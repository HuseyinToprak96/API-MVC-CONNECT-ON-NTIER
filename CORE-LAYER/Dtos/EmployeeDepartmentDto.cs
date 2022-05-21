using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Dtos
{
    public class EmployeeDepartmentDto:EmployeeDto
    {
        public string DepartmentName { get; set; }
    }
}
