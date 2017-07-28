using System;

namespace BLL.Classes
{
    public sealed class ClsFornecedor
    {
        public Guid idfornecedor { get; set; }
        public string nome { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }
    }
}
