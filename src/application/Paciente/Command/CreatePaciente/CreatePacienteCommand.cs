﻿

using application.Common.Interfaces;
using application.Common.Models;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace application.Paciente.Command.CreatePaciente
{
    public class CreatePacienteCommand 
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreatePacienteDto Paciente { get; set; }
        }

        

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var paciente = _mapper.Map<domain.Entities.Paciente>(request.Paciente);

                var pacienteRecebe = await _uow.PacienteRepository.AddAsync(paciente);

                var result = await _uow.Complete();

                if (result) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to create a new tarefa");
            }

        }
        
    }
}
