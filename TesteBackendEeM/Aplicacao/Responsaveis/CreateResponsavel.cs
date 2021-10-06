using System;
using MediatR;
using System.Threading.Tasks;
using TesteBackendEeM.Entidades;
using System.Threading;
using AutoMapper;
using TesteBackendEeM.Persistencia.Contexto;

namespace TesteBackendEeM.Aplicacao.Responsaveis
{
    public class CreateResponsavel : IRequest<ResponsavelDto>
    {

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Parentesco Parentesco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public class Handler : IRequestHandler<CreateResponsavel, ResponsavelDto>
        {
            private readonly TesteBackendEeMDbContext _contexto;
            private readonly IMapper _mapper;

            public Handler(TesteBackendEeMDbContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<ResponsavelDto> Handle(CreateResponsavel request, CancellationToken cancellationToken)
            {
                var Entity = new Responsavel
                {
                    Nome = request.Nome,
                    DataNascimento = request.DataNascimento,
                    Parentesco = request.Parentesco,
                    Telefone = request.Telefone,
                    Email = request.Email
                };

                _contexto.Responsavel.Add(Entity);

                await _contexto.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ResponsavelDto>(Entity);
            }
        }
    }
}
