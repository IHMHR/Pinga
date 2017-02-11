using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsItensSaida : IGeneric<ClsItensSaida>
    {
        public Guid iditensSaida { get; set; }
        public ClsSaida saidaIdsaida { get; set; }
        public ClsProduto produtoIdproduto { get; set; }
        public int quantidade { get; set; }
        public decimal valorSaida { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsItensSaida> Visualizar()
        {
            return null;
        }
    }
}
