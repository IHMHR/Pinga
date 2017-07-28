using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsFase
    {
        public Guid idfase { get; set; }
        public string fase { get; set; }
        public DateTime created { get; set; }
        public Nullable<DateTime> modified { get; set; }
    }
}
