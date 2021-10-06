using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using TesteBackendEeM.Entidades;
using TesteBackendEeM.Persistencia.Contexto;
using System.Data.Entity;
using System.Linq;

namespace TesteBackendEeM.Aplicacao.Responsaveis
{
        public class GetAllResponsavel : IRequest<IEnumerable<ResponsavelDto>>   
        {

            public class Handler : IRequestHandler<GetAllResponsavel, IEnumerable<ResponsavelDto>>
            {
                private readonly TesteBackendEeMDbContext _contexto;
                private readonly IMapper _mapper;
            
            public Handler(TesteBackendEeMDbContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<IEnumerable<ResponsavelDto>> Handle(GetAllResponsavel request, CancellationToken cancellationToken)
            {
                var Query = _contexto.Responsavel.AsNoTracking();

                return _mapper.Map<IEnumerable<ResponsavelDto>>(Query);
            }
        }
    }
}
