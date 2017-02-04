using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEmailDominio : IGeneric<ClsEmailDominio>
    {
        public Guid idemailDominio { get; set; }
        public string emailDominio { get; set; }
        public bool status { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEmailDominio> Visualizar()
        {
            return null;
        }
    }
}
