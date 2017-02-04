using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsTipoContinente : IGeneric
    {
        public Guid idtipoContinente { get; set; }
        public string tipoContinente { get; set; }
        public bool MyProperty { get; set; }

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
