using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace BLL.Logic
{
    public sealed class ClsSaidaBO : IGeneric<ClsSaida>
    {
        #region CRUD Funtions
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
                    com.CommandText = "Pinga.usp_InserirNovaSaida";
                    com.Parameters.AddWithValue("@data", data);
                    com.Parameters.AddWithValue("@parceiroIdparceiro", parceiroIdparceiro.idparceiro);
                    com.Parameters.AddWithValue("@clienteIdcliente", clienteIdcliente.idcliente);
                    com.Parameters.AddWithValue("@faseIdfase", faseIdfase.idfase);
                    com.Parameters.AddWithValue("@formaPagamentoIdformaPagamento", formaPagamentoIdformaPagamento.idformaPagamento);
                    com.Parameters.AddWithValue("@parcelamentoIdparcelamento", parcelamentoIdparcelamento.idparcelamento);

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
                    com.CommandText = "UPDATE Pinga.saida SET data = @data, parceiro_idparceiro = @parceiroIdparceiro, cliente_idcliente = @clienteIdcliente, fase_idfase = @faseIdfase, forma_pagamento_idforma_pagamento = @formaPagamentoIdformaPagamento, parcelamento_idparcelamento = @parcelamentoIdparcelamento WHERE idsaida = @id";
                    com.Parameters.AddWithValue("@data", data);
                    com.Parameters.AddWithValue("@parceiroIdparceiro", parceiroIdparceiro.idparceiro);
                    com.Parameters.AddWithValue("@clienteIdcliente", clienteIdcliente.idcliente);
                    com.Parameters.AddWithValue("@faseIdfase", faseIdfase.idfase);
                    com.Parameters.AddWithValue("@formaPagamentoIdformaPagamento", formaPagamentoIdformaPagamento.idformaPagamento);
                    com.Parameters.AddWithValue("@parcelamentoIdparcelamento", parcelamentoIdparcelamento.idparcelamento);
                    com.Parameters.AddWithValue("@id", idsaida);

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
                    com.CommandText = "DELETE FROM Pinga.saida WHERE idsaida = @id";
                    com.Parameters.AddWithValue("@id", idsaida);

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

        public List<ClsSaida> Visualizar()
        {
            List<ClsSaida> retorno = new List<ClsSaida>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT s.idsaida, s.data, s.created, s.modified, p.idparceiro, p.nome, pve.idendereco, pve.tipo_logradouro, pve.logradouro, pve.numero, pve.tipo_complemento, pve.complemento, pve.CEP, pve.ponto_referencia, pve.bairro, pve.uf, pve.estado, pve.sigla, pve.DDI, pve.pais, pve.fuso_horario, pve.tipo_continente, pve.continente, pvt.idtelefone, pvt.ddd, pvt.telefone, pvt.operadora, pvt.cidade, cvic.idcliente, cvic.cpf_cnpj, cvic.nome_razao_social, cvic.apelido_nome_fantasia, cvic.inscricao_municipal, cvic.identidade_inscricao_estadual, cvic.data_nascimento_fundacao, cvic.sexo, cvic.email, f.idfase, f.fase, fp.idforma_pagamento, fp.forma_pagamento, par.idparcelamento, par.data_pagamento, par.data_vencimento, par.parcelas, par.juros FROM Pinga.saida s INNER JOIN Pinga.parceiro p ON s.parceiro_idparceiro = p.idparceiro INNER JOIN Pinga.uvw_VisualizarEndereco pve ON pve.idendereco = p.endereco_idendereco INNER JOIN Pinga.uvw_VisualizarTelefone pvt ON pvt.idtelefone = p.telefone_idtelefone INNER JOIN Pinga.uvw_VisualizarInfoCliente cvic ON cvic.idcliente = s.cliente_idcliente INNER JOIN Pinga.fase f ON f.idfase = s.fase_idfase INNER JOIN Pinga.forma_pagamento fp ON fp.idforma_pagamento = s.forma_pagamento_idforma_pagamento INNER JOIN Pinga.parcelamento par ON par.idparcelamento = s.parcelamento_idparcelamento";

                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsSaida s = new ClsSaida();
                        s.idsaida = Guid.Parse(read["idsaida"].ToString());
                        s.data = DateTime.Parse(read["data"].ToString());
                        s.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            s.modified = DateTime.Parse(read["modified"].ToString());
                        }
                        s.parceiroIdparceiro.idparceiro = Guid.Parse(read["idparceiro"].ToString());
                        s.parceiroIdparceiro.nome = read["nome"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.idendereco = Guid.Parse(read["idendereco"].ToString());
                        s.parceiroIdparceiro.enderecoIdendereco.logradouro = read["logradouro"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.numero = (int)read["numero"];
                        s.parceiroIdparceiro.enderecoIdendereco.complemento = read["complemento"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.CEP = read["CEP"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.pontoReferencia = read["ponto_referencia"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.bairro = read["bairro"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.DDD = read["DDD"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
                        s.parceiroIdparceiro.telefoneIdtelefone.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                        s.parceiroIdparceiro.telefoneIdtelefone.cidadeDDD.DDD = read["ddd"].ToString();
                        s.parceiroIdparceiro.telefoneIdtelefone.telefone = read["telefone"].ToString();
                        s.parceiroIdparceiro.telefoneIdtelefone.operadoraIdoperadora.operadora = read["operadora"].ToString();
                        s.clienteIdcliente.idcliente = Guid.Parse(read["idcliente"].ToString());
                        s.clienteIdcliente.cpfCnpj = read["cpf_cnpj"].ToString();
                        s.clienteIdcliente.identidadeInscricaoEstadual = read["identidade_inscricao_estadual"].ToString();
                        s.clienteIdcliente.inscricaoMunicipal = read["inscricao_municipal"].ToString();
                        s.clienteIdcliente.nomeRazaoSocial = read["nome_razao_social"].ToString();
                        s.clienteIdcliente.apelidoNomeFantasia = read["apelido_nome_fantasia"].ToString();
                        s.clienteIdcliente.dataNascimentoFundacao = DateTime.Parse(read["data_nascimento_fundacao"].ToString());
                        s.clienteIdcliente.sexo = char.Parse(read["sexo"].ToString());
                        MailAddress email = new MailAddress(read["email"].ToString());
                        s.clienteIdcliente.emailIdemail.email = email.User;
                        s.clienteIdcliente.emailIdemail.emailDominioIdemailDominio.emailDominio = email.Host.Substring(0, email.Host.IndexOf('.'));
                        s.clienteIdcliente.emailIdemail.emailLocalidadeIdemailLocalidade.emailLocalidade = email.Host.Substring(email.Host.IndexOf('.') + 1);
                        s.faseIdfase.idfase = Guid.Parse(read["idfase"].ToString());
                        s.faseIdfase.fase = read["fase"].ToString();
                        s.formaPagamentoIdformaPagamento.idformaPagamento = Guid.Parse(read["idforma_pagamento"].ToString());
                        s.formaPagamentoIdformaPagamento.formaPagamento = read["forma_pagamento"].ToString();
                        s.parcelamentoIdparcelamento.idparcelamento = Guid.Parse(read["idparcelamento"].ToString());
                        s.parcelamentoIdparcelamento.dataPagamento = DateTime.Parse(read["data_pagamento"].ToString());
                        s.parcelamentoIdparcelamento.dataVencimento = DateTime.Parse(read["data_vencimento"].ToString());
                        s.parcelamentoIdparcelamento.parcelas = (int)read["parcelas"];
                        s.parcelamentoIdparcelamento.juros = (decimal)read["juros"];

                        retorno.Add(s);
                    }
                    con.Close();
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
                if (string.IsNullOrEmpty(data.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe a data.");
                }
                else if (parceiroIdparceiro.idparceiro.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o parceiro.");
                }
                else if (clienteIdcliente.idcliente.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o cliente.");
                }
                else if (faseIdfase.idfase.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a fase.");
                }
                else if (formaPagamentoIdformaPagamento.idformaPagamento.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a forma pagamento.");
                }
                else if (parcelamentoIdparcelamento.idparcelamento.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o parcelamento.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idsaida.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe id da saida.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsSaida BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT s.idsaida, s.data, s.created, s.modified, p.idparceiro, p.nome, pve.idendereco, pve.tipo_logradouro, pve.logradouro, pve.numero, pve.tipo_complemento, pve.complemento, pve.CEP, pve.ponto_referencia, pve.bairro, pve.uf, pve.estado, pve.sigla, pve.DDI, pve.pais, pve.fuso_horario, pve.tipo_continente, pve.continente, pvt.idtelefone, pvt.ddd, pvt.telefone, pvt.operadora, pvt.cidade, cvic.idcliente, cvic.cpf_cnpj, cvic.nome_razao_social, cvic.apelido_nome_fantasia, cvic.inscricao_municipal, cvic.identidade_inscricao_estadual, cvic.data_nascimento_fundacao, cvic.sexo, cvic.email, f.idfase, f.fase, fp.idforma_pagamento, fp.forma_pagamento, par.idparcelamento, par.data_pagamento, par.data_vencimento, par.parcelas, par.juros FROM Pinga.saida s INNER JOIN Pinga.parceiro p ON s.parceiro_idparceiro = p.idparceiro INNER JOIN Pinga.uvw_VisualizarEndereco pve ON pve.idendereco = p.endereco_idendereco INNER JOIN Pinga.uvw_VisualizarTelefone pvt ON pvt.idtelefone = p.telefone_idtelefone INNER JOIN Pinga.uvw_VisualizarInfoCliente cvic ON cvic.idcliente = s.cliente_idcliente INNER JOIN Pinga.fase f ON f.idfase = s.fase_idfase INNER JOIN Pinga.forma_pagamento fp ON fp.idforma_pagamento = s.forma_pagamento_idforma_pagamento INNER JOIN Pinga.parcelamento par ON par.idparcelamento = s.parcelamento_idparcelamento WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);

                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    idsaida = Guid.Parse(read["idsaida"].ToString());
                    data = DateTime.Parse(read["data"].ToString());
                    created = DateTime.Parse(read["created"].ToString());
                    if (!string.IsNullOrEmpty(read["modified"].ToString()))
                    {
                        modified = DateTime.Parse(read["modified"].ToString());
                    }
                    parceiroIdparceiro.idparceiro = Guid.Parse(read["idparceiro"].ToString());
                    parceiroIdparceiro.nome = read["nome"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.idendereco = Guid.Parse(read["idendereco"].ToString());
                    parceiroIdparceiro.enderecoIdendereco.logradouro = read["logradouro"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.numero = (int)read["numero"];
                    parceiroIdparceiro.enderecoIdendereco.complemento = read["complemento"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.CEP = read["CEP"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.pontoReferencia = read["ponto_referencia"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento = read["tipo_complemento"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro = read["tipo_logradouro"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.bairro = read["bairro"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade = read["cidade"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.DDD = read["DDD"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado = read["estado"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf = read["uf"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais = read["pais"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla = read["sigla"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                    parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
                    parceiroIdparceiro.telefoneIdtelefone.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                    parceiroIdparceiro.telefoneIdtelefone.cidadeDDD.DDD = read["ddd"].ToString();
                    parceiroIdparceiro.telefoneIdtelefone.telefone = read["telefone"].ToString();
                    parceiroIdparceiro.telefoneIdtelefone.operadoraIdoperadora.operadora = read["operadora"].ToString();
                    clienteIdcliente.idcliente = Guid.Parse(read["idcliente"].ToString());
                    clienteIdcliente.cpfCnpj = read["cpf_cnpj"].ToString();
                    clienteIdcliente.identidadeInscricaoEstadual = read["identidade_inscricao_estadual"].ToString();
                    clienteIdcliente.inscricaoMunicipal = read["inscricao_municipal"].ToString();
                    clienteIdcliente.nomeRazaoSocial = read["nome_razao_social"].ToString();
                    clienteIdcliente.apelidoNomeFantasia = read["apelido_nome_fantasia"].ToString();
                    clienteIdcliente.dataNascimentoFundacao = DateTime.Parse(read["data_nascimento_fundacao"].ToString());
                    clienteIdcliente.sexo = char.Parse(read["sexo"].ToString());
                    MailAddress email = new MailAddress(read["email"].ToString());
                    clienteIdcliente.emailIdemail.email = email.User;
                    clienteIdcliente.emailIdemail.emailDominioIdemailDominio.emailDominio = email.Host.Substring(0, email.Host.IndexOf('.'));
                    clienteIdcliente.emailIdemail.emailLocalidadeIdemailLocalidade.emailLocalidade = email.Host.Substring(email.Host.IndexOf('.') + 1);
                    faseIdfase.idfase = Guid.Parse(read["idfase"].ToString());
                    faseIdfase.fase = read["fase"].ToString();
                    formaPagamentoIdformaPagamento.idformaPagamento = Guid.Parse(read["idforma_pagamento"].ToString());
                    formaPagamentoIdformaPagamento.formaPagamento = read["forma_pagamento"].ToString();
                    parcelamentoIdparcelamento.idparcelamento = Guid.Parse(read["idparcelamento"].ToString());
                    parcelamentoIdparcelamento.dataPagamento = DateTime.Parse(read["data_pagamento"].ToString());
                    parcelamentoIdparcelamento.dataVencimento = DateTime.Parse(read["data_vencimento"].ToString());
                    parcelamentoIdparcelamento.parcelas = (int)read["parcelas"];
                    parcelamentoIdparcelamento.juros = (decimal)read["juros"];
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }
        #endregion

        public Guid InserirComRetorno()
        {
            ValidarClasse(CRUD.insert);

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovaSaidaRetorno";
                    com.Parameters.AddWithValue("@data", data);
                    com.Parameters.AddWithValue("@parceiroIdparceiro", parceiroIdparceiro.idparceiro);
                    com.Parameters.AddWithValue("@clienteIdcliente", clienteIdcliente.idcliente);
                    com.Parameters.AddWithValue("@faseIdfase", faseIdfase.idfase);
                    com.Parameters.AddWithValue("@formaPagamentoIdformaPagamento", formaPagamentoIdformaPagamento.idformaPagamento);
                    com.Parameters.AddWithValue("@parcelamentoIdparcelamento", parcelamentoIdparcelamento.idparcelamento);

                    con.Open();
                    var ret = com.ExecuteScalar();
                    con.Close();

                    return Guid.Parse(ret.ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        
    }
}
