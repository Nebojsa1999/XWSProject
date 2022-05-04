using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        void Dispose();

    }
}
