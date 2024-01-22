using api.Controller;
using application.Common.Models;
using application.Paciente.Command.CreatePaciente;
using application.Paciente.Command.DeletePaciente;
using application.Paciente.Command.UpdatePaciente;
using application.Paciente.Queries.GetPaciente;
using application.Paciente.Queries.GetPacienteList;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePacienteDto paciente)
        {
            var result = await Mediator.Send(new UpdatePacienteCommand.Command { Paciente = paciente });

            return HandleResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeletePacienteCommand.Command { Id = id });

            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetPacienteQuery.Query { Id = id});


            return HandleResult(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetPacienteListQuery.Query());

            return HandleResult(result);
        }

    }
}
