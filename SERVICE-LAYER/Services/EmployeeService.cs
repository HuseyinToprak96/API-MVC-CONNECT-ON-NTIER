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
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IGenericRepository<Employee> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, IEmployeeRepository employeeRepository) : base(genericRepository, unitOfWork, mapper)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<CustomResponseDto<EmployeeDetailDto>> EmployeeDetail(int id)
        {
            var employee = await _employeeRepository.EmployeeDetail(id);
            var dto = _mapper.Map<EmployeeDetailDto>(employee);
            return CustomResponseDto<EmployeeDetailDto>.success(200, dto);
        }

        public async Task<CustomResponseDto<List<EmployeeDetailDto>>> EmployeesDetail()
        {
            var employees = await _employeeRepository.EmployeesDetail();
            var dtos = _mapper.Map<List<EmployeeDetailDto>>(employees);
            return CustomResponseDto<List<EmployeeDetailDto>>.success(200, dtos);
        }

        public async Task<CustomResponseDto<List<EmployeeDepartmentDto>>> EmployeesWithDepartment()
        {
            var employees = await _employeeRepository.EmployeesWithDepartment();
            var dto = _mapper.Map<List<EmployeeDepartmentDto>>(employees);
            return CustomResponseDto<List<EmployeeDepartmentDto>>.success(200, dto);
        }
    }
}
