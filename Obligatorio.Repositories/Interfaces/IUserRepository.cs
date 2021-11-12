using Obligatorio.Domain.Model;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<Usuario>
    {
        Usuario GetForLogin(string username, string password);
        bool ExistsUserWithUsername(string username);
        bool ExistsUserWithPhoneNumber(int phoneNumber, int ci);
        bool ExistsUserWithCi(int ci);
        Usuario GetCompleteUserByUsername(string username);
        bool ExistsUserWithEmail(string email, int ci);
    }
}
