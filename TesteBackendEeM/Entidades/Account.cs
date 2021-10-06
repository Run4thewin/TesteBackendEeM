using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendEeM.Entidades
{
    public class Account
    {
        public string Matricula { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<string> Permissions { get; set; }
    }
}
