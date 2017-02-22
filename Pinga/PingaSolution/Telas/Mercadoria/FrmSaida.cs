using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace PingaSolution.Telas.Mercadoria
{
    public partial class FrmSaida : Form
    {
        Bll bll = new Bll("Saida");
        public FrmSaida()
        {
            InitializeComponent();

            Classes.ClsGlobal.qntProdutos = 1;
            //Classes.ClsGlobal.pointX = label8.Location.X + 9;
            //Classes.ClsGlobal.pointY = label8.Location.Y + 150;
            Classes.ClsGlobal.pointX = label8.Location.X;
            Classes.ClsGlobal.pointY = label8.Location.Y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.ClsGlobal.ClearForm(groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in bll.saida.Visualizar())
            {
                dataGridView1.Rows.Add(item.idsaida, item.data.ToShortDateString(), item.parceiroIdparceiro.idparceiro, item.parceiroIdparceiro.nome, item.parceiroIdparceiro.enderecoIdendereco.idendereco, item.parceiroIdparceiro.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro, item.parceiroIdparceiro.enderecoIdendereco.logradouro, item.parceiroIdparceiro.enderecoIdendereco.numero, item.parceiroIdparceiro.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento, item.parceiroIdparceiro.enderecoIdendereco.complemento, item.parceiroIdparceiro.enderecoIdendereco.pontoReferencia, item.parceiroIdparceiro.enderecoIdendereco.CEP, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.bairro, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente, item.parceiroIdparceiro.telefoneIdtelefone.idtelefone, (item.parceiroIdparceiro.telefoneIdtelefone.cidadeDDD.DDD + " " + item.parceiroIdparceiro.telefoneIdtelefone.telefone), item.parceiroIdparceiro.telefoneIdtelefone.operadoraIdoperadora.operadora, item.clienteIdcliente.idcliente, item.clienteIdcliente.nomeRazaoSocial, item.clienteIdcliente.apelidoNomeFantasia, item.clienteIdcliente.inscricaoMunicipal, item.clienteIdcliente.identidadeInscricaoEstadual, item.clienteIdcliente.dataNascimentoFundacao.ToShortDateString(), item.clienteIdcliente.sexo, (item.clienteIdcliente.emailIdemail.email + "@" + item.clienteIdcliente.emailIdemail.emailDominioIdemailDominio.emailDominio + "." + item.clienteIdcliente.emailIdemail.emailLocalidadeIdemailLocalidade.emailLocalidade));
            }
        }

        private void FrmSaida_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdSaida = new DataGridViewTextBoxColumn();
                columnIdSaida.HeaderText = "ID Saida";
                columnIdSaida.Name = "idsaida";
                columnIdSaida.DataPropertyName = "idsaida";
                columnIdSaida.Visible = false;

                var columnDataSaida = new DataGridViewTextBoxColumn();
                columnDataSaida.HeaderText = "Data Saída";
                columnDataSaida.Name = "data";
                columnDataSaida.DataPropertyName = "data";

                var columnIdParceiro = new DataGridViewTextBoxColumn();
                columnIdParceiro.HeaderText = "ID Parceiro";
                columnIdParceiro.Name = "idparceiro";
                columnIdParceiro.DataPropertyName = "idparceiro";
                columnIdParceiro.Visible = false;

                var columnParceiro = new DataGridViewTextBoxColumn();
                columnParceiro.HeaderText = "Parceiro";
                columnParceiro.Name = "parceiro";
                columnParceiro.DataPropertyName = "parceiro";

                var columnIdEndereco = new DataGridViewTextBoxColumn();
                columnIdEndereco.HeaderText = "ID Endereço";
                columnIdEndereco.Name = "idendereco";
                columnIdEndereco.DataPropertyName = "idendereco";
                columnIdEndereco.Visible = false;

                var columnTipoLogradouro = new DataGridViewTextBoxColumn();
                columnTipoLogradouro.HeaderText = "Tipo Logradouro";
                columnTipoLogradouro.Name = "tipo_logradouro";
                columnTipoLogradouro.DataPropertyName = "tipo_logradouro";

                var columnLogradouro = new DataGridViewTextBoxColumn();
                columnLogradouro.HeaderText = "Logradouro";
                columnLogradouro.Name = "logradouro";
                columnLogradouro.DataPropertyName = "logradouro";

                var columnNumero = new DataGridViewTextBoxColumn();
                columnNumero.HeaderText = "Número";
                columnNumero.Name = "numero";
                columnNumero.DataPropertyName = "columnNumero";

                var columnTipoComplemento = new DataGridViewTextBoxColumn();
                columnTipoComplemento.HeaderText = "Tipo Complemento";
                columnTipoComplemento.Name = "tipo_complemento";
                columnTipoComplemento.DataPropertyName = "tipo_complemento";

                var columnComplemento = new DataGridViewTextBoxColumn();
                columnComplemento.HeaderText = "Complemento";
                columnComplemento.Name = "complemento";
                columnComplemento.DataPropertyName = "complemento";

                var columnPontoReferencia = new DataGridViewTextBoxColumn();
                columnPontoReferencia.HeaderText = "Ponto Referência";
                columnPontoReferencia.Name = "ponto_referencia";
                columnPontoReferencia.DataPropertyName = "ponto_referencia";

                var columnCEP = new DataGridViewTextBoxColumn();
                columnCEP.HeaderText = "CEP";
                columnCEP.Name = "CEP";
                columnCEP.DataPropertyName = "CEP";

                var columnBairro = new DataGridViewTextBoxColumn();
                columnBairro.HeaderText = "Bairro";
                columnBairro.Name = "bairro";
                columnBairro.DataPropertyName = "bairro";

                var columnCidade = new DataGridViewTextBoxColumn();
                columnCidade.HeaderText = "Cidade";
                columnCidade.Name = "cidade";
                columnCidade.DataPropertyName = "cidade";

                var columnEstado = new DataGridViewTextBoxColumn();
                columnEstado.HeaderText = "Estado";
                columnEstado.Name = "estado";
                columnEstado.DataPropertyName = "estado";

                var columnUf = new DataGridViewTextBoxColumn();
                columnUf.HeaderText = "UF";
                columnUf.Name = "uf";
                columnUf.DataPropertyName = "uf";

                var columnPais = new DataGridViewTextBoxColumn();
                columnPais.HeaderText = "País";
                columnPais.Name = "pais";
                columnPais.DataPropertyName = "pais";

                var columnSigla = new DataGridViewTextBoxColumn();
                columnSigla.HeaderText = "Sigla";
                columnSigla.Name = "sigla";
                columnSigla.DataPropertyName = "sigla";

                var columnContinente = new DataGridViewTextBoxColumn();
                columnContinente.HeaderText = "Continente";
                columnContinente.Name = "continente";
                columnContinente.DataPropertyName = "continente";

                var columnIdTelefone = new DataGridViewTextBoxColumn();
                columnIdTelefone.HeaderText = "ID Telefone";
                columnIdTelefone.Name = "idtelefone";
                columnIdTelefone.DataPropertyName = "idtelefone";
                columnIdTelefone.Visible = false;

                var columnDDD = new DataGridViewTextBoxColumn();
                columnDDD.HeaderText = "DDD";
                columnDDD.Name = "DDD";
                columnDDD.DataPropertyName = "DDD";

                var columnTelefone = new DataGridViewTextBoxColumn();
                columnTelefone.HeaderText = "Telefone";
                columnTelefone.Name = "telefone";
                columnTelefone.DataPropertyName = "telefone";

                var columnOperadora = new DataGridViewTextBoxColumn();
                columnOperadora.HeaderText = "Operadora";
                columnOperadora.Name = "operadora";
                columnOperadora.DataPropertyName = "operadora";

                var columnIdCliente = new DataGridViewTextBoxColumn();
                columnIdCliente.HeaderText = "ID Cliente";
                columnIdCliente.Name = "idcliente";
                columnIdCliente.DataPropertyName = "idcliente";
                columnIdCliente.Visible = false;

                var columnCpfCnpj = new DataGridViewTextBoxColumn();
                columnCpfCnpj.HeaderText = "CPF/CNPJ";
                columnCpfCnpj.Name = "cpf_cnpj";
                columnCpfCnpj.DataPropertyName = "cpf_cnpj";

                var columnNomeCliente = new DataGridViewTextBoxColumn();
                columnNomeCliente.HeaderText = "Nome/Razão Social";
                columnNomeCliente.Name = "nome_razao_social";
                columnNomeCliente.DataPropertyName = "nome_razao_social";

                var columnApelidoCliente = new DataGridViewTextBoxColumn();
                columnApelidoCliente.HeaderText = "Apelido/Nome Fantasia";
                columnApelidoCliente.Name = "apelido_nome_fantasia";
                columnApelidoCliente.DataPropertyName = "apelido_nome_fantasia";

                var columnInscricaoMunicipal = new DataGridViewTextBoxColumn();
                columnInscricaoMunicipal.HeaderText = "Inscrição Municipal";
                columnInscricaoMunicipal.Name = "inscricao_municipal";
                columnInscricaoMunicipal.DataPropertyName = "inscricao_municipal";

                var columnIdentidade = new DataGridViewTextBoxColumn();
                columnIdentidade.HeaderText = "Identidade/Inscrição Estadual";
                columnIdentidade.Name = "identidade_inscricao_municipal";
                columnIdentidade.DataPropertyName = "identidade_inscricao_municipal";

                var columnDataNascimento = new DataGridViewTextBoxColumn();
                columnDataNascimento.HeaderText = "Data Nascimento/Fundação";
                columnDataNascimento.Name = "data_nascimento_fundacao";
                columnDataNascimento.DataPropertyName = "data_nascimento_fundacao";

                var columnSexo = new DataGridViewTextBoxColumn();
                columnSexo.HeaderText = "Sexo";
                columnSexo.Name = "sexo";
                columnSexo.DataPropertyName = "sexo";

                var columnEmail = new DataGridViewTextBoxColumn();
                columnEmail.HeaderText = "Email";
                columnEmail.Name = "email";
                columnEmail.DataPropertyName = "email";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarSaida";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarSaida";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdSaida);
                dataGridView1.Columns.Add(columnDataSaida);
                dataGridView1.Columns.Add(columnIdParceiro);
                dataGridView1.Columns.Add(columnParceiro);
                dataGridView1.Columns.Add(columnIdEndereco);
                dataGridView1.Columns.Add(columnTipoLogradouro);
                dataGridView1.Columns.Add(columnLogradouro);
                dataGridView1.Columns.Add(columnNumero);
                dataGridView1.Columns.Add(columnTipoComplemento);
                dataGridView1.Columns.Add(columnComplemento);
                dataGridView1.Columns.Add(columnPontoReferencia);
                dataGridView1.Columns.Add(columnCEP);
                dataGridView1.Columns.Add(columnBairro);
                dataGridView1.Columns.Add(columnCidade);
                dataGridView1.Columns.Add(columnEstado);
                dataGridView1.Columns.Add(columnUf);
                dataGridView1.Columns.Add(columnPais);
                dataGridView1.Columns.Add(columnSigla);
                dataGridView1.Columns.Add(columnContinente);
                dataGridView1.Columns.Add(columnIdTelefone);
                dataGridView1.Columns.Add(columnTelefone);
                dataGridView1.Columns.Add(columnOperadora);
                dataGridView1.Columns.Add(columnIdCliente);
                dataGridView1.Columns.Add(columnNomeCliente);
                dataGridView1.Columns.Add(columnApelidoCliente);
                dataGridView1.Columns.Add(columnInscricaoMunicipal);
                dataGridView1.Columns.Add(columnIdentidade);
                dataGridView1.Columns.Add(columnDataNascimento);
                dataGridView1.Columns.Add(columnSexo);
                dataGridView1.Columns.Add(columnEmail);
                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();

                // popular combo box
                comboBox1.DataSource = new Bll("Parceiro").parceiro.Visualizar();
                comboBox1.DisplayMember = "nome";
                comboBox1.ValueMember = "idparceiro";
                comboBox1.SelectedIndex = -1;

                comboBox2.DataSource = new Bll("Cliente").cliente.Visualizar();
                comboBox2.DisplayMember = "nomeRazaoSocial";
                comboBox2.ValueMember = "idcliente";
                comboBox2.SelectedIndex = -1;

                comboBox3.DataSource = new Bll("Fase").fase.Visualizar();
                comboBox3.DisplayMember = "Fase";
                comboBox3.ValueMember = "idfase";
                comboBox3.SelectedIndex = -1;

                comboBox4.DataSource = new Bll("Forma_Pagamento").formaPagamento.Visualizar();
                comboBox4.DisplayMember = "formaPagamento";
                comboBox4.ValueMember = "idformaPagamento";
                comboBox4.SelectedIndex = -1;

                comboBox5.DataSource = new Bll("Parcelamento").parcelamento.Visualizar();
                comboBox5.DisplayMember = "parcelas";
                comboBox5.ValueMember = "idparcelamento";
                comboBox5.SelectedIndex = -1;

                Produto1.DataSource = new Bll("Produto").produto.Visualizar();
                Produto1.DisplayMember = "Produto";
                Produto1.ValueMember = "idproduto";
                Produto1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1 && comboBox5.SelectedIndex != -1)
            {
                bll.saida.data = dateTimePicker1.Value;
                bll.saida.parceiroIdparceiro.idparceiro = Guid.Parse(comboBox1.SelectedValue.ToString());
                bll.saida.clienteIdcliente.idcliente = Guid.Parse(comboBox2.SelectedValue.ToString());
                bll.saida.faseIdfase.idfase = Guid.Parse(comboBox3.SelectedValue.ToString());
                bll.saida.formaPagamentoIdformaPagamento.idformaPagamento = Guid.Parse(comboBox4.SelectedValue.ToString());
                bll.saida.parcelamentoIdparcelamento.idparcelamento = Guid.Parse(comboBox5.SelectedValue.ToString());

                if (button1.Text == "Salvar")
                {
                    Guid idSaida = bll.saida.InserirComRetorno();

                    List<Bll> itensSaidaList = new List<Bll>();
                    int i;

                    Bll bllItensSaida = null;
                    for (i = 0; i < Classes.ClsGlobal.qntProdutos; i++)
                    {
                        bllItensSaida = new Bll("Itens_Saida");
                        bllItensSaida.itensSaida.saidaIdsaida.idsaida = idSaida;

                        itensSaidaList.Add(bllItensSaida);
                    }

                    i = 0;
                    foreach (ComboBox cmb in groupBox2.Controls.OfType<ComboBox>().Where(x => x.Name.StartsWith("Produto")).ToList())
                    {
                        itensSaidaList[i++].itensSaida.produtoIdproduto.idproduto = Guid.Parse(cmb.SelectedValue.ToString());
                    }

                    i = 0;
                    foreach (TextBox txt in groupBox2.Controls.OfType<TextBox>().Where(x => x.Name.StartsWith("QntI")).ToList())
                    {
                        itensSaidaList[i++].itensSaida.quantidade = int.Parse(txt.Text);
                    }

                    i = 0;
                    foreach (TextBox txt in groupBox2.Controls.OfType<TextBox>().Where(x => x.Name.StartsWith("preco")).ToList())
                    {
                        itensSaidaList[i++].itensSaida.valorSaida = decimal.Parse(txt.Text);
                    }

                    for (i = 0; i < Classes.ClsGlobal.qntProdutos; i++)
                    {
                        itensSaidaList[i++].itensSaida.Inserir();
                    }

                    fillDataGrid();
                    MessageBox.Show("Cadastrado nova Saída com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    button1.Text = "Salvar";

                    bll.saida.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterada Saída com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox5_Format(object sender, ListControlConvertEventArgs e)
        {
            DateTime dtVencimento = (DateTime)((BLL.Classes.ClsParcelamento)e.ListItem).dataVencimento;
            DateTime dtPagamento = (DateTime)((BLL.Classes.ClsParcelamento)e.ListItem).dataPagamento;
            int parcelas = ((BLL.Classes.ClsParcelamento)e.ListItem).parcelas;
            decimal juros = ((BLL.Classes.ClsParcelamento)e.ListItem).juros;
            e.Value = string.Format("Dt Venc: {0}, Dt 1º P: {1}, Parcelas: {2}, Juros: {3}", dtVencimento.ToShortDateString(), dtPagamento.ToShortDateString(), parcelas, juros);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Classes.ClsGlobal.qntProdutos < 8)
            {
                groupBox2.SuspendLayout();

                Classes.ClsGlobal.pointY += 22;
                Classes.ClsGlobal.qntProdutos++;

                Label lbl = new Label();
                lbl.Text = "Produto" + Classes.ClsGlobal.qntProdutos;
                lbl.Location = new Point(Classes.ClsGlobal.pointX, Classes.ClsGlobal.pointY);
                lbl.Width = 55;
                groupBox2.Controls.Add(lbl);

                ComboBox cmb = new ComboBox();
                cmb.Name = "Produto" + Classes.ClsGlobal.qntProdutos;
                cmb.Location = new Point(Classes.ClsGlobal.pointX + 55, Classes.ClsGlobal.pointY);
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb.Width = 171;
                cmb.DataSource = new Bll("Produto").produto.Visualizar();
                cmb.DisplayMember = "Produto";
                cmb.ValueMember = "idproduto";
                groupBox2.Controls.Add(cmb);
                cmb.SelectedIndex = -1;

                Label lblQnt = new Label();
                lblQnt.Text = "Quantidade";
                lblQnt.Width = 62;
                lblQnt.Location = new Point(Classes.ClsGlobal.pointX + 230, Classes.ClsGlobal.pointY);
                groupBox2.Controls.Add(lblQnt);

                TextBox txt = new TextBox();
                txt.Name = "QntItem" + Classes.ClsGlobal.qntProdutos;
                txt.Text = String.Empty;
                txt.Width = 45;
                txt.Location = new Point(Classes.ClsGlobal.pointX + 300, Classes.ClsGlobal.pointY);
                groupBox2.Controls.Add(txt);

                Label lblPreco = new Label();
                lblPreco.Text = "Preço Unidade";
                lblPreco.Width = 78;
                lblPreco.Location = new Point(Classes.ClsGlobal.pointX + 350, Classes.ClsGlobal.pointY);
                groupBox2.Controls.Add(lblPreco);

                TextBox txtPreco = new TextBox();
                txtPreco.Name = "precoUnidade" + Classes.ClsGlobal.qntProdutos;
                txtPreco.Text = String.Empty;
                txtPreco.Width = 57;
                txtPreco.Location = new Point(Classes.ClsGlobal.pointX + 435, Classes.ClsGlobal.pointY);
                groupBox2.Controls.Add(txtPreco);

                groupBox2.ResumeLayout(false);
            }
            else
            {
                button4.Visible = false;
            }
        }
    }
}
