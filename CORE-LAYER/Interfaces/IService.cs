using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Interfaces
{
   public interface IService<T> where T:class
    {
        Task<List<T>> gelAllAsync();
        Task<T> getByIdAsync(int id);
        Task<T> AddAsync(T Tentity);
        Task<IEnumerable<T>> AddRange(IEnumerable<T> Entities);
        Task Remove(T Tentity);
        Task RemoveRange(List<T> Entities);
        Task Update(T Tentity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
