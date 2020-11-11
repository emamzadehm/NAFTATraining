using System.Collections.Generic;
using System.Linq;
using _01.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01.Framework.Infrastructure.EFCore
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T:class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context) 
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }
    }
}
