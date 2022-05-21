using CORE_LAYER.Interfaces;
using DATA_LAYER.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_LAYER.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDB _companyDB;

        public UnitOfWork(CompanyDB companyDB)
        {
            _companyDB = companyDB;
        }

        public void Commit()
        {
            _companyDB.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _companyDB.SaveChangesAsync();
        }
    }
}
