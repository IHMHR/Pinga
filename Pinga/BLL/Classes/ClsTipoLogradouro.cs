using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsTipoLogradouro : IGeneric<ClsTipoLogradouro>
    {
        public Guid idtipoLogradouro { get; set; }
        public string tipoLogradouro { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsTipoLogradouro> Visualizar()
        {
            return null;
        }
    }
}
