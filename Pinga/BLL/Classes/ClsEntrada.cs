using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsEntrada
    {
        public Guid identrada { get; set; }
        public DateTime data { get; set; }
        public int litragem { get; set; }
        public ClsTipoLitragem tipoLitragemIdtipoLitragem { get; set; }
        public ClsCusto custoIdcusto { get; set; }
        public ClsParcelamento parcelamentoIdparcelamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsEntrada()
        {
            tipoLitragemIdtipoLitragem = new ClsTipoLitragem();
            custoIdcusto = new ClsCusto();
            parcelamentoIdparcelamento = new ClsParcelamento();
        }
    }
}
