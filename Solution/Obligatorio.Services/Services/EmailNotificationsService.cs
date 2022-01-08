using EmailService;
using EmailService.Service;
using Obligatorio.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Obligatorio.Services.Services
{
    public class EmailNotificationsService : INotificationsService<Email>
    {
        private readonly IEmailService _emailService;
        public EmailNotificationsService(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void Notify(Email notification)
        {
            try
            {
                _emailService.SendEmail(notification);
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }

        public Task NotifyAsync(Email notification)
        {
            throw new NotImplementedException();
        }
    }
}
