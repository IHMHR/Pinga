using System;

namespace BLL.Classes
{
    public sealed class ClsItem
    {
        public Guid iditem { get; set; }
        public string item { get; set; }
        public ClsProduto produtoIdproduto { get; set; }
        public DateTime created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsItem()
        {
            produtoIdproduto = new ClsProduto();
        }
    }
}
