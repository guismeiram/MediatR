using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<domain.Entities.Paciente> Pacientes { get; }

    }
}
