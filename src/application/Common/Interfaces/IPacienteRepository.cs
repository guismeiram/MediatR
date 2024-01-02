using application.Common.Interfaces.Repository;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common.Interfaces
{
    public interface IPacienteRepository : IRepository<domain.Entities.Paciente>
    {
    }
}
