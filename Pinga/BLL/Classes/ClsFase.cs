using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsFase : IGeneric<ClsFase>
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

        public List<ClsFase> Visualizar()
        {
            return null;
        }
    }
}
