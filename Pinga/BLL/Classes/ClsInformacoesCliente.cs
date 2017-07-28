using System;

namespace BLL.Classes
{
    public sealed class ClsInformacoesCliente
    {
        public Guid idinformacoesCliente { get; set; }
        public ClsCliente clienteIdcliente { get; set; }
        public string tipoCliente { get; set; }
        public bool visitado { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
    }
}
