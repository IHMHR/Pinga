using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsTelefone : IGeneric
    {
        public Guid idtelefone { get; set; }
        public string telefone { get; set; }
        public ClsCidade cidadeDDD { get; set; }
        public ClsTipoTelefone tipoTelefoneIdtipoTelefone { get; set; }
        public ClsOperadora operadoraIdoperadora { get; set; }
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
