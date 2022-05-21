using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_LAYER.Interfaces
{
   public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
