using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsParceiro : IGeneric
    {
        public Guid idparceiro { get; set; }
        public string nome { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public bool status { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

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
