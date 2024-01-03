using application.Common.Interfaces;
using application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace application.Paciente.Command.DeletePaciente
{
    public class DeletePacienteCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _uow;

            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _uow.PacienteRepository.DeleteAsync(request.Id);

                if (!result) return Result<Unit>.Failure("Paciente not found");

                await _uow.Complete();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
