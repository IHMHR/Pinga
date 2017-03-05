using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsParceiro : IGeneric<ClsParceiro>
    {
        public Guid idparceiro { get; set; }
        public string nome { get; set; }
        public ClsEndereco enderecoIdendereco { get; set; }
        public bool status { get; set; }
        public ClsTelefone telefoneIdtelefone { get; set; }
        public DateTime created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsParceiro()
        {
            enderecoIdendereco = new ClsEndereco();
            telefoneIdtelefone = new ClsTelefone();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsParceiro> Visualizar()
        {
            List<ClsParceiro> retorno = new List<ClsParceiro>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT p.idparceiro, p.nome, p.status, p.created, p.modified, pve.idendereco, pve.tipo_logradouro, pve.logradouro, pve.numero, pve.tipo_complemento, pve.complemento, pve.CEP, pve.ponto_referencia, pve.bairro, pve.cidade, pve.uf, pve.estado, pve.sigla, pve.DDI, pve.pais, pve.fuso_horario, pve.continente, pvt.idtelefone, pvt.ddd, pvt.telefone, pvt.operadora FROM Pinga.parceiro p INNER JOIN Pinga.uvw_VisualizarEndereco pve ON p.endereco_idendereco = pve.idendereco INNER JOIN Pinga.uvw_VisualizarTelefone pvt ON p.telefone_idtelefone = pvt.idtelefone;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsParceiro p = new ClsParceiro();
                        p.idparceiro = Guid.Parse(read["idparceiro"].ToString());
                        p.nome = read["nome"].ToString();
                        p.status = (bool)read["status"];
                        p.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            p.modified = DateTime.Parse(read["modified"].ToString());
                        }
                        p.telefoneIdtelefone.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                        p.telefoneIdtelefone.telefone = read["telefone"].ToString();
                        p.telefoneIdtelefone.cidadeDDD.DDD = read["DDD"].ToString();
                        p.telefoneIdtelefone.operadoraIdoperadora.operadora = read["operadora"].ToString();
                        p.enderecoIdendereco.idendereco = Guid.Parse(read["idendereco"].ToString());
                        p.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                        p.enderecoIdendereco.logradouro = read["logradouro"].ToString();
                        p.enderecoIdendereco.numero = (int)read["numero"];
                        p.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                        p.enderecoIdendereco.complemento = read["complemento"].ToString();
                        p.enderecoIdendereco.pontoReferencia = read["ponto_referencia"].ToString();
                        p.enderecoIdendereco.CEP = read["CEP"].ToString();
                        p.enderecoIdendereco.bairroIdbairro.bairro = read["bairro"].ToString();
                        p.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                        p.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                        p.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                        p.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();

                        retorno.Add(p);
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
                else if (status != true && status != false)
                {
                    throw new ArgumentNullException("Por favor informe o status.");
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
                if (idparceiro.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do Parceiro.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsParceiro BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
