using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsCidadeBO : IGeneric<ClsCidade>
    {
        private static ClsCidade c = null;

        public ClsCidadeBO()
        {
            c = new ClsCidade();
        }

        public ClsCidadeBO(ClsCidade cidadeClass)
        {
            c = cidadeClass ?? new ClsCidade();
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
                    com.CommandText = "Pinga.usp_InserirNovaCidade";
                    com.Parameters.AddWithValue("@cidade", c.cidade);
                    com.Parameters.AddWithValue("@DDD", c.DDD);
                    com.Parameters.AddWithValue("@capital", c.capital);
                    com.Parameters.AddWithValue("@estadoIdestado", c.estadoIdestado.idestado);

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
                    com.CommandText = "UPDATE Pinga.cidade SET cidade = @cidade, DDD = @DDD, capital = @capital, estado_idestado = @estadoIdestado WHERE idcidade = @id";
                    com.Parameters.AddWithValue("@cidade", c.cidade);
                    com.Parameters.AddWithValue("@DDD", c.DDD);
                    com.Parameters.AddWithValue("@capital", c.capital);
                    com.Parameters.AddWithValue("@estadoIdestado", c.estadoIdestado.idestado);
                    com.Parameters.AddWithValue("@id", c.idcidade);

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
                    com.CommandText = "DELETE FROM Pinga.cidade WHERE idcidade = @id";
                    com.Parameters.AddWithValue("@id", c.idcidade);

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

        public List<ClsCidade> Visualizar()
        {
            List<ClsCidade> retorno = new List<ClsCidade>();
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT ci.idcidade, ci.cidade, ci.DDD, ci.capital, e.idestado, e.estado, e.uf, e.capital AS capitalEstado, p.idpais, p.pais, p.idioma, p.DDI, p.sigla, p.fuso_horario, c.continente, tc.tipo_continente FROM Pinga.cidade ci INNER JOIN Pinga.estado e ON ci.estado_idestado = e.idestado INNER JOIN Pinga.pais p ON e.pais_idpais = p.idpais INNER JOIN Pinga.continente c ON p.continente_idcontinente = c.idcontinente INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsCidade ci = new ClsCidade();
                        ci.idcidade = Guid.Parse(read["idcidade"].ToString());
                        ci.cidade = read["cidade"].ToString();
                        ci.DDD = read["DDD"].ToString();
                        ci.capital = (bool)read["capital"];
                        ci.estadoIdestado.idestado = Guid.Parse(read["idestado"].ToString());
                        ci.estadoIdestado.estado = read["estado"].ToString();
                        ci.estadoIdestado.uf = read["uf"].ToString();
                        ci.estadoIdestado.capital = (bool)read["capitalEstado"];
                        ci.estadoIdestado.paisIdpais.idpais = Guid.Parse(read["idpais"].ToString());
                        ci.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                        ci.estadoIdestado.paisIdpais.idioma = read["idioma"].ToString();
                        ci.estadoIdestado.paisIdpais.DDI = read["DDI"].ToString();
                        ci.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                        ci.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                        ci.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                        ci.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();

                        retorno.Add(ci);
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
                if (string.IsNullOrEmpty(c.cidade))
                {
                    throw new ArgumentNullException("Por favor informe a cidade");
                }
                else if (string.IsNullOrEmpty(c.DDD))
                {
                    throw new ArgumentNullException("Por favor informe o DDD");
                }
                else if (c.capital != true && c.capital != false)
                {
                    throw new ArgumentNullException("Por favor informe se é capital");
                }
                else if (c.estadoIdestado.idestado.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o estado");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (c.idcidade.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do bairro");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsCidade BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT ci.idcidade, ci.cidade, ci.DDD, ci.capital, e.idestado, e.estado, e.uf, e.capital AS capitalEstado, p.idpais, p.pais, p.idioma, p.DDI, p.sigla, p.fuso_horario, c.continente, tc.tipo_continente FROM Pinga.cidade ci INNER JOIN Pinga.estado e ON ci.estado_idestado = e.idestado INNER JOIN Pinga.pais p ON e.pais_idpais = p.idpais INNER JOIN Pinga.continente c ON p.continente_idcontinente = c.idcontinente INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    c.idcidade = Guid.Parse(read["idcidade"].ToString());
                    c.cidade = read["cidade"].ToString();
                    c.DDD = read["DDD"].ToString();
                    c.capital = (bool)read["capital"];
                    c.estadoIdestado.idestado = Guid.Parse(read["idestado"].ToString());
                    c.estadoIdestado.estado = read["estado"].ToString();
                    c.estadoIdestado.uf = read["uf"].ToString();
                    c.estadoIdestado.capital = (bool)read["capitalEstado"];
                    c.estadoIdestado.paisIdpais.idpais = Guid.Parse(read["idpais"].ToString());
                    c.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                    c.estadoIdestado.paisIdpais.idioma = read["idioma"].ToString();
                    c.estadoIdestado.paisIdpais.DDI = read["DDI"].ToString();
                    c.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                    c.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                    c.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                    c.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
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
