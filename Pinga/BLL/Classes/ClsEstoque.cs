using System;

namespace BLL.Classes
{
    public sealed class ClsEstoque
    {
        public Guid idestoque { get; set; }
        public ClsProduto produtoIdproduto { get; set; }
        public int quantidade { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
    }
}
