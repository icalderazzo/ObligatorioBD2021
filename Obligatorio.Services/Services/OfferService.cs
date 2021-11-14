using EmailService;
using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using Obligatorio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Obligatorio.Domain.Emails.EmailBodies;

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
                var postsInOffer = entity.PublicacionesEmisor.Union(entity.PublicacionesDestinatario).ToList();

                if (_offerRepository.CheckForExistingOffer(postsInOffer))
                    throw new InvalidOperationException("Ya existe una oferta pendiente que contiene a los articulos seleccionados");

                _offerRepository.Insert(entity);


                Thread t = new Thread(o =>
                {
                    var offer = (Oferta)o;
                    // Si es una contraoferta envio mail de contraoferta a emisor
                    if (entity.TransaccionContraofertada != null)
                    {
                        var recieverPosts = new List<string>();

                        // Obtengo las publicaciones del emisor porque estoy parado en la contraoferta
                        // Estas publicaciones son las mismas que las PublicacionesDestinatario de la oferta original
                        foreach (Publicacion pub in offer.PublicacionesEmisor)
                        {
                            recieverPosts.Add(pub.Articulo.Nombre);
                        }

                        _emailNotificationsService.Notify(new Email()
                        {
                            Subject = "Oferta contraofertada",
                            Body = SenderCounterOfferEmailBody(
                                        name: offer.UsuarioEmisor.Nombre,
                                        surname: offer.UsuarioEmisor.Apellido,
                                        postsnames: recieverPosts
                                    ),
                            ToEmail = offer.UsuarioEmisor.Correo
                        });
                    }
                    // Sino envio mail de oferta recibida a destinatario
                    else
                    {
                        var senderPosts = new List<string>();
                        var receiversPosts = new List<string>();

                        foreach (Publicacion pub in offer.PublicacionesEmisor)
                        {
                            senderPosts.Add(pub.Articulo.Nombre);
                        }

                        foreach (var post in offer.PublicacionesDestinatario)
                        {
                            receiversPosts.Add(post.Articulo.Nombre);
                        }

                        _emailNotificationsService.Notify(new Email()
                        {
                            Subject = "Oferta recibida",
                            Body = RecieverNewOfferEmailBody(
                                        name: offer.UsuarioDestinatario.Nombre,
                                        surname: offer.UsuarioDestinatario.Apellido,
                                        sendersPostsnames: senderPosts,
                                        receiversPostnames: receiversPosts
                                    ),
                            ToEmail = offer.UsuarioDestinatario.Correo
                        });
                    }
                })
                {
                    IsBackground = true,
                    Name = "AfterCreateOffer"
                };

                t.Start(entity);
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
                ; offer.UsuarioEmisor = _offerRepository.GetUserByRole(EnumRoles.RolOferta.Emisor, offer.IdOferta);
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

                Thread t = new Thread(o =>
                {
                    var offer = (Oferta)o;

                    var allPosts = offer.PublicacionesEmisor.Union(offer.PublicacionesDestinatario).ToList();
                    var otherOffers = _offerRepository.GetPendingOffersWithPosts(offer.IdOferta, allPosts);

                    foreach (var idOffer in otherOffers)
                    {
                        _offerRepository.UpdateOfferState(idOffer, EnumOfertas.EstadoOferta.Cancelada);
                    }

                    var sendersPosts = new List<string>();
                    var receiversPosts = new List<string>();

                    foreach (Publicacion pub in offer.PublicacionesDestinatario)
                    {
                        // cambiar estado de todas las ofertas en las que aparezca pub
                        _postService.UpdatePostState(pub.IdPublicacion, false);
                        receiversPosts.Add(pub.Articulo.Nombre);
                    }

                    foreach (Publicacion pub in offer.PublicacionesEmisor)
                    {
                        // cambiar estado de todas las ofertas en las que aparezca pub
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
                })
                {
                    IsBackground = true,
                    Name = "AfterAcceptOffer"
                };

                t.Start(offer);
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

                Thread t = new Thread(o =>
                {
                    var offer = (Oferta)o;
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
                })
                {
                    IsBackground = true,
                    Name = "AfterRejectOffer"
                };

                t.Start(offer);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}