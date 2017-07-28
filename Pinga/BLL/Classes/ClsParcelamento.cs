using System;

namespace BLL.Classes
{
    public sealed class ClsParcelamento
    {
        #region Atributos
        public Guid idparcelamento { get; set; }
        public Nullable<DateTime> dataPagamento { get; set; }
        public Nullable<DateTime> dataVencimento { get; set; }
        public int parcelas { get; set; }
        public decimal juros { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
        #endregion
    }
}
