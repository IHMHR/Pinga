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
                string email = item.clienteIdcliente.emailIdemail.email + "@" + item.clienteIdcliente.emailIdemail.emailDominioIdemailDominio.emailDominio + "." + item.clienteIdcliente.emailIdemail.emailLocalidadeIdemailLocalidade.emailLocalidade;
                dataGridView1.Rows.Add(item.idsaida, item.data, item.parceiroIdparceiro.idparceiro, item.parceiroIdparceiro.nome, item.parceiroIdparceiro.enderecoIdendereco.idendereco, item.parceiroIdparceiro.enderecoIdendereco, item.parceiroIdparceiro.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro, item.parceiroIdparceiro.enderecoIdendereco.logradouro, item.parceiroIdparceiro.enderecoIdendereco.numero, item.parceiroIdparceiro.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento, item.parceiroIdparceiro.enderecoIdendereco.complemento, item.parceiroIdparceiro.enderecoIdendereco.pontoReferencia, item.parceiroIdparceiro.enderecoIdendereco.CEP, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.bairro, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.sigla, item.parceiroIdparceiro.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente, item.parceiroIdparceiro.telefoneIdtelefone.idtelefone, item.parceiroIdparceiro.telefoneIdtelefone.telefone, item.parceiroIdparceiro.telefoneIdtelefone.operadoraIdoperadora.operadora, item.clienteIdcliente.idcliente, item.clienteIdcliente.nomeRazaoSocial, item.clienteIdcliente.apelidoNomeFantasia, item.clienteIdcliente.inscricaoMunicipal, item.clienteIdcliente.identidadeInscricaoEstadual, item.clienteIdcliente.dataNascimentoFundacao, item.clienteIdcliente.sexo, email);
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
                comboBox1.DisplayMember = "parceiro";
                comboBox1.ValueMember = "idparceiro";
                comboBox1.SelectedIndex = -1;

                comboBox2.DataSource = new Bll("Cliente").cliente.Visualizar();
                comboBox2.DisplayMember = "nome";
                comboBox2.ValueMember = "idcliente";
                comboBox2.SelectedIndex = -1;

                comboBox3.DataSource = new Bll("Fase").fase.Visualizar();
                comboBox3.DisplayMember = "fase";
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
            }
            catch (Exception erro)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
