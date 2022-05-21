using CORE_LAYER.Entities;
using CORE_LAYER.Interfaces;
using DATA_LAYER.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_LAYER.Repository
{
   public class EmployeeRepository:GenericRepository<Employee>,IEmployeeRepository
    {

        public EmployeeRepository(CompanyDB companyDB):base(companyDB)
        {

        }

        public async Task<Employee> EmployeeDetail(int id)
        {
            return await _companyDB.Employees.Include(x => x.department).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Employee>> EmployeesDetail()
        {
            return await _companyDB.Employees.Include(x => x.department).ToListAsync();
        }

        public async Task<List<Employee>> EmployeesWithDepartment()
        {
            return await _companyDB.Employees.Include(x => x.department).ToListAsync();
           
        }
    }
}
