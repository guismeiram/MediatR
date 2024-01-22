using application.Common.Interfaces;
using application.Common.Models;
using application.Paciente.Command.UpdatePaciente;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using domain.Common;
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
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _uow;
            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<PacienteDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                var results = await _uow.PacienteRepository.GetAsyncById(request.Id);


                //var results = await _uow.PacienteRepository.GetAsync(e => e.Id == request.Id);

                

                return Result<PacienteDto>.Success(_mapper.Map<PacienteDto>(results));
            }
        }
    }
}
