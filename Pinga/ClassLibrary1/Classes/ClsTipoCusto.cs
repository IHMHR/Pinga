using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsTipoCusto : IGeneric
    {
        public Guid idtipoCusto { get; set; }
        public string tipoCusto { get; set; }

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
