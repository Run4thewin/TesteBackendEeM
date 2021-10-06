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

namespace TesteBackendEeM.Aplicacao.Alunos
{
        public class GetAllAluno : IRequest<IEnumerable<AlunoDto>>   
        {
            public string Nome { get; set; }
            public Segmento? Segmento { get; set; }
            public int? ResponsavelId { get; set; }

            public class Handler : IRequestHandler<GetAllAluno, IEnumerable<AlunoDto>>
            {
                private readonly TesteBackendEeMDbContext _contexto;
                private readonly IMapper _mapper;
            
            public Handler(TesteBackendEeMDbContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<IEnumerable<AlunoDto>> Handle(GetAllAluno request, CancellationToken cancellationToken)
            {
                var Query = _contexto.Aluno.AsNoTracking();

                if(!String.IsNullOrEmpty(request.Nome))
                    Query = Query.Where(x => x.Nome == request.Nome);
                
                if(request.Segmento.HasValue)
                    Query = Query.Where(x => x.Segmento == request.Segmento);
                
                if(request.ResponsavelId.HasValue)
                    Query = Query.Where(x => x.Responsaveis.Count > 0);

                return _mapper.Map<IEnumerable<AlunoDto>>(Query);
            }
        }
    }
}
