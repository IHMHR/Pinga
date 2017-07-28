using System;

namespace BLL.Classes
{
    public sealed class ClsProduto
    {
        #region Atributos
        public Guid idproduto { get; set; }
        public string produto { get; set; }
        public ClsTipoLitragem tipoLitragemIdtipoLitragem { get; set; }
        public Nullable<int> litragem { get; set; }
        public bool vendendo { get; set; }
        public decimal valorUnitario { get; set; }
        public ClsProdutoQuantidade produtoQuantidadeIdprodutoQuantidade { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
        #endregion

        public ClsProduto()
        {
            tipoLitragemIdtipoLitragem = new ClsTipoLitragem();
            produtoQuantidadeIdprodutoQuantidade = new ClsProdutoQuantidade();
        }
    }
}
