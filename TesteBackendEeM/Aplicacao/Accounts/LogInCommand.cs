using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteBackendEeM.Persistencia.Contexto;

namespace TesteBackendEeM.Aplicacao.Accounts
{
    public class LogInCommand : IRequest<AccountDto>
    {
        public string Matricula { get; set; }
        public string Senha { get; set; }

        public class Handler : IRequestHandler<LogInCommand, AccountDto>
        {
            private readonly TesteBackendEeMDbContext _contexto;
            private readonly IMapper _mapper;

            public Handler(TesteBackendEeMDbContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<AccountDto> Handle(LogInCommand request, CancellationToken cancellationToken)
            {
                var Account = _contexto.Account.FirstOrDefault();

                if (Account == null)
                    throw new Exception("Usuário não encontrado");

                if (!Account.Password.Equals(request.Senha))
                    throw new Exception("Usuário ou senha errados");

                return _mapper.Map<AccountDto>(Account);

            }
        }

    }
}
