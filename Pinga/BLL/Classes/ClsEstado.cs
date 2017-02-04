using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEstado : IGeneric<ClsEstado>
    {
        public Guid idestado { get; set; }
        public string estado { get; set; }
        public string uf { get; set; }
        public bool capital { get; set; }
        public ClsPais paisIdpais { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEstado> Visualizar()
        {
            return null;
        }
    }
}
