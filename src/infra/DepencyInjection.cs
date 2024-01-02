using application.Common.Interfaces.Repository;
using application.Common.Interfaces;
using infra.Repository.Base;
using infra.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infra.Repository;
using infra.Context;

namespace infra
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPacienteRepository, PacienteRepository>();


            return services;
        }
    }
}
