using System;

namespace BLL.Classes
{
    public sealed class ClsCusto
    {
        public Guid idcusto { get; set; }
        public ClsTipoCusto tipoCustoIdtipoCusto { get; set; }
        public decimal valor { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsCusto()
        {
            tipoCustoIdtipoCusto = new ClsTipoCusto();
        }
    }
}
