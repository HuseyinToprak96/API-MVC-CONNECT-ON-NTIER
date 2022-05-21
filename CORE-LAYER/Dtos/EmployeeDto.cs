using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Dtos
{
    //Add-Update
   public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
