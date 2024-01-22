using application.Common.Interfaces;
using application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace application.Paciente.Queries.GetPacienteList
{
    public class GetPacienteListQuery
    {
        public class Query : IRequest<Result<IEnumerable<PacienteDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<IEnumerable<PacienteDto>>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<IEnumerable<PacienteDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var paciente = await _uow.PacienteRepository.GetAsyncList();

                return Result<IEnumerable<PacienteDto>>.Success(_mapper.Map<IEnumerable<PacienteDto>>(paciente));
            }
        }
    }
}
