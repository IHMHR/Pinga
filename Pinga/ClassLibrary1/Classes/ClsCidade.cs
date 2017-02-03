using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsCidade : IGeneric
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

        public DataTable Visualizar()
        {
            return null;
        }
    }
}
