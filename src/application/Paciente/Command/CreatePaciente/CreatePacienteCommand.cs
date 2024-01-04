using application.Common.Interfaces;
using application.Common.Models;
using AutoMapper;
using domain.Enums;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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


                return Result.Ok(pacienteRecebe);
            }
        }
        
    }
}
