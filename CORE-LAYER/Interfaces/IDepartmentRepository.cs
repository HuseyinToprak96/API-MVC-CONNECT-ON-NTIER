using CORE_LAYER.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Interfaces
{
   public interface IDepartmentRepository:IGenericRepository<Department>
    {
        Task<List<Employee>> DepartmentWithEmployees(int depId);
        Task<List<Department>> DepartmentsDetail();
        Task<Department> DepartmentByIdDetail(int id);
        Task<Department> DepartmentDetail(int id);

    }
}
