﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace BLL.Classes
{
    public sealed class ClsSaida : IGeneric<ClsSaida>
    {
        public Guid idsaida { get; set; }
        public DateTime data { get; set; }
        public ClsParceiro parceiroIdparceiro { get; set; }
        public ClsCliente clienteIdcliente { get; set; }
        public ClsFase faseIdfase { get; set; }
        public ClsFormaPagamento formaPagamentoIdformaPagamento { get; set; }
        public ClsParcelamento parcelamentoIdparcelamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsSaida()
        {
            
            parceiroIdparceiro = new ClsParceiro();
            clienteIdcliente = new ClsCliente();
            faseIdfase = new ClsFase();
            formaPagamentoIdformaPagamento = new ClsFormaPagamento();
            parcelamentoIdparcelamento = new ClsParcelamento();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

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
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.fusoHorario = read["fuso_horario"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente = read["continente"].ToString();
                        s.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
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
    }
}
