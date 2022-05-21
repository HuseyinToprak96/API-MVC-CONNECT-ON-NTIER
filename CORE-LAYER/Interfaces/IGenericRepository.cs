using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Interfaces
{
   public interface IGenericRepository<T> where T:class
    {
        Task<List<T>> gelAllAsync();
        Task<T> getByIdAsync(int id);
        Task AddAsync(T Tentity);
        Task AddRangeAsync(IEnumerable<T> Entities);
        void Remove(T Tentity);
        void RemoveRange(List<T> Entities);
        void Update(T Tentity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
