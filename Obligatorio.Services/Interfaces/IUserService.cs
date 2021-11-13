using Obligatorio.Domain.Model;

namespace Obligatorio.Services.Interfaces
{
    public interface IUserService : IService<Usuario>
    {
        Usuario Login(string username, string password);
        bool IsUserAllowedToChangePassword(string username, string oldPassword);   
    }
}
