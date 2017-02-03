using System;
using System.Data;

namespace ClassLibrary1.Classes
{
    class ClsEndereco : IGeneric
    {
        public Guid idendereco { get; set; }
        public ClsTipoLogradouro tipoLogradouroIdtipoLogradouro { get; set; }
        public string logradouro { get; set; }
        public Nullable<int> numero { get; set; }
        public ClsTipoComplemento tipoComplementoIdtipoComplemento { get; set; }
        public string complemento { get; set; }
        public string CEP { get; set; }
        public string pontoReferencia { get; set; }
        public ClsBairro bairroIdbairro { get; set; }
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
