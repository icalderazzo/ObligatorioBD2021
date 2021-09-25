using System.Collections.Generic;

namespace Obligatorio.Services.Interfaces
{
    public interface IService<T>
    {
        void Create(T entity);
        void Modify(T entity);
        ICollection<T> List();
        void Delete(string entityId);
        T GetById(string entityId);
    }
}