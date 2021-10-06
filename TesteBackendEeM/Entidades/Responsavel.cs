using System;

namespace TesteBackendEeM.Entidades
{
    public class Responsavel : BaseEntity<int>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Parentesco Parentesco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
