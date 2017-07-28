using System;

namespace BLL.Classes
{
    public sealed class ClsEstado
    {
        public Guid idestado { get; set; }
        public string estado { get; set; }
        public string uf { get; set; }
        public bool capital { get; set; }
        public ClsPais paisIdpais { get; set; }

        public ClsEstado()
        {
            paisIdpais = new ClsPais();
        }
    }
}
