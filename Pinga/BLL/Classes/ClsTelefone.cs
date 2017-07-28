﻿using System;

namespace BLL.Classes
{
    public sealed class ClsTelefone
    {
        #region Atributos
        public Guid idtelefone { get; set; }
        public string telefone { get; set; }
        public ClsCidade cidadeDDD { get; set; }
        public ClsTipoTelefone tipoTelefoneIdtipoTelefone { get; set; }
        public ClsOperadora operadoraIdoperadora { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
        #endregion

        public ClsTelefone()
        {
            cidadeDDD = new ClsCidade();
            tipoTelefoneIdtipoTelefone = new ClsTipoTelefone();
            operadoraIdoperadora = new ClsOperadora();
        }
    }
}
