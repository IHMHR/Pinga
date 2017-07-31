using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsTipoTelefoneBO : IGeneric<ClsTipoTelefone>
    {
        private static ClsTipoTelefone tt = null;

        public ClsTipoTelefoneBO(ClsTipoTelefone tipoTelefoneClass)
        {
            tt = tipoTelefoneClass ?? new ClsTipoTelefone();
        }

        public ClsTipoTelefoneBO()
        {
            tt = new ClsTipoTelefone();
        }

        public void Inserir()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovoTipoTelefone";
                    com.Parameters.AddWithValue("@tipoTelefone", tt.tipoTelefone);

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
                    com.CommandText = "UPDATE Pinga.tipo_telefone SET tipo_telefone = @tipoTelefone WHERE idtipo_telefone = @id";
                    com.Parameters.AddWithValue("@id", tt.idtipoTelefone);
                    com.Parameters.AddWithValue("@tipoTelefone", tt.tipoTelefone);

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
                    com.CommandText = "DELETE FROM Pinga.tipo_telefone WHERE idtipo_telefone = @id";
                    com.Parameters.AddWithValue("@id", tt.idtipoTelefone);

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

        public List<ClsTipoTelefone> Visualizar()
        {
            List<ClsTipoTelefone> retorno = new List<ClsTipoTelefone>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtipo_telefone, tipo_telefone FROM Pinga.tipo_telefone";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsTipoTelefone tt = new ClsTipoTelefone();
                        tt.idtipoTelefone = Guid.Parse(read["idtipo_telefone"].ToString());
                        tt.tipoTelefone = read["tipo_telefone"].ToString();

                        retorno.Add(tt);
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
                if (string.IsNullOrEmpty(tt.tipoTelefone))
                {
                    throw new ArgumentNullException("Por favor informe o Tipo Telefone");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (tt.idtipoTelefone.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID Tipo Telefone");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsTipoTelefone BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtipo_telefone, tipo_telefone FROM Pinga.tipo_telefone WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    tt.idtipoTelefone = Guid.Parse(read["idtipo_telefone"].ToString());
                    tt.tipoTelefone = read["tipo_telefone"].ToString();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return tt;
        }
    }
}