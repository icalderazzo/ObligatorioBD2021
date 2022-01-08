using System.Threading.Tasks;

namespace Obligatorio.Services.Interfaces
{
    public interface INotificationsService<T>
    {
        void Notify(T notification);
        Task NotifyAsync(T notification);
    }
}
