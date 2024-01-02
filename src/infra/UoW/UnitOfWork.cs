using application.Common.Interfaces;
using infra.Context;
using infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IPacienteRepository PacienteRepository => new PacienteRepository(_context);

        public async Task<bool> Complete()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            _context.Dispose();
        }

        


    }
}
