using application.Common.Mappings;
using AutoMapper;
using System;

namespace application.Paciente.Queries.GetPacienteList
{
    public class PacienteDto : IMapFrom<domain.Entities.Paciente>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Rg { get; set; }
        public int Sexo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<domain.Entities.Paciente, PacienteDto>();
        }

    }
}
