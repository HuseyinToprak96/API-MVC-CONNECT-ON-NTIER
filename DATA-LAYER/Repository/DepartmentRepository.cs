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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CompanyDB companyDB) : base(companyDB)
        {
        }

        public async Task<Department> DepartmentByIdDetail(int id)
        {
            return await _companyDB.Departments.Include(x => x.employees).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Department> DepartmentDetail(int id)
        {
            return await _companyDB.Departments.Include(x => x.employees).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Department>> DepartmentsDetail()
        {
            return await _companyDB.Departments.Include(x => x.employees).ToListAsync();
        }

        public async Task<List<Employee>> DepartmentWithEmployees(int depId)
        {
          var department=  await _companyDB.Departments.Include(x => x.employees).Where(x => x.Id ==depId).SingleOrDefaultAsync();
            return department.employees;
        }
    }
}
