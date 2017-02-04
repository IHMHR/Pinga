using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsEmail : IGeneric
    {
        public Guid idemail { get; set; }
        public string email { get; set; }
        public ClsEmailDominio emailDominioIdemailDominio { get; set; }
        public ClsEmailLocalidade emailLocalidadeIdemailLocalidade { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public DataTable Visualizar()
        {
            return null;
        }
    }
}
