using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsTipoComplemento : IGeneric<ClsTipoComplemento>
    {
        #region Atributos
        public Guid idtipoComplemento { get; set; }
        public string tipoComplemento { get; set; }
        #endregion

        #region CRUD Functions
        public void Inserir()
        {
            if (string.IsNullOrEmpty(tipoComplemento))
            {
                throw new ArgumentNullException("Por favor informe o Tipo Complemento");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovoTipoComplemento";
                    com.Parameters.AddWithValue("@tipoComplemento", tipoComplemento);

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
            if (idtipoComplemento.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                throw new ArgumentNullException("Por favor informe o ID do Tipo Complemento");
            }
            else if (string.IsNullOrEmpty(tipoComplemento))
            {
                throw new ArgumentNullException("Por favor informe o Tipo Complemento");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.tipo_complemento SET tipo_complemento = @tipoComplemento WHERE idtipo_complemento = @id";
                    com.Parameters.AddWithValue("@tipoComplemento", tipoComplemento);
                    com.Parameters.AddWithValue("@id", idtipoComplemento);

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
            if (idtipoComplemento == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do Tipo Complemento");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.tipo_complemento WHERE idtipo_complemento = @id";
                    com.Parameters.AddWithValue("@id", idtipoComplemento);

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

        public List<ClsTipoComplemento> Visualizar()
        {
            List<ClsTipoComplemento> retorno = new List<ClsTipoComplemento>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtipo_complemento, tipo_complemento FROM Pinga.tipo_complemento";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsTipoComplemento tc = new ClsTipoComplemento();
                        tc.idtipoComplemento = Guid.Parse(read["idtipo_complemento"].ToString());
                        tc.tipoComplemento = read["tipo_complemento"].ToString();

                        retorno.Add(tc);
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
            }
            else if (crud == CRUD.update)
            {

            }
            else if (crud == CRUD.delete)
            {

            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }
        #endregion
    }
}
