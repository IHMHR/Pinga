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
    public partial class FrmEstado : Form
    {
        Bll bll = new Bll("Estado");
        public FrmEstado()
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

        private void FrmEstado_Load(object sender, EventArgs e)
        {
            try
            {
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

                var columnCapital = new DataGridViewCheckBoxColumn();
                columnCapital.HeaderText = "Estado Capital";
                columnCapital.Name = "capital";
                columnCapital.DataPropertyName = "capital";

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
                columnEditar.Name = "editarEstado";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarEstado";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdestado);
                dataGridView1.Columns.Add(columnEstado);
                dataGridView1.Columns.Add(columnUf);
                dataGridView1.Columns.Add(columnCapital);
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
                comboBox1.DataSource = new Bll("Pais").pais.Visualizar();
                comboBox1.DisplayMember = "pais";
                comboBox1.ValueMember = "idpais";
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

            foreach (var item in bll.estado.Visualizar())
            {
                dataGridView1.Rows.Add(item.idestado, item.estado, item.uf, item.capital, item.paisIdpais.idpais, item.paisIdpais.pais, item.paisIdpais.idioma, item.paisIdpais.DDI, item.paisIdpais.sigla, item.paisIdpais.fusoHorario, item.paisIdpais.continenteIdcontinete.continente, item.paisIdpais.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && comboBox1.SelectedIndex != -1)
            {
                bll.estado.estado = textBox2.Text;
                bll.estado.uf = textBox3.Text;
                bll.estado.capital = checkBox1.Checked;
                bll.estado.paisIdpais.idpais = Guid.Parse(comboBox1.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.estado.idestado = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.estado.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Estado com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";
                    bll.estado.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Estado com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarEstado")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idestado"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["estado"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["uf"].Value.ToString();
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
                    bll.pais = (BLL.Classes.ClsPais)comboBox1.Items[i];
                    if (bll.pais.idpais.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idpais"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarEstado")
            {
                bll.estado.idestado = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idestado"].Value.ToString());
                bll.estado.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado estado com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
