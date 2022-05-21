using CORE_LAYER.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Interfaces
{
   public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        Task<List<Employee>> EmployeesDetail();
        Task<Employee> EmployeeDetail(int id);
        Task<List<Employee>> EmployeesWithDepartment();
    }
}
