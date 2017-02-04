using System;
using System.Data;

namespace BLL.Classes
{
    class ClsTipoComplemento : IGeneric
    {
        public Guid idtipoComplemento { get; set; }
        public string tipoComplemento { get; set; }

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
