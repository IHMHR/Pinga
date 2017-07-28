using System;

namespace BLL.Classes
{
    public sealed class ClsEntradaHasItem
    {
        #region Atributos
        public Guid identrada_has_item { get; set; }
        public ClsEntrada entrada_identrada { get; set; }
        public ClsItem item_iditem { get; set; }
        #endregion

        public ClsEntradaHasItem()
        {
            entrada_identrada = new ClsEntrada();
            item_iditem = new ClsItem();
        }
    }
}
