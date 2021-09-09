using System.Collections.Generic;

namespace Obligatorio.Services.Interfaces
{
    public interface IService<T>
    {
        int Create(T entity);
        int Modify(T entity);
        ICollection<T> List();
        int Delete(string entityId);
        T GetById(string entityId);
    }
}