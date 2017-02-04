using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsCidade : IGeneric<ClsCidade>
    {
        public Guid idcidade { get; set; }
        public string cidade { get; set; }
        public string DDD { get; set; }
        public bool capital { get; set; }
        public ClsEstado estadoIdestado { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsCidade> Visualizar()
        {
            return null;
        }
    }
}
