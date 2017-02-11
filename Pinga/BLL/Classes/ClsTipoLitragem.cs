using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsTipoLitragem : IGeneric<ClsTipoLitragem>
    {
        public Guid idtipoLitragem { get; set; }
        public string tipoLitragem { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsTipoLitragem> Visualizar()
        {
            return null;
        }
    }
}
