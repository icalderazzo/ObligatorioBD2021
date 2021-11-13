
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain.Emails
{
    public static class EmailBodies
    {
        private static readonly StringBuilder stringBuilder = new StringBuilder();
        public static string SenderAcceptedOfferEmailBody(
            string name, 
            string surname,
            List<string> postsnames,
            string receiversName,
            string receiversSurname,
            string receiversEmail)
        {
            stringBuilder.Clear();
            stringBuilder.AppendLine($"Hola, {name} {surname}!");
            stringBuilder.AppendLine("La oferta que realizaste por: ");
            stringBuilder.AppendLine();
            foreach (var post in postsnames)
            {
                stringBuilder.AppendLine($"- {post}");
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Ha sido aceptada.");
            stringBuilder.AppendLine($"Ponte en contacto con " +
                $"{receiversName} {receiversSurname} " +
                $"a través de su correo: {receiversEmail} para concretar el trueque");

            return stringBuilder.ToString();
        }

        public static string ReceiversAcceptedOfferEmailBody(
            string name,
            string surname,
            List<string> postsnames,
            string sendersName,
            string sendersSurname,
            string sendersEmail)
        {
            stringBuilder.Clear();
            stringBuilder.AppendLine($"Hola, {name} {surname}!");
            stringBuilder.AppendLine($"Has aceptado la oferta que te realizó {sendersName} {sendersSurname}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Recibirás los siguientes articulos:");
            foreach (var post in postsnames)
            {
                stringBuilder.AppendLine($"- {post}");
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Ponte en contacto con " +
                $"{sendersName} " +
                $"a través de su correo: {sendersEmail} para concretar el trueque");

            return stringBuilder.ToString();
        }

        public static string SenderRejectedOfferEmailBody(
            string name,
            string surname,
            List<string> postsnames
            )
        {
            stringBuilder.Clear();
            stringBuilder.AppendLine($"Hola, {name} {surname}!");
            stringBuilder.AppendLine("Lamentamos informarte que la oferta que realizaste por: ");
            stringBuilder.AppendLine();
            foreach (var post in postsnames)
            {
                stringBuilder.AppendLine($"- {post}");
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Ha sido rechazada.");

            return stringBuilder.ToString();
        }

        public static string SenderCounterOfferEmailBody(
            string name,
            string surname,
            List<string> postsnames
            )
        {
            stringBuilder.Clear();
            stringBuilder.AppendLine($"Hola, {name} {surname}!");
            stringBuilder.AppendLine("La oferta que realizaste por: ");
            stringBuilder.AppendLine();
            foreach (var post in postsnames)
            {
                stringBuilder.AppendLine($"- {post}");
            }
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Ha sido contraofertada.");
            stringBuilder.AppendLine("Revisa tu pestaña de ofertas.");

            return stringBuilder.ToString();
        }

        public static string RecieverNewOfferEmailBody(
            string name,
            string surname,
            List<string> sendersPostsnames,
            List<string> receiversPostnames
            )
        {
            stringBuilder.Clear();
            stringBuilder.AppendLine($"Hola, {name} {surname}!");
            stringBuilder.AppendLine("Has recibido una oferta!");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine("Te han ofrecido: ");
            foreach (var post in sendersPostsnames)
            {
                stringBuilder.AppendLine($"- {post}");
            }
            stringBuilder.AppendLine();

            stringBuilder.AppendLine("Por tus siguientes publicaciones: ");
            foreach (var p in receiversPostnames)
            {
                stringBuilder.AppendLine($"- {p}");
            }
            stringBuilder.AppendLine();

            stringBuilder.AppendLine("Revisa tu pestaña de ofertas.");
            return stringBuilder.ToString();
        }

    }
}
