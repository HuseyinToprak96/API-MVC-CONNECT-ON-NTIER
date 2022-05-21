using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Dtos
{
    public class DepartmentwithEmployeeDto
    {
        public string Name { get; set; }
        public List<EmployeeDto> employeeDtos { get; set; }
    }
}
