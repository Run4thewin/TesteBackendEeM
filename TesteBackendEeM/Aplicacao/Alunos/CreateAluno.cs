using System;
using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using TesteBackendEeM.Entidades;
using System.Threading;
using AutoMapper;
using TesteBackendEeM.Persistencia.Contexto;

namespace TesteBackendEeM.Aplicacao.Alunos
{
        public class CreateAluno : IRequest<AlunoDto>   
        {
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            public Segmento Segmento { get; set; }
            public string FotoPerfilURL { get; set; }
            public string Email { get; set; }
            public List<Responsavel> Responsaveis { get; set; }

            public class Handler : IRequestHandler<CreateAluno, AlunoDto>
            {
                private readonly TesteBackendEeMDbContext _contexto;
                private readonly IMapper _mapper;
            
            public Handler(TesteBackendEeMDbContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<AlunoDto> Handle(CreateAluno request, CancellationToken cancellationToken)
            {

                if (request.Segmento == Segmento.Medio && String.IsNullOrEmpty(request.Email))
                    throw new Exception("Necessario informar Email Para anulos do segmento Ensino médio");

                var Entity = new Aluno
                {
                    Nome = request.Nome,
                    DataNascimento = request.DataNascimento,
                    Segmento = request.Segmento,
                    FotoPerfilURL = request.FotoPerfilURL,
                    Email = request.Email,
                    Responsaveis = request.Responsaveis,
                };

                _contexto.Aluno.Add(Entity);

                await _contexto.SaveChangesAsync(cancellationToken);

                return _mapper.Map<AlunoDto>(Entity);
            }
        }
    }
}
