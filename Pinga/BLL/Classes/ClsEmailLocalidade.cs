using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsEmailLocalidade : IGeneric
    {
        public Guid idemailLocalidade { get; set; }
        public string emailLocalidade { get; set; }
        public bool status { get; set; }

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
