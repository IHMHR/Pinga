using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsTipoLitragem : IGeneric
    {
        public Guid idtipoLitragem { get; set; }
        public string tipoLitragem { get; set; }

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
