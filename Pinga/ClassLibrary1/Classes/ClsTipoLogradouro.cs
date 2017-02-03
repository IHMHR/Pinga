using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsTipoLogradouro : IGeneric
    {
        public Guid idtipoLogradouro { get; set; }
        public string tipoLogradouro { get; set; }

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
