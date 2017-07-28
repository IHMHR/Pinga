using System;

namespace BLL.Classes
{
    public sealed class ClsEndereco
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

        public ClsEndereco()
        {
            tipoLogradouroIdtipoLogradouro = new ClsTipoLogradouro();
            tipoComplementoIdtipoComplemento = new ClsTipoComplemento();
            bairroIdbairro = new ClsBairro();
        }
    }
}
