using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Entities
{
    public class Employee:BaseEntity
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
    }
}
