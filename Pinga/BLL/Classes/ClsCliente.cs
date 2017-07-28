using System;

namespace BLL.Classes
{
    public sealed class ClsCliente
    {
        public Guid idcliente { get; set; }
        public string cpfCnpj { get; set; }
        public string nomeRazaoSocial { get; set; }
        public string apelidoNomeFantasia { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string identidadeInscricaoEstadual { get; set; }
        public DateTime dataNascimentoFundacao { get; set; }
        public char sexo { get; set; }
        public ClsEmail emailIdemail { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }
        public DateTime created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsCliente()
        {
            emailIdemail = new ClsEmail();
            enderecoIdendereco = new ClsEndereco();
            telefoneIdtelefone = new ClsTelefone();
        }
    }
}
