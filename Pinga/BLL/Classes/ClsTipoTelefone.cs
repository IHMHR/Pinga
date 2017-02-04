using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsTipoTelefone : IGeneric
    {
        public Guid idtipoTelefone { get; set; }
        public string tipoTelefone { get; set; }

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
