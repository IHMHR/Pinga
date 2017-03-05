using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsPais : IGeneric<ClsPais>
    {
        public Guid idpais { get; set; }
        public string pais { get; set; }
        public string idioma { get; set; }
        public string colacao { get; set; }
        public string DDI { get; set; }
        public string sigla { get; set; }
        public string fusoHorario { get; set; }
        public ClsContinente continenteIdcontinete { get; set; }

        public ClsPais()
        {
            continenteIdcontinete = new ClsContinente();
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
                    com.CommandText = "Pinga.usp_InserirNovoPais";
                    com.Parameters.AddWithValue("@pais", pais);
                    com.Parameters.AddWithValue("@idioma", idioma);
                    com.Parameters.AddWithValue("@colacao", colacao);
                    com.Parameters.AddWithValue("@DDI", DDI);
                    com.Parameters.AddWithValue("@sigla", sigla);
                    com.Parameters.AddWithValue("@fusoHorario", fusoHorario);
                    com.Parameters.AddWithValue("@continenteIdcontinente", continenteIdcontinete.idcontinente);

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
                    com.CommandText = "UPDATE Pinga.pais SET pais = @pais, idioma = @idioma, colacao = @colacao, DDI = @DDI, sigla = @sigla, fuso_horario = @fusoHorario, continente_idcontinente = @continenteIdcontinente WHERE idpais = @id";
                    com.Parameters.AddWithValue("@pais", pais);
                    com.Parameters.AddWithValue("@idioma", idioma);
                    com.Parameters.AddWithValue("@colacao", colacao);
                    com.Parameters.AddWithValue("@DDI", DDI);
                    com.Parameters.AddWithValue("@sigla", sigla);
                    com.Parameters.AddWithValue("@fusoHorario", fusoHorario);
                    com.Parameters.AddWithValue("@continenteIdcontinente", continenteIdcontinete.idcontinente);
                    com.Parameters.AddWithValue("@id", idpais);

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
                    com.CommandText = "DELETE FROM Pinga.pais WHERE idpais = @id";
                    com.Parameters.AddWithValue("@id", idpais);

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

        public List<ClsPais> Visualizar()
        {
            List<ClsPais> retorno = new List<ClsPais>();
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT p.idpais, p.pais, p.idioma, p.colacao, p.DDI, p.sigla, p.fuso_horario, c.idcontinente, c.continente, tc.idtipo_continente, tc.tipo_continente, tc.ativo FROM Pinga.pais p INNER JOIN Pinga.continente c ON p.continente_idcontinente = c.idcontinente INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente ORDER BY p.pais ASC, tc.ativo DESC;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsPais pais = new ClsPais();
                        pais.idpais = Guid.Parse(read["idpais"].ToString());
                        pais.pais = read["pais"].ToString();
                        pais.idioma = read["idioma"].ToString();
                        pais.colacao = read["colacao"].ToString();
                        pais.DDI = read["DDI"].ToString();
                        pais.sigla = read["sigla"].ToString();
                        pais.fusoHorario = read["fuso_horario"].ToString();
                        pais.continenteIdcontinete.idcontinente = Guid.Parse(read["idcontinente"].ToString());
                        pais.continenteIdcontinete.continente = read["continente"].ToString();
                        pais.continenteIdcontinete.tipoContinenteIdtipoContinente.idtipoContinente = Guid.Parse(read["idtipo_continente"].ToString());
                        pais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
                        pais.continenteIdcontinete.tipoContinenteIdtipoContinente.ativo = (bool)read["ativo"];

                        retorno.Add(pais);
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
                if (string.IsNullOrEmpty(pais.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o pais.");
                }
                else if (string.IsNullOrEmpty(idioma.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o idioma.");
                }
                else if (string.IsNullOrEmpty(colacao.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a colação.");
                }
                else if (string.IsNullOrEmpty(sigla.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a sigla.");
                }
                else if (string.IsNullOrEmpty(fusoHorario.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o fuso horário.");
                }
                else if (string.IsNullOrEmpty(DDI.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o contDDIinente.");
                }
                else if (continenteIdcontinete.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o tipo continente.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idpais.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do pais.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsPais BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
