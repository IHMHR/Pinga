using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsTelefone : IGeneric<ClsTelefone>
    {
        public Guid idtelefone { get; set; }
        public string telefone { get; set; }
        public ClsCidade cidadeDDD { get; set; }
        public ClsTipoTelefone tipoTelefoneIdtipoTelefone { get; set; }
        public ClsOperadora operadoraIdoperadora { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsTelefone()
        {
            cidadeDDD = new ClsCidade();
            tipoTelefoneIdtipoTelefone = new ClsTipoTelefone();
            operadoraIdoperadora = new ClsOperadora();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsTelefone> Visualizar()
        {
            return null;
        }
    }
}
