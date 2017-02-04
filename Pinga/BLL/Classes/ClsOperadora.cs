using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsOperadora : IGeneric<ClsOperadora>
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

        public List<ClsOperadora> Visualizar()
        {
            return null;
        }
    }
}
