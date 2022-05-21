using CORE_LAYER.Dtos;
using CORE_LAYER.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Interfaces
{
   public interface IEmployeeService:IService<Employee>
    {
        Task<CustomResponseDto<List<EmployeeDetailDto>>> EmployeesDetail();
        Task<CustomResponseDto<EmployeeDetailDto>> EmployeeDetail(int id);
        Task<CustomResponseDto<List<EmployeeDepartmentDto>>> EmployeesWithDepartment();
    }
}
