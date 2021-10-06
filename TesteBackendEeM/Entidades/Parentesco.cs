using System.ComponentModel;

namespace TesteBackendEeM.Entidades
{
    public enum Parentesco
    {
        [Description("Mãe")]
        Mae = 1,        
        [Description("Pai")]
        Pai = 2,        
        [Description("Tio")]
        Tio = 3,        
        [Description("Avó")]
        Avo = 4
    }
}