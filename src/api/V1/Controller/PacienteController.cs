using api.Controller;
using application.Common.Models;
using application.Paciente.Command.CreatePaciente;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.V1.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreatePacienteDto paciente)
        {
            var result = await Mediator.Send(new CreatePacienteCommand.Command { Paciente = paciente });

            return HandleResult(result);
        }

       
    }
}
