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
    public partial class FrmFornecedor : Form
    {
        Bll bll = new Bll("Fornecedor");
        public FrmFornecedor()
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

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdfornecedor = new DataGridViewTextBoxColumn();
                columnIdfornecedor.HeaderText = "ID Fornecedor";
                columnIdfornecedor.Name = "idfornecedor";
                columnIdfornecedor.DataPropertyName = "idfornecedor";
                columnIdfornecedor.Visible = false;

                var columnNomeFornecedor = new DataGridViewTextBoxColumn();
                columnNomeFornecedor.HeaderText = "Nome Fornecedor";
                columnNomeFornecedor.Name = "nome";
                columnNomeFornecedor.DataPropertyName = "nome";

                var columnIdtelefone = new DataGridViewTextBoxColumn();
                columnIdtelefone.HeaderText = "ID Telefone";
                columnIdtelefone.Name = "idtelefone";
                columnIdtelefone.DataPropertyName = "idtelefone";
                columnIdtelefone.Visible = false;

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

                var columnTipoTelefone = new DataGridViewTextBoxColumn();
                columnTipoTelefone.HeaderText = "Tipo Telefone";
                columnTipoTelefone.Name = "tipo_telefone";
                columnTipoTelefone.DataPropertyName = "tipo_telefone";

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
                columnNumero.DataPropertyName = "numero";

                var columnTipoComplemento = new DataGridViewTextBoxColumn();
                columnTipoComplemento.HeaderText = "Tipo Complemenot";
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

                var columncidade = new DataGridViewTextBoxColumn();
                columncidade.HeaderText = "Cidade";
                columncidade.Name = "Cidade";
                columncidade.DataPropertyName = "Cidade";

                var columnEstado = new DataGridViewTextBoxColumn();
                columnEstado.HeaderText = "Estado";
                columnEstado.Name = "estado";
                columnEstado.DataPropertyName = "estado";

                var columnUf = new DataGridViewTextBoxColumn();
                columnUf.HeaderText = "UF";
                columnUf.Name = "uf";
                columnUf.DataPropertyName = "uf";

                var columnContinente = new DataGridViewTextBoxColumn();
                columnEstado.HeaderText = "Continetne";
                columnEstado.Name = "continente";
                columnEstado.DataPropertyName = "continente";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarFornecedor";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarFornecedor";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdfornecedor);
                dataGridView1.Columns.Add(columnNomeFornecedor);
                dataGridView1.Columns.Add(columnIdtelefone);
                dataGridView1.Columns.Add(columnTelefone);
                dataGridView1.Columns.Add(columnOperadora);
                dataGridView1.Columns.Add(columnTipoTelefone);
                dataGridView1.Columns.Add(columnIdEndereco);
                dataGridView1.Columns.Add(columnTipoLogradouro);
                dataGridView1.Columns.Add(columnLogradouro);
                dataGridView1.Columns.Add(columnNumero);
                dataGridView1.Columns.Add(columnTipoComplemento);
                dataGridView1.Columns.Add(columnComplemento);
                dataGridView1.Columns.Add(columnDDD);
                dataGridView1.Columns.Add(columnBairro);
                dataGridView1.Columns.Add(columncidade);
                dataGridView1.Columns.Add(columnEstado);
                dataGridView1.Columns.Add(columnUf);
                dataGridView1.Columns.Add(columnContinente);
                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();

                // popular combo box
                comboBox1.DataSource = new Bll("Endereco").endereco.Visualizar();
                comboBox1.DisplayMember = "bairro";
                comboBox1.ValueMember = "idendereco";
                comboBox1.SelectedIndex = -1;

                comboBox2.DataSource = new Bll("Telefone").telefone.Visualizar();
                comboBox2.DisplayMember = "telefone";
                comboBox2.ValueMember = "idtelefone";
                comboBox2.SelectedIndex = -1;
            }
            catch (Exception error)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in bll.fornecedor.Visualizar())
            {
                dataGridView1.Rows.Add(item.idfornecedor, item.nome, item.telefoneIdtelefone.idtelefone, item.telefoneIdtelefone.cidadeDDD.DDD, item.telefoneIdtelefone.telefone, item.telefoneIdtelefone.operadoraIdoperadora.operadora, item.telefoneIdtelefone.tipoTelefoneIdtipoTelefone.tipoTelefone, item.enderecoIdendereco.idendereco, item.enderecoIdendereco.tipoLogradouroIdtipoLogradouro.tipoLogradouro, item.enderecoIdendereco.logradouro, item.enderecoIdendereco.numero, item.enderecoIdendereco.tipoComplementoIdtipoComplemento.tipoComplemento, item.enderecoIdendereco.complemento, item.enderecoIdendereco.bairroIdbairro.bairro, item.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.cidade, item.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.estado, item.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.uf, item.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.pais, item.enderecoIdendereco.bairroIdbairro.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarFornecedor")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idfornecedor"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    bll.endereco = (BLL.Classes.ClsEndereco)comboBox1.Items[i];
                    if (bll.endereco.idendereco.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idendereco"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    bll.telefone = (BLL.Classes.ClsTelefone)comboBox2.Items[i];
                    if (bll.telefone.idtelefone.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idtelefone"].Value.ToString())
                    {
                        comboBox2.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarFornecedor")
            {
                bll.fornecedor.idfornecedor = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idfornecedor"].Value.ToString());
                bll.fornecedor.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado fornecedor com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text.Trim()) && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                bll.fornecedor.nome = textBox2.Text.Trim();
                bll.fornecedor.enderecoIdendereco.idendereco = Guid.Parse(comboBox1.SelectedValue.ToString());
                bll.fornecedor.telefoneIdtelefone.idtelefone = Guid.Parse(comboBox2.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.fornecedor.idfornecedor = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.fornecedor.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Fornecedor com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    button1.Text = "Salvar";

                    bll.fornecedor.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Fornecedor com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string tipoLogradouro = ((BLL.Classes.ClsEndereco)e.ListItem).tipoLogradouroIdtipoLogradouro.tipoLogradouro;
            string Logradouro = ((BLL.Classes.ClsEndereco)e.ListItem).logradouro;
            int numero = (int)((BLL.Classes.ClsEndereco)e.ListItem).numero;
            string bairro = ((BLL.Classes.ClsEndereco)e.ListItem).bairroIdbairro.bairro;
            string cidade = ((BLL.Classes.ClsEndereco)e.ListItem).bairroIdbairro.cidadeIdcidade.cidade;
            string uf = ((BLL.Classes.ClsEndereco)e.ListItem).bairroIdbairro.cidadeIdcidade.estadoIdestado.uf;
            e.Value = string.Format("{0} {1}, {2} - {3} {4} - {5}", tipoLogradouro, Logradouro, numero, bairro, cidade, uf);
        }

        private void comboBox2_Format(object sender, ListControlConvertEventArgs e)
        {
            string ddd = ((BLL.Classes.ClsTelefone)e.ListItem).cidadeDDD.DDD;
            string telefone = ((BLL.Classes.ClsTelefone)e.ListItem).telefone;
            e.Value = string.Format("({0}) {1}", ddd, telefone);
        }
    }
}
