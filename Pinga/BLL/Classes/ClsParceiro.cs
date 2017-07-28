using System;

namespace BLL.Classes
{
    public sealed class ClsParceiro
    {
        public Guid idparceiro { get; set; }
        public string nome { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public bool status { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }
        public DateTime created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsParceiro()
        {
            enderecoIdendereco = new ClsEndereco();
            telefoneIdtelefone = new ClsTelefone();
        }
    }
}
