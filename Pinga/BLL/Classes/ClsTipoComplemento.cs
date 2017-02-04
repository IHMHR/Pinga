using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsTipoComplemento : IGeneric<ClsTipoComplemento>
    {
        public Guid idtipoComplemento { get; set; }
        public string tipoComplemento { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsTipoComplemento> Visualizar()
        {
            return null;
        }
    }
}
