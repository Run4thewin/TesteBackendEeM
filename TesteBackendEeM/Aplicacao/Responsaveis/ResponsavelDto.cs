using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEeM.Entidades;

namespace TesteBackendEeM.Aplicacao.Responsaveis
{
    public class ResponsavelDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Segmento Segmento { get; set; }
        public string FotoPerfilURL { get; set; }
        public string Email { get; set; }

    }
}
