using System.Collections.Generic;

namespace _01.Framework.Domain
{
    public interface IRepository<TKey, T>
    {
        void Create(T entity);
        T GetBy(TKey id);
        List<T> GetAll();
    }
}
