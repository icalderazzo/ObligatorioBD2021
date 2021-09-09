using System.Collections.Generic;
using System.Threading.Tasks;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<int> Insert(T model);
        Task<int> Update(T model);
        Task Delete(string id);
        Task<ICollection<T>> List();
        Task<T> GetById(string id);
    }
}