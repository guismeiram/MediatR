using application.Common.Mappings;
using AutoMapper;
using domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Paciente.Command.UpdatePaciente
{
    public class UpdatePacienteDto : IMapFrom<domain.Entities.Paciente>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Rg { get; set; }
        public Sexo Sexo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePacienteDto, domain.Entities.Paciente>();
        }
    }
}
