using Obligatorio.Domain.Model;

namespace Obligatorio.Services.Interfaces
{
    public interface IUserService : IService<Usuario>
    {
        Usuario Login(Usuario usuario);
    }
}
