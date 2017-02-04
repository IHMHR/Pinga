using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsFornecedor : IGeneric<ClsFornecedor>
    {
        public Guid idfornecedor { get; set; }
        public string nome { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsFornecedor> Visualizar()
        {
            return null;
        }
    }
}
