﻿using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsFase : IGeneric
    {
        public Guid idfase { get; set; }
        public string fase { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public DataTable Visualizar()
        {
            return null;
        }
    }
}
