using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsParcelamento : IGeneric
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

        public DataTable Visualizar()
        {
            return null;
        }
    }
}
