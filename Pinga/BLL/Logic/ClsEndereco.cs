using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsEnderecoBO : IGeneric<ClsEndereco>
    {
        private static ClsEndereco e = null;

        public ClsEnderecoBO()
        {
            e = new ClsEndereco();
        }

        public ClsEnderecoBO(ClsEndereco enderecoClass)
        {
            e = enderecoClass ?? new ClsEndereco();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEndereco> Visualizar()
        {
            List<ClsEndereco> retorno = new List<ClsEndereco>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT e.idendereco, tl.idtipo_logradouro, tl.tipo_logradouro, e.logradouro, e.numero, tc.idtipo_complemento, tc.tipo_complemento, e.complemento, e.CEP, e.ponto_referencia, b.idbairro, b.bairro, c.idcidade, c.DDD, c.cidade, c.capital, es.idestado, es.uf, es.estado, p.idpais, p.sigla, p.DDI, p.pais, p.fuso_horario, tcon.idtipo_continente, tcon.tipo_continente, con.idcontinente, con.continente FROM Pinga.endereco e INNER JOIN Pinga.tipo_logradouro tl ON e.tipo_logradouro_idtipo_logradouro = tl.idtipo_logradouro INNER JOIN Pinga.tipo_complemento tc ON e.tipo_complemento_idtipo_complemento = tc.idtipo_complemento INNER JOIN Pinga.bairro b ON e.bairro_idbairro = b.idbairro INNER JOIN Pinga.cidade c ON b.cidade_idcidade = c.idcidade INNER JOIN Pinga.estado es ON c.estado_idestado = es.idestado INNER JOIN Pinga.pais p ON es.pais_idpais = p.idpais INNER JOIN Pinga.continente con ON p.continente_idcontinente = con.idcontinente INNER JOIN Pinga.tipo_continente tcon ON con.tipo_continente_idtipo_continente = tcon.idtipo_continente";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsEndereco e = new ClsEndereco();
                        e.idendereco = Guid.Parse(read["idendereco"].ToString());
                        e.tipoLogradouroIdtipoLogradouro.idtipoLogradouro = Guid.Parse(read["idtipo_logradouro"].ToString());
                        e.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                        e.logradouro = read["logradouro"].ToString();
                        e.numero = (int)read["numero"];
                        e.tipoComplementoIdtipoComplemento.idtipoComplemento = Guid.Parse(read["idtipo_complemento"].ToString());
                        e.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                        e.complemento = read["complemento"].ToString();
                        e.pontoReferencia = read["ponto_referencia"].ToString();
                        e.CEP = read["CEP"].ToString();
                        e.bairroIdbairro.idbairro = Guid.Parse(read["idbairro"].ToString());
                        e.bairroIdbairro.bairro = read["bairro"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.idcidade = Guid.Parse(read["idcidade"].ToString());
                        e.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.DDD = read["DDD"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.idestado = Guid.Parse(read["idestado"].ToString());
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.idpais = Guid.Parse(read["idpais"].ToString());
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.idcontinente = Guid.Parse(read["idcontinente"].ToString());
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.idtipoContinente = Guid.Parse(read["idtipo_continente"].ToString());
                        e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();

                        retorno.Add(e);
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
                if (e.tipoLogradouroIdtipoLogradouro.idtipoLogradouro.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o tipo logradouro");
                }
                else if (string.IsNullOrEmpty(e.logradouro.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o logradouro");
                }
                else if (e.tipoComplementoIdtipoComplemento.idtipoComplemento.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o tipo complemento");
                }
                else if (string.IsNullOrEmpty(e.complemento.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o complemento");
                }
                else if (string.IsNullOrEmpty(e.CEP.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o CEP");
                }
                else if (string.IsNullOrEmpty(e.pontoReferencia.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o ponto de referência");
                }
                else if (e.bairroIdbairro.idbairro.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o bairro");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (e.idendereco.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID Endereço");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsEndereco BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT e.idendereco, tl.idtipo_logradouro, tl.tipo_logradouro, e.logradouro, e.numero, tc.idtipo_complemento, tc.tipo_complemento, e.complemento, e.CEP, e.ponto_referencia, b.idbairro, b.bairro, c.idcidade, c.DDD, c.cidade, c.capital, es.idestado, es.uf, es.estado, p.idpais, p.sigla, p.DDI, p.pais, p.fuso_horario, tcon.idtipo_continente, tcon.tipo_continente, con.idcontinente, con.continente FROM Pinga.endereco e INNER JOIN Pinga.tipo_logradouro tl ON e.tipo_logradouro_idtipo_logradouro = tl.idtipo_logradouro INNER JOIN Pinga.tipo_complemento tc ON e.tipo_complemento_idtipo_complemento = tc.idtipo_complemento INNER JOIN Pinga.bairro b ON e.bairro_idbairro = b.idbairro INNER JOIN Pinga.cidade c ON b.cidade_idcidade = c.idcidade INNER JOIN Pinga.estado es ON c.estado_idestado = es.idestado INNER JOIN Pinga.pais p ON es.pais_idpais = p.idpais INNER JOIN Pinga.continente con ON p.continente_idcontinente = con.idcontinente INNER JOIN Pinga.tipo_continente tcon ON con.tipo_continente_idtipo_continente = tcon.idtipo_continente WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    e.idendereco = Guid.Parse(read["idendereco"].ToString());
                    e.tipoLogradouroIdtipoLogradouro.idtipoLogradouro = Guid.Parse(read["idtipo_logradouro"].ToString());
                    e.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                    e.logradouro = read["logradouro"].ToString();
                    e.numero = (int)read["numero"];
                    e.tipoComplementoIdtipoComplemento.idtipoComplemento = Guid.Parse(read["idtipo_complemento"].ToString());
                    e.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                    e.complemento = read["complemento"].ToString();
                    e.pontoReferencia = read["ponto_referencia"].ToString();
                    e.CEP = read["CEP"].ToString();
                    e.bairroIdbairro.idbairro = Guid.Parse(read["idbairro"].ToString());
                    e.bairroIdbairro.bairro = read["bairro"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.idcidade = Guid.Parse(read["idcidade"].ToString());
                    e.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.DDD = read["DDD"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.idestado = Guid.Parse(read["idestado"].ToString());
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.idpais = Guid.Parse(read["idpais"].ToString());
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.idcontinente = Guid.Parse(read["idcontinente"].ToString());
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.idtipoContinente = Guid.Parse(read["idtipo_continente"].ToString());
                    e.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return e;
        }
    }
}
