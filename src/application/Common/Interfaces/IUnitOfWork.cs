using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPacienteRepository PacienteRepository { get; }
        Task<bool> Complete();
    }
}
