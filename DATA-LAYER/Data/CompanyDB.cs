using CORE_LAYER.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_LAYER.Data
{
  public  class CompanyDB:DbContext
    {
        public CompanyDB(DbContextOptions<CompanyDB> options):base(options)
        {
           
        }
       public DbSet<Employee> Employees { get; set; }
       public DbSet<Department>  Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
