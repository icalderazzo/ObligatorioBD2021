using Obligatorio.Domain.Model;
using System.Threading.Tasks;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<Usuario>
    {
        Task<Usuario> Get(string username, string password);
    }
}
