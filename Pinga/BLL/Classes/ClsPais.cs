using System;

namespace BLL.Classes
{
    public sealed class ClsPais
    {
        public Guid idpais { get; set; }
        public string pais { get; set; }
        public string idioma { get; set; }
        public string colacao { get; set; }
        public string DDI { get; set; }
        public string sigla { get; set; }
        public string fusoHorario { get; set; }
        public ClsContinente continenteIdcontinete { get; set; }

        public ClsPais()
        {
            continenteIdcontinete = new ClsContinente();
        }
    }
}
