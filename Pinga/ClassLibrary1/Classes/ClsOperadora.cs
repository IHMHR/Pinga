using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsOperadora : IGeneric
    {
        public Guid idoperadora { get; set; }
        public string operadora { get; set; }
        public string razaoSocial { get; set; }
        public bool status { get; set; }

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
