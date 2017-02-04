using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsFormaPagamento : IGeneric<ClsFormaPagamento>
    {
        public Guid idformaPagamento { get; set; }
        public string formaPagamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsFormaPagamento> Visualizar()
        {
            return null;
        }
    }
}
