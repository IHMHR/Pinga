using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsCliente : IGeneric<ClsCliente>
    {
        public Guid idcliente { get; set; }
        public string cpfCnpj { get; set; }
        public string nomeRazaoSocial { get; set; }
        public string apelidoNomeFantasia { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string identidadeInscricaoEstadual { get; set; }
        public Nullable<DateTime> dataNascimentoFundacao { get; set; }
        public char sexo { get; set; }
        public ClsEmail emailIdemail { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsCliente> Visualizar()
        {
            return null;
        }
    }
}
