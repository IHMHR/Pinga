using System;
using System.Data;

namespace BLL.Classes
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
