using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsFase : IGeneric<ClsFase>
    {
        public Guid idfase { get; set; }
        public string fase { get; set; }
        public DateTime created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        {
            ValidarClasse(CRUD.insert);
        }

        public void Alterar()
        {
            ValidarClasse(CRUD.update);
        }

        public void Apagar()
        {
            ValidarClasse(CRUD.delete);
        }

        public List<ClsFase> Visualizar()
        {
            List<ClsFase> retorno = new List<ClsFase>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idfase, fase, created, modified FROM Pinga.fase";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsFase f = new ClsFase();
                        f.idfase = Guid.Parse(read["idfase"].ToString());
                        f.fase = read["fase"].ToString();
                        f.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            f.modified = DateTime.Parse(read["modified"].ToString());
                        }

                        retorno.Add(f);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return retorno;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(fase))
                {
                    throw new ArgumentNullException("Por favor informe a Fase");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idfase.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID da Fase");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }
    }
}
