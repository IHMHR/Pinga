﻿using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsCusto : IGeneric
    {
        public Guid idcusto { get; set; }
        public ClsTipoCusto tipoCustoIdtipoCusto { get; set; }
        public decimal valor { get; set; }
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
