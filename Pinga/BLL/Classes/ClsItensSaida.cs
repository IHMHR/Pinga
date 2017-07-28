using System;

namespace BLL.Classes
{
    public sealed class ClsItensSaida
    {
        public Guid iditensSaida { get; set; }
        public ClsSaida saidaIdsaida { get; set; }
        public ClsProduto produtoIdproduto { get; set; }
        public int quantidade { get; set; }
        public decimal valorSaida { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsItensSaida()
        {
            saidaIdsaida = new ClsSaida();
            produtoIdproduto = new ClsProduto();
        }
    }
}
