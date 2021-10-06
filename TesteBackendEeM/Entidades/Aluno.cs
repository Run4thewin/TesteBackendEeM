using System;
using System.Collections.Generic;

namespace TesteBackendEeM.Entidades
{
    public class Aluno : BaseEntity<int>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Segmento Segmento { get; set; }
        public string FotoPerfilURL { get; set; }
        public string Email { get; set; }
        public ICollection<Responsavel> Responsaveis { get; set; }
    }
}
