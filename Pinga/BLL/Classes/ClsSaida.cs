using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsSaida : IGeneric
    {
        public Guid idsaida { get; set; }
        public Nullable<DateTime> data { get; set; }
        public ClsParceiro parceiroIdparceiro { get; set; }
        public ClsCliente clienteIdcliente { get; set; }
        public ClsFase faseIdfase { get; set; }
        public ClsFormaPagamento formaPagamentoIdformaPagamento { get; set; }
        public ClsParceiro parcelamentoIdparcelamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

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
