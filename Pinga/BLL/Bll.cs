using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bll
    {
        public Classes.ClsLogin login = null;
        public Classes.ClsTipoContinente tipoContinente = null;
        public Classes.ClsContinente continente = null;
        public Classes.ClsPais pais = null;
        public Classes.ClsEstado estado = null;
        public Classes.ClsCidade cidade = null;
        public Classes.ClsBairro bairro = null;

        public Bll(string classe)
        {
            if(!string.IsNullOrEmpty(classe))
            {
                switch (classe)
                {
                    case "Login":
                        login = new Classes.ClsLogin();
                        break;

                    case "Tipo Continente":
                        tipoContinente = new Classes.ClsTipoContinente();
                        break;

                    case "Continente":
                        continente = new Classes.ClsContinente();
                        break;

                    case "Pais":
                        pais = new Classes.ClsPais();
                        break;

                    case "Estado":
                        estado = new Classes.ClsEstado();
                        break;

                    case "Cidade":
                        cidade = new Classes.ClsCidade();
                        break;

                    case "Bairro":
                        bairro = new Classes.ClsBairro();
                        break;
                }
            }
        }
    }
}
