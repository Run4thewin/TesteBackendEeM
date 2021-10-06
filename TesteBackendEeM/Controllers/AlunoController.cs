using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEeM.Aplicacao.Alunos;
using TesteBackendEeM.Entidades;

namespace TesteBackendEeM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly ILogger<AlunoController> _logger;
        private readonly IMediator _mediator;

        public AlunoController(ILogger<AlunoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<AlunoDto>> GetAll(string nome, Segmento segmento, int responsavelId)
        {
            return await _mediator.Send(new GetAllAluno() {
                Nome = nome,
                Segmento = segmento,
                ResponsavelId = responsavelId
            });
        }
    }
}
