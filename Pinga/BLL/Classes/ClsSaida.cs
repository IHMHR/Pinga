using System;

namespace BLL.Classes
{
    public sealed class ClsSaida
    {
        #region Atributos
        public Guid idsaida { get; set; }
        public DateTime data { get; set; }
        public ClsParceiro parceiroIdparceiro { get; set; }
        public ClsCliente clienteIdcliente { get; set; }
        public ClsFase faseIdfase { get; set; }
        public ClsFormaPagamento formaPagamentoIdformaPagamento { get; set; }
        public ClsParcelamento parcelamentoIdparcelamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
        #endregion

        public ClsSaida()
        {
            parceiroIdparceiro = new ClsParceiro();
            clienteIdcliente = new ClsCliente();
            faseIdfase = new ClsFase();
            formaPagamentoIdformaPagamento = new ClsFormaPagamento();
            parcelamentoIdparcelamento = new ClsParcelamento();
        }
    }
}
