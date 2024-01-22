using application.Common.Interfaces;
using domain.Entities;
using infra.Context;
using infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {   
        public PacienteRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }

     
    }
}
