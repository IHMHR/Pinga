using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsTipoTelefone : IGeneric<ClsTipoTelefone>
    {
        public Guid idtipoTelefone { get; set; }
        public string tipoTelefone { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsTipoTelefone> Visualizar()
        {
            return null;
        }
    }
}
