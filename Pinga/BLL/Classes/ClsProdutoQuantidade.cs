using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsProdutoQuantidade : IGeneric<ClsProdutoQuantidade>
    {
        public Guid idprodutoQuantidade { get; set; }
        public int quantidadeMinima { get; set; }
        public int quantidadeMaxima { get; set; }
        public int quantidadeRecomendaEstoque { get; set; }
        public int quantidadeSolicitarCompra { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsProdutoQuantidade> Visualizar()
        {
            return null;
        }
    }
}
