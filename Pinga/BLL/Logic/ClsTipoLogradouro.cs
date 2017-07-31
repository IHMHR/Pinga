using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsTipoLogradouroBO : IGeneric<ClsTipoLogradouro>
    {
        #region CRUD Functions
        public void Inserir()
        {
            ValidarClasse(CRUD.insert);

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
            ValidarClasse(CRUD.update);

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
            ValidarClasse(CRUD.delete);

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

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(tipoLogradouro))
                {
                    throw new ArgumentNullException("Por favor informe o Tipo Logradouro");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idtipoLogradouro.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do Tipo Logradouro");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsTipoLogradouro BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtipo_logradouro, tipo_logradouro FROM Pinga.tipo_logradouro WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    idtipoLogradouro = Guid.Parse(read["idtipo_logradouro"].ToString());
                    tipoLogradouro = read["tipo_logradouro"].ToString();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }
        #endregion
    }
}
