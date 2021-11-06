using Obligatorio.Domain.Model;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<Usuario>
    {
        Usuario GetForLogin(string username, string password);
        bool ExistsUserWithUsername(string username);
        bool ExistsUserWithPhoneNumber(int phoneNumber);
        bool ExistsUserWithCi(int ci);
        Usuario GetUserByRole(long idOffer, int idRole);
    }
}
