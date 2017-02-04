using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsInformacoesCliente : IGeneric
    {
        public Guid idinformacoesCliente { get; set; }
        public ClsCliente clienteIdcliente { get; set; }
        public string tipoCliente { get; set; }
        public bool visitado { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

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
