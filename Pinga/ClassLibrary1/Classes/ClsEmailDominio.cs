using System;

namespace ClassLibrary1.Classes
{
    class ClsEmailDominio : IGeneric
    {
        public Guid idemailDominio { get; set; }
        public string emailDominio { get; set; }
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
