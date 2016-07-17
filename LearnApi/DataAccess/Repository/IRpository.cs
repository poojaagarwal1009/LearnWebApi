using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public interface IRpository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);

        T Get(T entity);

        void Update(T entity);
        void Update(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(IEnumerable<T> entities);

        IQueryable<T> Table { get; }
    }
}
