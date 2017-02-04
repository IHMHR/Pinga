using System;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsBairro : IGeneric
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

        public DataTable Visualizar()
        {
            return null;
        }
    }
}
