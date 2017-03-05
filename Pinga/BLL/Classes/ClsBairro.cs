using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsBairro : IGeneric<ClsBairro>
    {
        public Guid idbairro { get; set; }
        public string bairro { get; set; }
        public string regiao { get; set; }
        public ClsCidade cidadeIdcidade { get; set; }

        public ClsBairro()
        {
            cidadeIdcidade = new ClsCidade();
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
                    com.CommandText = "Pinga.usp_InserirNovoBairro";
                    com.Parameters.AddWithValue("@bairro", bairro);
                    com.Parameters.AddWithValue("@regiao", regiao);
                    com.Parameters.AddWithValue("@cidadeIdcidade", cidadeIdcidade.idcidade);

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
                    com.CommandText = "UPDATE Pinga.bairro SET bairro = @bairro, regiao = @regiao, cidade_idcidade = @cidadeIdcidade WHERE idbairro = @id";
                    com.Parameters.AddWithValue("@bairro", bairro);
                    com.Parameters.AddWithValue("@regiao", regiao);
                    com.Parameters.AddWithValue("@cidadeIdcidade", cidadeIdcidade.idcidade);
                    com.Parameters.AddWithValue("@id", idbairro);

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
                    com.CommandText = "DELETE FROM Pinga.bairro WHERE idbairro = @id";
                    com.Parameters.AddWithValue("@id", idbairro);

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

        public List<ClsBairro> Visualizar()
        {
            List<ClsBairro> retorno = new List<ClsBairro>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT b.idbairro, b.bairro, b.regiao, ci.idcidade, ci.cidade, ci.DDD, ci.capital, e.idestado, e.estado, e.uf, e.capital AS capitalEstado, p.idpais, p.pais, p.idioma, p.DDI, p.sigla, p.fuso_horario, c.continente, tc.tipo_continente FROM Pinga.bairro b INNER JOIN Pinga.cidade ci ON b.cidade_idcidade = ci.idcidade INNER JOIN Pinga.estado e ON ci.estado_idestado = e.idestado INNER JOIN Pinga.pais p ON e.pais_idpais = p.idpais INNER JOIN Pinga.continente c ON p.continente_idcontinente = c.idcontinente INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsBairro bairro = new ClsBairro();
                        bairro.idbairro = Guid.Parse(read["idbairro"].ToString());
                        bairro.bairro = read["bairro"].ToString();
                        bairro.regiao = read["regiao"].ToString();
                        bairro.cidadeIdcidade.idcidade = Guid.Parse(read["idcidade"].ToString());
                        bairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                        bairro.cidadeIdcidade.DDD = read["DDD"].ToString();
                        bairro.cidadeIdcidade.capital = (bool)read["capital"];
                        bairro.cidadeIdcidade.estadoIdestado.idestado = Guid.Parse(read["idestado"].ToString());
                        bairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.capital = (bool)read["capitalEstado"];
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.idpais = Guid.Parse(read["idpais"].ToString());
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.idioma = read["idioma"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.DDI = read["DDI"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                        bairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();

                        retorno.Add(bairro);
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
                if (string.IsNullOrEmpty(bairro))
                {
                    throw new ArgumentNullException("Por favor informe o bairro");
                }
                else if (string.IsNullOrEmpty(regiao))
                {
                    throw new ArgumentNullException("Por favor informe a região");
                }
                else if (cidadeIdcidade.idcidade.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID da Cidade");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idbairro.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do bairro");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsBairro BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
