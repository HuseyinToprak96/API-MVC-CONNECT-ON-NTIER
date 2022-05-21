using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Entities
{
   public class Department:BaseEntity
    {
        public string Name { get; set; }
        public List<Employee> employees { get; set; }
    }
}
