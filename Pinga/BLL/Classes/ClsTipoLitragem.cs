using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsTipoLitragem : IGeneric<ClsTipoLitragem>
    {
        public Guid idtipoLitragem { get; set; }
        public string tipoLitragem { get; set; }

        public void Inserir()
        {
            if(string.IsNullOrEmpty(tipoLitragem))
            {
                throw new ArgumentNullException("Por favor informe o Tipo Litragem");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovoTipoLitragem";
                    com.Parameters.AddWithValue("@tipoLitragem", tipoLitragem);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Alterar()
        {
            if(idtipoLitragem == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do Tipo Litragem");
            }
            else if (string.IsNullOrEmpty(tipoLitragem))
            {
                throw new ArgumentNullException("Por favor informe o Tipo Litragem");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.tipo_litragem SET tipo_litragem = @tipoLitragem WHERE idtipo_litragem = @id";
                    com.Parameters.AddWithValue("@id", idtipoLitragem);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Apagar()
        {
            if (idtipoLitragem == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do Tipo Litragem");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.tipo_litragem WHERE idtipo_litragem = @id";
                    com.Parameters.AddWithValue("@id", idtipoLitragem);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ClsTipoLitragem> Visualizar()
        {
            List<ClsTipoLitragem> retorno = new List<ClsTipoLitragem>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT idtipo_litragem, tipo_litragem FROM Pinga.tipo_litragem";

                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsTipoLitragem tl = new ClsTipoLitragem();
                        tl.idtipoLitragem = Guid.Parse(read["idtipo_litragem"].ToString());
                        tl.tipoLitragem = read["tipo_litragem"].ToString();

                        retorno.Add(tl);
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return retorno;
        }
    }
}
