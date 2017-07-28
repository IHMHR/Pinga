using System;

namespace BLL.Classes
{
    public sealed class ClsProdutoQuantidade
    {
        public Guid idprodutoQuantidade { get; set; }
        public int quantidadeMinima { get; set; }
        public int quantidadeMaxima { get; set; }
        public int quantidadeRecomendaEstoque { get; set; }
        public int quantidadeSolicitarCompra { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
    }
}
