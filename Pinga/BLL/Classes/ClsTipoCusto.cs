using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsTipoCusto : IGeneric<ClsTipoCusto>
    {
        public Guid idtipoCusto { get; set; }
        public string tipoCusto { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsTipoCusto> Visualizar()
        {
            return null;
        }
    }
}
