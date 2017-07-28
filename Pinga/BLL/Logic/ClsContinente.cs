using BLL.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Logic.Classes
{
    public sealed class ClsContinenteBO : IGeneric<ClsContinente>
    {
        private static ClsContinente c = null;

        public ClsContinenteBO()
        {
            c = new ClsContinente();
        }

        public ClsContinenteBO(ClsContinente continenteClass)
        {
            c = continenteClass ?? new ClsContinente();
        }

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
                    com.CommandText = "Pinga.usp_InserirNovoContinente";
                    com.Parameters.AddWithValue("@continente", c.continente);
                    com.Parameters.AddWithValue("@tipoContienteidtipoContinente", c.tipoContinenteIdtipoContinente.idtipoContinente);

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

            using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "UPDATE Pinga.continente SET continente = @continente, tipo_continente_idtipo_continente = @idtipoContinente WHERE idcontinente = @id";
                com.Parameters.AddWithValue("@id", c.idcontinente);
                com.Parameters.AddWithValue("@continente", c.continente);
                com.Parameters.AddWithValue("@idtipoContinente", c.tipoContinenteIdtipoContinente.idtipoContinente);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Apagar()
        {
            ValidarClasse(CRUD.delete);

            using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "DELETE FROM Pinga.continente WHERE idcontinente = @id";
                com.Parameters.AddWithValue("@id", c.idcontinente);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<ClsContinente> Visualizar()
        {
            List<ClsContinente> retorno = new List<ClsContinente>();
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT c.idcontinente, c.continente, tc.idtipo_continente, tc.tipo_continente, tc.ativo "
                                    + "FROM Pinga.continente c INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente "
                                    + "ORDER BY c.continente ASC, tc.ativo DESC;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsContinente cont = new ClsContinente();
                        cont.idcontinente = Guid.Parse(read["idcontinente"].ToString());
                        cont.continente = read["continente"].ToString();
                        cont.tipoContinenteIdtipoContinente.idtipoContinente = Guid.Parse(read["idtipo_continente"].ToString());
                        cont.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
                        cont.tipoContinenteIdtipoContinente.ativo = (bool)read["ativo"];

                        retorno.Add(cont);
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
                if (string.IsNullOrEmpty(c.continente.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o continente.");
                }
                else if (c.tipoContinenteIdtipoContinente.idtipoContinente.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o tipo de continente.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (c.idcontinente.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do continente.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsContinente BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT c.idcontinente, c.continente, tc.idtipo_continente, tc.tipo_continente, tc.ativo "
                                    + "FROM Pinga.continente c INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente WHERE ROWGUIDCOL = @id"
                                    + "ORDER BY c.continente ASC, tc.ativo DESC;";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    c.idcontinente = Guid.Parse(read["idcontinente"].ToString());
                    c.continente = read["continente"].ToString();
                    c.tipoContinenteIdtipoContinente.idtipoContinente = Guid.Parse(read["idtipo_continente"].ToString());
                    c.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
                    c.tipoContinenteIdtipoContinente.ativo = (bool)read["ativo"];
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return c;
        }
    }
}
