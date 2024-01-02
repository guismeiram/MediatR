using System.Reflection;
using application.Common.Mappings;
using application.Paciente.Command.CreatePaciente;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(typeof(MappingProfile));
            //services.AddMediatR(typeof(CreatePacienteCommand.Command).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(CreatePacienteCommand).GetTypeInfo().Assembly));


            return services;
        }
    }
}
