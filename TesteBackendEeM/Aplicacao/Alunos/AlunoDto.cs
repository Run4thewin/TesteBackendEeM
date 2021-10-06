using System;
using TesteBackendEeM.Entidades;

namespace TesteBackendEeM.Aplicacao.Alunos
{
    public class AlunoDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Segmento Segmento { get; set; }
        public string FotoPerfilURL { get; set; }
        public string Email { get; set; }

    }
}
