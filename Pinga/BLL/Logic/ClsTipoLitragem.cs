using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsTipoLitragemBO : IGeneric<ClsTipoLitragem>
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
            ValidarClasse(CRUD.update);

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.tipo_litragem SET tipo_litragem = @tipoLitragem WHERE idtipo_litragem = @id";
                    com.Parameters.AddWithValue("@id", idtipoLitragem);
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

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(tipoLitragem))
                {
                    throw new ArgumentNullException("Por favor informe o Tipo Litragem");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idtipoLitragem.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do Tipo Litragem");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsTipoLitragem BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT idtipo_litragem, tipo_litragem FROM Pinga.tipo_litragem WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    idtipoLitragem = Guid.Parse(read["idtipo_litragem"].ToString());
                    tipoLitragem = read["tipo_litragem"].ToString();

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
