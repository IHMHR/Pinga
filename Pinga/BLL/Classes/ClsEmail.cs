using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEmail
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
    }
}
