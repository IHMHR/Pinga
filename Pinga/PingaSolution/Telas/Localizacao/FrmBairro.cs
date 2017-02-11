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

namespace PingaSolution.Telas.Localizacao
{
    public partial class FrmBairro : Form
    {
        Bll bll = new Bll("Bairro");
        public FrmBairro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.ClsGlobal.ClearForm(groupBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && comboBox1.SelectedIndex != -1)
            {
                bll.bairro.bairro = textBox2.Text.Trim().Replace("'", "");
                bll.bairro.regiao = textBox3.Text.Trim().Replace("'", "");
                bll.bairro.cidadeIdcidade.idcidade = Guid.Parse(comboBox1.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.bairro.idbairro = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.bairro.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Bairro com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";

                    bll.bairro.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Bairro com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmBairro_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdbairro = new DataGridViewTextBoxColumn();
                columnIdbairro.HeaderText = "ID Bairro";
                columnIdbairro.Name = "idbairro";
                columnIdbairro.DataPropertyName = "idbairro";
                columnIdbairro.Visible = false;

                var columnBairro = new DataGridViewTextBoxColumn();
                columnBairro.HeaderText = "Bairro";
                columnBairro.Name = "bairro";
                columnBairro.DataPropertyName = "bairro";

                var columnRegiao = new DataGridViewTextBoxColumn();
                columnRegiao.HeaderText = "Região do Bairro";
                columnRegiao.Name = "regiao";
                columnRegiao.DataPropertyName = "regiao";

                var columnIdcidade = new DataGridViewTextBoxColumn();
                columnIdcidade.HeaderText = "ID Cidade";
                columnIdcidade.Name = "idcidade";
                columnIdcidade.DataPropertyName = "idcidade";
                columnIdcidade.Visible = false;

                var columnCidade = new DataGridViewTextBoxColumn();
                columnCidade.HeaderText = "Cidade";
                columnCidade.Name = "cidade";
                columnCidade.DataPropertyName = "cidade";

                var columnDDD = new DataGridViewTextBoxColumn();
                columnDDD.HeaderText = "DDD";
                columnDDD.Name = "DDD";
                columnDDD.DataPropertyName = "DDD";

                var columnCapital = new DataGridViewCheckBoxColumn();
                columnCapital.HeaderText = "Capital do Estado";
                columnCapital.Name = "capital";
                columnCapital.DataPropertyName = "Capital do Estado";

                var columnIdestado = new DataGridViewTextBoxColumn();
                columnIdestado.HeaderText = "ID Estado";
                columnIdestado.Name = "idestado";
                columnIdestado.DataPropertyName = "idestado";
                columnIdestado.Visible = false;

                var columnEstado = new DataGridViewTextBoxColumn();
                columnEstado.HeaderText = "Estado";
                columnEstado.Name = "estado";
                columnEstado.DataPropertyName = "estado";

                var columnUf = new DataGridViewTextBoxColumn();
                columnUf.HeaderText = "UF";
                columnUf.Name = "uf";
                columnUf.DataPropertyName = "uf";

                var columnEstadoCapital = new DataGridViewCheckBoxColumn();
                columnEstadoCapital.HeaderText = "Estado Capital";
                columnEstadoCapital.Name = "capital";
                columnEstadoCapital.DataPropertyName = "capital";

                var columnIdpais = new DataGridViewTextBoxColumn();
                columnIdpais.HeaderText = "ID Pais";
                columnIdpais.Name = "idpais";
                columnIdpais.DataPropertyName = "idpais";
                columnIdpais.Visible = false;

                var columnPais = new DataGridViewTextBoxColumn();
                columnPais.HeaderText = "País";
                columnPais.Name = "pais";
                columnPais.DataPropertyName = "pais";

                var columnIdioma = new DataGridViewTextBoxColumn();
                columnIdioma.HeaderText = "Idioma";
                columnIdioma.Name = "idioma";
                columnIdioma.DataPropertyName = "idioma";

                var columnDDI = new DataGridViewTextBoxColumn();
                columnDDI.HeaderText = "DDI";
                columnDDI.Name = "DDI";
                columnDDI.DataPropertyName = "DDI";

                var columnSigla = new DataGridViewTextBoxColumn();
                columnSigla.HeaderText = "Sigla";
                columnSigla.Name = "sigla";
                columnSigla.DataPropertyName = "sigla";

                var columnFusoHorario = new DataGridViewTextBoxColumn();
                columnFusoHorario.HeaderText = "Fuso Horário";
                columnFusoHorario.Name = "fusoHorario";
                columnFusoHorario.DataPropertyName = "fusoHorario";

                var columnContinente = new DataGridViewTextBoxColumn();
                columnContinente.HeaderText = "Continente";
                columnContinente.Name = "continente";
                columnContinente.DataPropertyName = "continente";

                var columnTipoContinente = new DataGridViewTextBoxColumn();
                columnTipoContinente.HeaderText = "Tipo Continente";
                columnTipoContinente.Name = "tipoContinente";
                columnTipoContinente.DataPropertyName = "tipoContinente";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarBairro";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarBairro";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdbairro);
                dataGridView1.Columns.Add(columnBairro);
                dataGridView1.Columns.Add(columnRegiao);
                dataGridView1.Columns.Add(columnIdcidade);
                dataGridView1.Columns.Add(columnCidade);
                dataGridView1.Columns.Add(columnDDD);
                dataGridView1.Columns.Add(columnCapital);
                dataGridView1.Columns.Add(columnIdestado);
                dataGridView1.Columns.Add(columnEstado);
                dataGridView1.Columns.Add(columnUf);
                dataGridView1.Columns.Add(columnEstadoCapital);
                dataGridView1.Columns.Add(columnIdpais);
                dataGridView1.Columns.Add(columnPais);
                dataGridView1.Columns.Add(columnIdioma);
                dataGridView1.Columns.Add(columnDDI);
                dataGridView1.Columns.Add(columnSigla);
                dataGridView1.Columns.Add(columnFusoHorario);
                dataGridView1.Columns.Add(columnContinente);
                dataGridView1.Columns.Add(columnTipoContinente);
                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();

                // popular combo box
                comboBox1.DataSource = new Bll("Cidade").cidade.Visualizar();
                comboBox1.DisplayMember = "cidade";
                comboBox1.ValueMember = "idcidade";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in bll.bairro.Visualizar())
            {
                dataGridView1.Rows.Add(item.idbairro, item.bairro, item.regiao, item.cidadeIdcidade.idcidade, item.cidadeIdcidade.cidade, item.cidadeIdcidade.DDD, item.cidadeIdcidade.capital, item.cidadeIdcidade.estadoIdestado.idestado, item.cidadeIdcidade.estadoIdestado.estado, item.cidadeIdcidade.estadoIdestado.uf, item.cidadeIdcidade.estadoIdestado.capital, item.cidadeIdcidade.estadoIdestado.paisIdpais.idpais, item.cidadeIdcidade.estadoIdestado.paisIdpais.pais, item.cidadeIdcidade.estadoIdestado.paisIdpais.idioma, item.cidadeIdcidade.estadoIdestado.paisIdpais.DDI, item.cidadeIdcidade.estadoIdestado.paisIdpais.sigla, item.cidadeIdcidade.estadoIdestado.paisIdpais.fusoHorario, item.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.continente, item.cidadeIdcidade.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarBairro")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idbairro"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["bairro"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["regiao"].Value.ToString();

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    bll.cidade = (BLL.Classes.ClsCidade)comboBox1.Items[i];
                    if (bll.cidade.idcidade.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idcidade"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarBairro")
            {
                bll.bairro.idbairro = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idbairro"].Value.ToString());
                bll.bairro.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado cidade com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
