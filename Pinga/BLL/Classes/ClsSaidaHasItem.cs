using System;

namespace BLL.Classes
{
    public sealed class ClsSaidaHasItem
    {
        #region Atributos
        public Guid idsaida_has_item { get; set; }
        public ClsSaida saida_idsaida { get; set; }
        public ClsItem item_iditem { get; set; }
        #endregion

        public ClsSaidaHasItem()
        {
            saida_idsaida = new ClsSaida();
            item_iditem = new ClsItem();
        }
    }
}
