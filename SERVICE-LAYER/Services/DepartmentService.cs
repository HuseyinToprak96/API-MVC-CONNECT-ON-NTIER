using AutoMapper;
using CORE_LAYER.Dtos;
using CORE_LAYER.Entities;
using CORE_LAYER.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE_LAYER.Services
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IGenericRepository<Department> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, IDepartmentRepository departmentRepository) : base(genericRepository, unitOfWork, mapper)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<CustomResponseDto<DepartmentwithEmployeeDto>> DepartmentByIdDetail(int id)
        {
            var department = await _departmentRepository.DepartmentByIdDetail(id);
            var dto = _mapper.Map<DepartmentwithEmployeeDto>(department);
            return CustomResponseDto<DepartmentwithEmployeeDto>.success(200, dto);
           
        }

        public async Task<CustomResponseDto<DepartmentwithEmployeeDto>> DepartmentDetail(int id)
        {
            var department = await _departmentRepository.DepartmentDetail(id);
            var dto = _mapper.Map<DepartmentwithEmployeeDto>(department);
            return CustomResponseDto<DepartmentwithEmployeeDto>.success(200, dto);
        }

        public async Task<CustomResponseDto<List<DepartmentwithEmployeeDto>>> DepartmentsDetail()
        {
            var departments = await _departmentRepository.DepartmentsDetail();
            var dtos = _mapper.Map<List<DepartmentwithEmployeeDto>>(departments);
            return CustomResponseDto<List<DepartmentwithEmployeeDto>>.success(200,dtos);
        }

        public async Task<CustomResponseDto<List<EmployeeDto>>> DepartmentWithEmployees(int depId)
        {
            var employees = await _departmentRepository.DepartmentWithEmployees(depId);
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);
            return CustomResponseDto<List<EmployeeDto>>.success(200, dtos);
        }
    }
}
