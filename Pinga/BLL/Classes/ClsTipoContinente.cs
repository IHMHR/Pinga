using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsTipoContinente : IGeneric
    {
        #region Atributos
        public Guid idtipoContinente { get; set; }
        public string tipoContinente { get; set; }
        public bool ativo { get; set; }
        #endregion

        #region CRUD Functions
        public void Inserir()
        {
            if(string.IsNullOrEmpty(tipoContinente.Trim()))
            {
                throw new ArgumentNullException("Por favor informe o tipo de continente.");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovoTipoContinente";
                    com.Parameters.AddWithValue("@tipoContinente", tipoContinente);
                    com.Parameters.AddWithValue("@ativo", ativo);

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
            if (string.IsNullOrEmpty(idtipoContinente.ToString()))
            {
                throw new ArgumentNullException("Por favor informe o ID do tipo de continente.");
            }
            else if (string.IsNullOrEmpty(tipoContinente.Trim()))
            {
                throw new ArgumentNullException("Por favor informe o tipo de continente.");
            }
            else if(ativo != false && ativo != true)
            {
                throw new ArgumentNullException("Por favor informe se o tipo de continente está ativo.");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.tipo_continente SET tipo_continente = @tipoContinente, ativo = @ativo WHERE idtipo_continente = @id";
                    com.Parameters.AddWithValue("@id", idtipoContinente);
                    com.Parameters.AddWithValue("@tipoContinente", tipoContinente);
                    com.Parameters.AddWithValue("@ativo", ativo);

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
            if (string.IsNullOrEmpty(idtipoContinente.ToString()))
            {
                throw new ArgumentNullException("Por favor informe o ID do tipo de continente.");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.tipo_continente WHERE idtipo_continente = @id";
                    com.Parameters.AddWithValue("@id", idtipoContinente);

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

        public DataTable Visualizar()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtipo_continente AS idtipoContinente, tipo_continente AS tipoContinente, ativo "
                                    + "FROM Pinga.tipo_continente ORDER BY tipo_continente ASC, ativo DESC;";
                    con.Open();
                    com.Connection = con;
                    DataTable retorno = new DataTable();
                    retorno.Load(com.ExecuteReader());
                    return retorno;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
