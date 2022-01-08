using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Insert(T model);
        T Update(T model);
        void Delete(string id);
        ICollection<T> List();
        T GetById(string id);
    }
}