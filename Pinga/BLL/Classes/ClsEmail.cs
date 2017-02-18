using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEmail : IGeneric<ClsEmail>
    {
        public Guid idemail { get; set; }
        public string email { get; set; }
        public ClsEmailDominio emailDominioIdemailDominio { get; set; }
        public ClsEmailLocalidade emailLocalidadeIdemailLocalidade { get; set; }

        public ClsEmail()
        {
            emailDominioIdemailDominio = new ClsEmailDominio();
            emailLocalidadeIdemailLocalidade = new ClsEmailLocalidade();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEmail> Visualizar()
        {
            return null;
        }
    }
}
