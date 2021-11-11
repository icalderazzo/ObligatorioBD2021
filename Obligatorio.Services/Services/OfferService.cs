using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using Obligatorio.Services.Interfaces;
using System.Collections.Generic;
using System;
using EmailService;
using static Obligatorio.Domain.Emails.EmailBodies;
using System.Threading.Tasks;

namespace Obligatorio.Services.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IPostsService _postService;
        private readonly INotificationsService<Email> _emailNotificationsService;
        private readonly IValidator<Oferta> _offerValidator;
        public OfferService(
            IOfferRepository offerRepository, 
            IPostsService postsService, 
            INotificationsService<Email> emailNotificationsService,
            IValidator<Oferta> offerValidator
        )
        {
            _offerValidator = offerValidator;
            _postService = postsService;
            _offerRepository = offerRepository;
            _emailNotificationsService = emailNotificationsService;
        }
        public void Create(Oferta entity)
        {
            var validation_result = _offerValidator.Validate(entity);

            if (validation_result.Item1)
            {
                _offerRepository.Insert(entity);

                // Si es una contraoferta envio mail de contraoferta a emisor
                if (entity.TransaccionContraofertada != null)
                {
                    var recieverPosts = new List<string>();

                    // Obtengo las publicaciones del emisor porque estoy parado en la contraoferta
                    // Estas publicaciones son las mismas que las PublicacionesDestinatario de la oferta original
                    foreach (Publicacion pub in entity.PublicacionesEmisor)
                    {
                        recieverPosts.Add(pub.Articulo.Nombre);
                    }

                    _emailNotificationsService.Notify(new Email()
                    {
                        Subject = "Oferta contraofertada",
                        Body = SenderCounterOfferEmailBody(
                                    name: entity.UsuarioEmisor.Nombre,
                                    surname: entity.UsuarioEmisor.Apellido,
                                    postsnames: recieverPosts
                                ),
                        ToEmail = entity.UsuarioEmisor.Correo
                    });
                }
                // Sino envio mail de oferta recibida a destinatario
                else 
                {
                    var senderPosts = new List<string>();

                    foreach (Publicacion pub in entity.PublicacionesEmisor)
                    {
                        senderPosts.Add(pub.Articulo.Nombre);
                    }

                    _emailNotificationsService.Notify(new Email()
                    {
                        Subject = "Oferta recibida",
                        Body = RecieverNewOfferEmailBody(
                                    name: entity.UsuarioDestinatario.Nombre,
                                    surname: entity.UsuarioDestinatario.Apellido,
                                    postsnames: senderPosts
                                ),
                        ToEmail = entity.UsuarioDestinatario.Correo
                    });
                }
            }
            else 
            {
                throw new InvalidOperationException(validation_result.Item2);
            }
        }

        public void Delete(string entityId)
        {
            throw new System.NotImplementedException();
        }

        public Oferta GetById(string entityId)
        {
            try
            {
                var offer = _offerRepository.GetById(entityId);
                offer.UsuarioEmisor = _offerRepository.GetUserByRole(EnumRoles.RolOferta.Emisor, offer.IdOferta);
                offer.UsuarioDestinatario = _offerRepository.GetUserByRole(EnumRoles.RolOferta.Destinatario, offer.IdOferta);
                offer.PublicacionesEmisor = _postService.GetPostsInOffer(offer.IdOferta, offer.UsuarioEmisor.Cedula);
                offer.PublicacionesDestinatario = _postService.GetPostsInOffer(offer.IdOferta, offer.UsuarioDestinatario.Cedula);
                offer.TransaccionContraofertada = _offerRepository.GetCounterOffer(offer.IdOferta);

                return offer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Oferta> FilterOffers(OfferFilter filter)
        {
            // Obtain offers that the user recieved and are pending
            var offersRecieved = _offerRepository.FilterOffers(filter);

            foreach (var offer in offersRecieved)
            {
;               offer.UsuarioEmisor = _offerRepository.GetUserByRole(EnumRoles.RolOferta.Emisor, offer.IdOferta);
                offer.UsuarioDestinatario = _offerRepository.GetUserByRole(EnumRoles.RolOferta.Destinatario, offer.IdOferta);
                offer.PublicacionesEmisor = _postService.GetPostsInOffer(offer.IdOferta, offer.UsuarioEmisor.Cedula);
                offer.PublicacionesDestinatario = _postService.GetPostsInOffer(offer.IdOferta, offer.UsuarioDestinatario.Cedula);
                offer.TransaccionContraofertada = _offerRepository.GetCounterOffer(offer.IdOferta);
            }

            return offersRecieved;
        }

        public ICollection<Oferta> List()
        {
            throw new System.NotImplementedException();
        }

        public void Modify(Oferta entity)
        {
            throw new System.NotImplementedException();
        }

        public void AcceptOffer(Oferta offer)
        {
            try
            {
                _offerRepository.UpdateOfferState(offer.IdOferta, EnumOfertas.EstadoOferta.Completada);

                var sendersPosts = new List<string>();
                var receiversPosts = new List<string>();

                foreach (Publicacion pub in offer.PublicacionesDestinatario)
                {
                    _postService.UpdatePostState(pub.IdPublicacion, false);
                    receiversPosts.Add(pub.Articulo.Nombre);
                }

                foreach (Publicacion pub in offer.PublicacionesEmisor)
                {
                    _postService.UpdatePostState(pub.IdPublicacion, false);
                    sendersPosts.Add(pub.Articulo.Nombre);
                }

                _emailNotificationsService.Notify(new Email()
                {
                    Subject = "Oferta aceptada",
                    Body = SenderAcceptedOfferEmailBody(
                                name: offer.UsuarioEmisor.Nombre,
                                surname: offer.UsuarioEmisor.Apellido,
                                postsnames: receiversPosts,
                                receiversName: offer.UsuarioDestinatario.Nombre,
                                receiversSurname: offer.UsuarioDestinatario.Apellido,
                                receiversEmail: offer.UsuarioDestinatario.Correo
                           ),
                    ToEmail = offer.UsuarioEmisor.Correo
                });

                _emailNotificationsService.Notify(new Email()
                {
                    Subject = "Oferta aceptada",
                    Body = ReceiversAcceptedOfferEmailBody(
                                name: offer.UsuarioDestinatario.Nombre,
                                surname: offer.UsuarioDestinatario.Apellido,
                                postsnames: sendersPosts,
                                sendersName: offer.UsuarioEmisor.Nombre,
                                sendersSurname: offer.UsuarioEmisor.Apellido,
                                sendersEmail: offer.UsuarioEmisor.Correo
                            ),
                    ToEmail = offer.UsuarioDestinatario.Correo
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CancelOffer(Oferta offer)
        {
            try
            {
                _offerRepository.UpdateOfferState(offer.IdOferta, EnumOfertas.EstadoOferta.Rechazada);

                var receiversPosts = new List<string>();

                foreach (Publicacion pub in offer.PublicacionesDestinatario)
                {
                    receiversPosts.Add(pub.Articulo.Nombre);
                }

                _emailNotificationsService.Notify(new Email()
                {
                    Subject = "Oferta rechazada",
                    Body = SenderRejectedOfferEmailBody(
                                name: offer.UsuarioEmisor.Nombre,
                                surname: offer.UsuarioEmisor.Apellido,
                                postsnames: receiversPosts
                            ),
                    ToEmail = offer.UsuarioEmisor.Correo
                });
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }

}