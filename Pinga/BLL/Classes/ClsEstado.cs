using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BLL.Classes
{
    public sealed class ClsEstado : IGeneric<ClsEstado>
    {
        public Guid idestado { get; set; }
        public string estado { get; set; }
        public string uf { get; set; }
        public bool capital { get; set; }
        public ClsPais paisIdpais { get; set; }

        public ClsEstado()
        {
            paisIdpais = new ClsPais();
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
                    com.CommandText = "Pinga.usp_InserirNovoEstado";
                    com.Parameters.AddWithValue("@estado", estado);
                    com.Parameters.AddWithValue("@uf", uf);
                    com.Parameters.AddWithValue("@capital", capital);
                    com.Parameters.AddWithValue("@paisIdpais", paisIdpais.idpais);

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
                    com.CommandText = "UPDATE Pinga.estado SET estado = @estado, uf = @uf, capital = @capital, pais_idpais = @paisIdpais WHERE idestado = @id";
                    com.Parameters.AddWithValue("@estado", estado);
                    com.Parameters.AddWithValue("@uf", uf);
                    com.Parameters.AddWithValue("@capital", capital);
                    com.Parameters.AddWithValue("@paisIdpais", paisIdpais.idpais);
                    com.Parameters.AddWithValue("@id", idestado);

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
                    com.CommandText = "DELETE FROM Pinga.estado WHERE idestado = @id";
                    com.Parameters.AddWithValue("@id", idestado);

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

        public List<ClsEstado> Visualizar()
        {
            List<ClsEstado> retorno = new List<ClsEstado>();
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT e.idestado, e.estado, e.uf, e.capital, p.idpais, p.pais, p.idioma, p.DDI, p.sigla, p.fuso_horario, c.continente, tc.tipo_continente FROM Pinga.estado e INNER JOIN Pinga.pais p ON e.pais_idpais = p.idpais INNER JOIN Pinga.continente c ON p.continente_idcontinente = c.idcontinente INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsEstado est = new ClsEstado();
                        est.idestado = Guid.Parse(read["idestado"].ToString());
                        est.estado = read["estado"].ToString();
                        est.uf = read["uf"].ToString();
                        est.capital = (bool)read["capital"];
                        est.paisIdpais.idpais = Guid.Parse(read["idpais"].ToString());
                        est.paisIdpais.pais = read["pais"].ToString();
                        est.paisIdpais.idioma = read["idioma"].ToString();
                        est.paisIdpais.DDI = read["DDI"].ToString();
                        est.paisIdpais.sigla = read["sigla"].ToString();
                        est.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                        est.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                        est.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();

                        retorno.Add(est);
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
                if (string.IsNullOrEmpty(estado))
                {
                    throw new ArgumentNullException("Por favor informe o estado");
                }
                else if (string.IsNullOrEmpty(uf))
                {
                    throw new ArgumentNullException("Por favor informe a UF");
                }
                else if (capital != true && capital != false)
                {
                    throw new ArgumentNullException("Por favor informe o estado é capital");
                }
                else if (paisIdpais.idpais.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o pais");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idestado.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do estado");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }
    }
}
