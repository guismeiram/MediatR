using domain.Common;
using domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Paciente : Entity
    {
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Rg {  get; set; }
        public Sexo Sexo {  get; set; } 
    }
}
