using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsFornecedor : IGeneric<ClsFornecedor>
    {
        public Guid idfornecedor { get; set; }
        public string nome { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsFornecedor> Visualizar()
        {
            List<ClsFornecedor> retorno = new List<ClsFornecedor>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idfornecedor, f.nome, endereco_idendereco, tipo_logradouro, logradouro, numero, tipo_complemento, complemento, CEP, ponto_referencia, bairro, vef.cidade, uf, estado, pais, continente, idtelefone, telefone, vtf.DDD, operadora, tipo_telefone FROM Pinga.fornecedor f INNER JOIN Pinga.uvw_VisualizarEndereco vef ON f.endereco_idendereco = vef.idendereco INNER JOIN Pinga.uvw_VisualizarTelefone vtf ON f.telefone_idtelefone = vtf.idtelefone";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsFornecedor f = new ClsFornecedor();
                        f.idfornecedor = Guid.Parse(read["idfornecedor"].ToString());
                        f.nome = read["nome"].ToString();
                        f.telefoneIdtelefone.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                        f.telefoneIdtelefone.telefone = read["telefone"].ToString();
                        f.telefoneIdtelefone.operadoraIdoperadora.operadora = read["operadora"].ToString();
                        f.telefoneIdtelefone.tipoTelefoneIdtipoTelefone.tipoTelefone = read["tipo_telefone"].ToString();
                        f.telefoneIdtelefone.cidadeDDD.DDD = read["DDD"].ToString();
                        f.telefoneIdtelefone.cidadeDDD.cidade = read["cidade"].ToString();
                        f.enderecoIdendereco.idendereco = Guid.Parse(read["idendereco"].ToString());
                        f.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                        f.enderecoIdendereco.logradouro = read["logradouro"].ToString();
                        f.enderecoIdendereco.numero = int.Parse(read["numero"].ToString());
                        f.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                        f.enderecoIdendereco.complemento = read["complemento"].ToString();
                        f.enderecoIdendereco.pontoReferencia = read["ponto_referencia"].ToString();
                        f.enderecoIdendereco.CEP = read["CEP"].ToString();
                        f.enderecoIdendereco.bairroIdbairro.bairro = read["bairro"].ToString();
                        f.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                        f.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                        f.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                        f.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                        f.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();

                        retorno.Add(f);
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
                if (string.IsNullOrEmpty(nome.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o nome.");
                }
                else if (enderecoIdendereco.idendereco.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o endereço.");
                }
                else if (telefoneIdtelefone.idtelefone.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o telefone.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idfornecedor.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do continente.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsFornecedor BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idfornecedor, f.nome, endereco_idendereco, tipo_logradouro, logradouro, numero, tipo_complemento, complemento, CEP, ponto_referencia, bairro, vef.cidade, uf, estado, pais, continente, idtelefone, telefone, vtf.DDD, operadora, tipo_telefone FROM Pinga.fornecedor f INNER JOIN Pinga.uvw_VisualizarEndereco vef ON f.endereco_idendereco = vef.idendereco INNER JOIN Pinga.uvw_VisualizarTelefone vtf ON f.telefone_idtelefone = vtf.idtelefone WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    idfornecedor = Guid.Parse(read["idfornecedor"].ToString());
                    nome = read["nome"].ToString();
                    telefoneIdtelefone.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                    telefoneIdtelefone.telefone = read["telefone"].ToString();
                    telefoneIdtelefone.operadoraIdoperadora.operadora = read["operadora"].ToString();
                    telefoneIdtelefone.tipoTelefoneIdtipoTelefone.tipoTelefone = read["tipo_telefone"].ToString();
                    telefoneIdtelefone.cidadeDDD.DDD = read["DDD"].ToString();
                    telefoneIdtelefone.cidadeDDD.cidade = read["cidade"].ToString();
                    enderecoIdendereco.idendereco = Guid.Parse(read["idendereco"].ToString());
                    enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                    enderecoIdendereco.logradouro = read["logradouro"].ToString();
                    enderecoIdendereco.numero = int.Parse(read["numero"].ToString());
                    enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                    enderecoIdendereco.complemento = read["complemento"].ToString();
                    enderecoIdendereco.pontoReferencia = read["ponto_referencia"].ToString();
                    enderecoIdendereco.CEP = read["CEP"].ToString();
                    enderecoIdendereco.bairroIdbairro.bairro = read["bairro"].ToString();
                    enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                    enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                    enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                    enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                    enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }
    }
}
