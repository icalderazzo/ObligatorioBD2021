using System.Collections.Generic;
using System.Threading.Tasks;

namespace Obligatorio.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Insert(T model);
        Task<T> Update(T model);
        Task Delete(string id);
        Task<ICollection<T>> List();
        Task<T> GetById(string id);
    }
}