using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsContinente
    {
        public Guid idcontinente { get; set; }
        public string continente { get; set; }
        public ClsTipoContinente tipoContinenteIdtipoContinente { get; set; }

        public ClsContinente()
        {
            tipoContinenteIdtipoContinente = new ClsTipoContinente();
        }
    }
}
