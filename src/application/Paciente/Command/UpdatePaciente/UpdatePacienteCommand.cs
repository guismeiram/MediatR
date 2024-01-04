﻿using application.Common.Interfaces;
using application.Common.Models;
using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace application.Paciente.Command.UpdatePaciente
{
    public class UpdatePacienteCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdatePacienteDto Paciente { get; set; }
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

                await _uow.PacienteRepository.UpdateAsync(paciente);

                var result = await _uow.Complete();

                
            }
        }
    }
}
