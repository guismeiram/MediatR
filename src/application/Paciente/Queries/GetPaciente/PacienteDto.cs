using application.Common.Mappings;
using application.Paciente.Command.UpdatePaciente;
using AutoMapper;
using domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Paciente.Queries.GetPaciente
{
    public class PacienteDto : IMapFrom<domain.Entities.Paciente>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Rg { get; set; }
        public Sexo Sexo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePacienteDto, domain.Entities.Paciente>().ReverseMap()
                                .ForMember(x => x.Sexo, opt => opt.MapFrom(src => src.Sexo));

        }
    }
}
