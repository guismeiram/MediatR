using System;
using System.Reflection;
using application.Common.Mappings;
using application.Paciente.Queries.GetPacienteList;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
           

            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(CreatePacienteCommand.Command).GetTypeInfo().Assembly));
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(GetPacienteListQuery.Handler).GetTypeInfo().Assembly));
            // services.AddMediatR(cf => cf.
            //AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }
    }
}
