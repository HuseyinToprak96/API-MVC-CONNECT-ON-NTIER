using CORE_LAYER.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
   public interface IController
    {


        Task List();
       Task Find(int id);
        
        Task Add(EmployeeDto employeeDto);
        Task AddRange(IEnumerable<EmployeeDto> employeeDtos);
        Task Update(EmployeeDto employeeDto);
        Task Delete(int id);
           }
}
