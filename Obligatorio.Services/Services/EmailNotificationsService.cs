using System;
using System.Threading.Tasks;
using EmailService;
using EmailService.Service;
using Obligatorio.Services.Interfaces;

namespace Obligatorio.Services.Services
{
    public class EmailNotificationsService : INotificationsService<Email>
    {
        private readonly IEmailService _emailService;
        public EmailNotificationsService(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Notify(Email notification)
        {
            try
            {
                await _emailService.SendEmailAsync(notification);
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }
    }
}
