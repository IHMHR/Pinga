using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsParcelamento : IGeneric<ClsParcelamento>
    {
        public Guid idparcelamento { get; set; }
        public Nullable<DateTime> dataPagamento { get; set; }
        public Nullable<DateTime> dataVencimento { get; set; }
        public int parcelas { get; set; }
        public decimal juros { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsParcelamento> Visualizar()
        {
            return null;
        }
    }
}
