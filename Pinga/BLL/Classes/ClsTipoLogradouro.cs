using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsTipoLogradouro : IGeneric<ClsTipoLogradouro>
    {
        public Guid idtipoLogradouro { get; set; }
        public string tipoLogradouro { get; set; }

        public void Inserir()
        {
            if (string.IsNullOrEmpty(tipoLogradouro))
            {
                throw new ArgumentNullException("Por favor informe o Tipo Logradouro");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovoTipoLogradouro";
                    com.Parameters.AddWithValue("@tipoLogradouro", tipoLogradouro);

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
            if (idtipoLogradouro == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do Tipo Logradouro");
            }
            else if (string.IsNullOrEmpty(tipoLogradouro))
            {
                throw new ArgumentNullException("Por favor informe o Tipo Logradouro");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.tipo_logradouro SET tipo_logradouro = @tipoLogradouro WHERE idtipo_logradouro = @id";
                    com.Parameters.AddWithValue("@tipoLogradouro", tipoLogradouro);
                    com.Parameters.AddWithValue("@id", idtipoLogradouro);

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
            if (idtipoLogradouro == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do Tipo Logradouro");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.tipo_logradouro WHERE idtipo_logradouro = @id";
                    com.Parameters.AddWithValue("@id", idtipoLogradouro);

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

        public List<ClsTipoLogradouro> Visualizar()
        {
            List<ClsTipoLogradouro> retorno = new List<ClsTipoLogradouro>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtipo_logradouro, tipo_logradouro FROM Pinga.tipo_logradouro";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsTipoLogradouro tl = new ClsTipoLogradouro();
                        tl.idtipoLogradouro = Guid.Parse(read["idtipo_logradouro"].ToString());
                        tl.tipoLogradouro = read["tipo_logradouro"].ToString();

                        retorno.Add(tl);
                    }
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
