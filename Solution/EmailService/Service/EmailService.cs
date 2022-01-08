using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace EmailService.Service
{
    public class EmailService : IEmailService
    {
        private readonly Settings _emailSettings;
        public EmailService(IOptions<Settings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public void SendEmail(Email email)
        {
            SmtpClient client = null;
            try
            {
                var emailRequest = new MimeMessage();
                emailRequest.Sender = MailboxAddress.Parse(_emailSettings.EmailAccount);
                emailRequest.To.Add(MailboxAddress.Parse(email.ToEmail));
                emailRequest.Subject = email.Subject;

                var bodyBuilder = new BodyBuilder();
                //bodyBuilder.HtmlBody = email.Body;
                bodyBuilder.TextBody = email.Body;
                emailRequest.Body = bodyBuilder.ToMessageBody();

                client = new SmtpClient();
                client.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                client.Authenticate(_emailSettings.EmailAccount, _emailSettings.Password);
                client.Send(emailRequest);
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
            finally
            {
                if (client != null)
                {
                    client.Disconnect(true);
                }
            }
        }

        public async Task SendEmailAsync(Email email)
        {
            SmtpClient client = null;
            try
            {
                var emailRequest = new MimeMessage();
                emailRequest.Sender = MailboxAddress.Parse(_emailSettings.EmailAccount);
                emailRequest.To.Add(MailboxAddress.Parse(email.ToEmail));
                emailRequest.Subject = email.Subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = email.Body;
                emailRequest.Body = bodyBuilder.ToMessageBody();

                using (client = new SmtpClient())
                {
                    client.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                    client.Authenticate(_emailSettings.EmailAccount, _emailSettings.Password);
                    await client.SendAsync(emailRequest);
                }
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
            finally
            {
                if (client != null)
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
