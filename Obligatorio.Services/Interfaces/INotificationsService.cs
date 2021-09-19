using System.Threading.Tasks;

namespace Obligatorio.Services.Interfaces
{
    public interface INotificationsService<T>
    {
        Task Notify(T notification);
    }
}
