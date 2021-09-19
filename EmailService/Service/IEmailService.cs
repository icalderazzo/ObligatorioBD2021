using System.Threading.Tasks;

namespace EmailService.Service
{
    public interface IEmailService
    {
        void SendEmail(Email email);
        Task SendEmailAsync(Email email);
    }
}
