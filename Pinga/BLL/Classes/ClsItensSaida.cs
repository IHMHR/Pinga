using System;
using System.Data;

namespace BLL.Classes
{
    class ClsItensSaida : IGeneric
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

        public DataTable Visualizar()
        {
            return null;
        }
    }
}
