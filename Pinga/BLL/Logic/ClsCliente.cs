using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;

namespace BLL.Logic
{
    public sealed class ClsClienteBO : IGeneric<ClsCliente>
    {
        private static ClsCliente c = null;

        public ClsClienteBO()
        {
            c = new ClsCliente();
        }

        public ClsClienteBO(ClsCliente clienteClass)
        {
            c = clienteClass ?? new ClsCliente();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsCliente> Visualizar()
        {
            List<ClsCliente> retorno = new List<ClsCliente>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idcliente, cpf_cnpj, nome_razao_social, apelido_nome_fantasia, inscricao_municipal, identidade_inscricao_estadual, data_nascimento_fundacao, sexo, idemail, email, idendereco, tipo_logradouro, logradouro, numero, tipo_complemento, complemento, ponto_referencia, CEP, bairro, DDD, cidade, capital, estado, uf, pais, sigla, continente, idtelefone, telefone, telefone_DDD, operadora, telefone_cidade, tipo_telefone FROM Pinga.uvw_VisualizarInfoCliente;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsCliente c = new ClsCliente();
                        c.idcliente = Guid.Parse(read["idcliente"].ToString());
                        c.nomeRazaoSocial = read["nome_razao_social"].ToString();
                        c.apelidoNomeFantasia = read["apelido_nome_fantasia"].ToString();
                        c.sexo = char.Parse(read["sexo"].ToString());
                        c.inscricaoMunicipal = read["inscricao_municipal"].ToString();
                        c.identidadeInscricaoEstadual = read["identidade_inscricao_estadual"].ToString();
                        c.dataNascimentoFundacao = DateTime.Parse(read["data_nascimento_fundacao"].ToString());
                        /*c.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            c.created = DateTime.Parse(read["modified"].ToString());
                        }*/
                        MailAddress email = new MailAddress(read["email"].ToString());
                        c.emailIdemail.idemail = Guid.Parse(read["idemail"].ToString());
                        c.emailIdemail.emailDominioIdemailDominio.emailDominio = email.Host.Substring(0, email.Host.IndexOf('.'));
                        c.emailIdemail.emailLocalidadeIdemailLocalidade.emailLocalidade = email.Host.Substring(email.Host.IndexOf('.'));
                        c.telefoneIdtelefone.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                        c.telefoneIdtelefone.telefone = read["telefone"].ToString();
                        c.telefoneIdtelefone.cidadeDDD.DDD = read["DDD"].ToString();
                        c.telefoneIdtelefone.operadoraIdoperadora.operadora = read["operadora"].ToString();
                        c.telefoneIdtelefone.cidadeDDD.cidade = read["telefone_cidade"].ToString();
                        c.telefoneIdtelefone.tipoTelefoneIdtipoTelefone.tipoTelefone = read["tipo_telefone"].ToString();
                        c.enderecoIdendereco.idendereco = Guid.Parse(read["idendereco"].ToString());
                        c.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                        c.enderecoIdendereco.logradouro = read["logradouro"].ToString();
                        c.enderecoIdendereco.numero = int.Parse(read["numero"].ToString());
                        c.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                        c.enderecoIdendereco.complemento = read["complemento"].ToString();
                        c.enderecoIdendereco.pontoReferencia = read["ponto_referencia"].ToString();
                        c.enderecoIdendereco.CEP = read["CEP"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.bairro = read["bairro"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.DDD = read["DDD"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                        c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();

                        retorno.Add(c);
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
                if (string.IsNullOrEmpty(c.cpfCnpj.Trim()))
                {
                    throw new ArgumentNullException(@"Por favor informe o CPF\CNPJ do cliente");
                }
                else if (string.IsNullOrEmpty(c.nomeRazaoSocial.Trim()))
                {
                    throw new ArgumentNullException(@"Por favor informe o Nome\Razão Social do cliente");
                }
                else if (string.IsNullOrEmpty(c.apelidoNomeFantasia.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o apelido do cliente");
                }
                else if (string.IsNullOrEmpty(c.identidadeInscricaoEstadual.Trim()))
                {
                    throw new ArgumentNullException(@"Por favor informe a Identidade\Inscrição Estadual do cliente");
                }
                else if (c.dataNascimentoFundacao.ToString() == "01/01/0001 00:00:00")
                {
                    throw new ArgumentNullException(@"Por favor informe a Data de Nascimento\Fundação do cliente");
                }
                else if (c.sexo != 'M' && c.sexo != 'F' && c.sexo.ToString() != string.Empty)
                {
                    throw new ArgumentNullException(@"Por favor informe o sexo do cliente");
                }
                else if (c.emailIdemail.idemail.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o email do cliente");
                }
                else if (c.enderecoIdendereco.idendereco.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o endereço do cliente");
                }
                else if (c.telefoneIdtelefone.idtelefone.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o telefone do cliente");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (c.idcliente.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do cliente");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsCliente BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idcliente, cpf_cnpj, nome_razao_social, apelido_nome_fantasia, inscricao_municipal, identidade_inscricao_estadual, data_nascimento_fundacao, sexo, idemail, email, idendereco, tipo_logradouro, logradouro, numero, tipo_complemento, complemento, ponto_referencia, CEP, bairro, DDD, cidade, capital, estado, uf, pais, sigla, continente, idtelefone, telefone, telefone_DDD, operadora, telefone_cidade, tipo_telefone FROM Pinga.uvw_VisualizarInfoCliente WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    c.idcliente = Guid.Parse(read["idcliente"].ToString());
                    c.nomeRazaoSocial = read["nome_razao_social"].ToString();
                    c.apelidoNomeFantasia = read["apelido_nome_fantasia"].ToString();
                    c.sexo = char.Parse(read["sexo"].ToString());
                    c.inscricaoMunicipal = read["inscricao_municipal"].ToString();
                    c.identidadeInscricaoEstadual = read["identidade_inscricao_estadual"].ToString();
                    c.dataNascimentoFundacao = DateTime.Parse(read["data_nascimento_fundacao"].ToString());
                    /*c.created = DateTime.Parse(read["created"].ToString());
                    if (!string.IsNullOrEmpty(read["modified"].ToString()))
                    {
                        c.created = DateTime.Parse(read["modified"].ToString());
                    }*/
                    MailAddress email = new MailAddress(read["email"].ToString());
                    c.emailIdemail.idemail = Guid.Parse(read["idemail"].ToString());
                    c.emailIdemail.emailDominioIdemailDominio.emailDominio = email.Host.Substring(0, email.Host.IndexOf('.'));
                    c.emailIdemail.emailLocalidadeIdemailLocalidade.emailLocalidade = email.Host.Substring(email.Host.IndexOf('.'));
                    c.telefoneIdtelefone.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                    c.telefoneIdtelefone.telefone = read["telefone"].ToString();
                    c.telefoneIdtelefone.cidadeDDD.DDD = read["DDD"].ToString();
                    c.telefoneIdtelefone.operadoraIdoperadora.operadora = read["operadora"].ToString();
                    c.telefoneIdtelefone.cidadeDDD.cidade = read["telefone_cidade"].ToString();
                    c.telefoneIdtelefone.tipoTelefoneIdtipoTelefone.tipoTelefone = read["tipo_telefone"].ToString();
                    c.enderecoIdendereco.idendereco = Guid.Parse(read["idendereco"].ToString());
                    c.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                    c.enderecoIdendereco.logradouro = read["logradouro"].ToString();
                    c.enderecoIdendereco.numero = int.Parse(read["numero"].ToString());
                    c.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                    c.enderecoIdendereco.complemento = read["complemento"].ToString();
                    c.enderecoIdendereco.pontoReferencia = read["ponto_referencia"].ToString();
                    c.enderecoIdendereco.CEP = read["CEP"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.bairro = read["bairro"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.DDD = read["DDD"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                    c.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
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
