﻿using application.Common.Interfaces;
using application.Common.Models;
using application.Paciente.Command.UpdatePaciente;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace application.Paciente.Queries.GetPaciente
{
    public class GetPacienteQuery
    {
        public class Query : IRequest<Result<PacienteDto>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<PacienteDto>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<PacienteDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var paciente = await _uow.PacienteRepository
                    .AsQueryable(x => x.Id == request.Id)
                    .ProjectTo<PacienteDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                return Result<PacienteDto>.Success(paciente);
            }
        }
    }
}