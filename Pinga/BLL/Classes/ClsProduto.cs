using System;
using System.Data;

namespace BLL.Classes
{
    class ClsProduto : IGeneric
    {
        public Guid idproduto { get; set; }
        public string produto { get; set; }
        public ClsTipoLitragem tipoLitragemIdtipoLitragem { get; set; }
        public Nullable<int> litragem { get; set; }
        public bool vendendo { get; set; }
        public decimal valorUnitario { get; set; }
        public ClsProdutoQuantidade produtoQuantidadeIdprodutoQuantidade { get; set; }
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
