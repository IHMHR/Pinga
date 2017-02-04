using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsEntrada : IGeneric
    {
        public Guid identrada { get; set; }
        public Nullable<DateTime> data { get; set; }
        public int litragem { get; set; }
        public ClsTipoLitragem tipoLitragemIdtipoLitragem { get; set; }
        public decimal valor { get; set; }
        public ClsCusto custoIdcusto { get; set; }
        public ClsParcelamento parcelamentoIdparcelamento { get; set; }
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
