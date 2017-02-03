using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsContinente : IGeneric
    {
        public Guid idcontinente { get; set; }
        public string continente { get; set; }
        public ClsTipoContinente tipoContinenteIdtipoContinente { get; set; }

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
