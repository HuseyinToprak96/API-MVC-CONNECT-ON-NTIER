using CORE_LAYER.Interfaces;
using DATA_LAYER.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATA_LAYER.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CompanyDB _companyDB;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(CompanyDB companyDB)
        {
            _companyDB = companyDB;
            _dbSet = companyDB.Set<T>();
            companyDB.Database.EnsureCreated();
        }

        public async Task AddAsync(T Tentity)
        {
            await _dbSet.AddAsync(Tentity);
           
        }

        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            await _dbSet.AddRangeAsync(Entities);
        }

        public async Task<List<T>> gelAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T Tentity)
        {
            _dbSet.Remove(Tentity);
        }

        public void RemoveRange(List<T> Entities)
        {
            _dbSet.RemoveRange(Entities);
        }

        public void Update(T Tentity)
        {
            _dbSet.Update(Tentity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
