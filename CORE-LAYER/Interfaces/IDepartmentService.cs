using CORE_LAYER.Dtos;
using CORE_LAYER.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Interfaces
{
   public interface IDepartmentService:IService<Department>
    {
       Task<CustomResponseDto<List<EmployeeDto>>> DepartmentWithEmployees(int depId);
       Task<CustomResponseDto<List<DepartmentwithEmployeeDto>>> DepartmentsDetail();
        Task<CustomResponseDto<DepartmentwithEmployeeDto>> DepartmentByIdDetail(int id);
        Task<CustomResponseDto<DepartmentwithEmployeeDto>> DepartmentDetail(int id);
    }
}
