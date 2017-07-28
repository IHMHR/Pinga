using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsFormaPagamento
    {
        public Guid idformaPagamento { get; set; }
        public string formaPagamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
    }
}
