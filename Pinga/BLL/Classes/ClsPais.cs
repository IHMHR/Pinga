using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsPais : IGeneric<ClsPais>
    {
        public Guid idpais { get; set; }
        public string pais { get; set; }
        public string idioma { get; set; }
        public string colacao { get; set; }
        public string DDI { get; set; }
        public string sigla { get; set; }
        public string fusoHorario { get; set; }
        public ClsContinente continenteIdcontinete { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsPais> Visualizar()
        {
            return null;
        }
    }
}
