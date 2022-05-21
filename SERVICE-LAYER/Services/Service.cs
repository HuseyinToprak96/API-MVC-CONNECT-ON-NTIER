using AutoMapper;
using CORE_LAYER.Interfaces;
using SERVICE_LAYER.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE_LAYER.Services
{
    public class Service<T> : IService<T> where T:class
    {
        protected readonly IGenericRepository<T> _genericRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public Service(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<T> AddAsync(T Tentity)
        {
            await _genericRepository.AddAsync(Tentity);
            await _unitOfWork.CommitAsync();
            return Tentity;
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> Entities)
        {
            await _genericRepository.AddRangeAsync(Entities);
            await _unitOfWork.CommitAsync();
            return Entities;
        }

        public async Task<List<T>> gelAllAsync()
        {
            return await _genericRepository.gelAllAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            var result= await _genericRepository.getByIdAsync(id);
            if (result == null)
            {
                throw new NotFoundException($"{typeof(T).Name}({id}) not found");
            }
            
            return result;
        }

        public async Task Remove(T Tentity)
        {
            _genericRepository.Remove(Tentity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRange(List<T> Entities)
        {
            _genericRepository.RemoveRange(Entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(T Tentity)
        {
            _genericRepository.Update(Tentity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return _genericRepository.Where(expression);
        }
    }
}
