using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsBairro : IGeneric<ClsBairro>
    {
        public Guid idbairro { get; set; }
        public string bairro { get; set; }
        public string regiao { get; set; }
        public ClsCidade cidadeIdcidade { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsBairro> Visualizar()
        {
            return null;
        }
    }
}
