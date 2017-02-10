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
    public partial class FrmCidade : Form
    {
        Bll bll = new Bll("Cidade");
        public FrmCidade()
        {
            InitializeComponent();
        }

        private void FrmCidade_Load(object sender, EventArgs e)
        {
            try
            {
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
                columnEditar.Name = "editarCidade";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarCidade";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

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
                comboBox1.DataSource = new Bll("Estado").estado.Visualizar();
                comboBox1.DisplayMember = "estado";
                comboBox1.ValueMember = "idestado";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in bll.cidade.Visualizar())
            {
                dataGridView1.Rows.Add(item.idcidade, item.cidade, item.DDD, item.capital, item.estadoIdestado.idestado, item.estadoIdestado.estado, item.estadoIdestado.uf, item.estadoIdestado.capital, item.estadoIdestado.paisIdpais.idpais, item.estadoIdestado.paisIdpais.pais, item.estadoIdestado.paisIdpais.idioma, item.estadoIdestado.paisIdpais.DDI, item.estadoIdestado.paisIdpais.sigla, item.estadoIdestado.paisIdpais.fusoHorario, item.estadoIdestado.paisIdpais.continenteIdcontinete.continente, item.estadoIdestado.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.ClsGlobal.ClearForm(groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1)
            {
                bll.cidade.cidade = textBox2.Text;
                bll.cidade.capital = checkBox1.Checked;
                bll.cidade.DDD = textBox3.Text;
                bll.cidade.estadoIdestado.idestado = Guid.Parse(comboBox1.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.cidade.idcidade = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.cidade.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado nova Cidade com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";

                    bll.cidade.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Cidade com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarCidade")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idcidade"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["cidade"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["DDD"].Value.ToString();
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells["capital"].Value)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    bll.estado = (BLL.Classes.ClsEstado)comboBox1.Items[i];
                    if (bll.estado.idestado.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idestado"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarCidade")
            {
                bll.cidade.idcidade = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idcidade"].Value.ToString());
                bll.cidade.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado cidade com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
