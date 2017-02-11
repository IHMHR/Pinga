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
    public partial class FrmPais : Form
    {
        Bll bll = new Bll("Pais");
        public FrmPais()
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
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text) && comboBox1.SelectedIndex != -1)
            {
                bll.pais.pais = textBox2.Text.Trim().Replace("'", "");
                bll.pais.idioma = textBox3.Text.Trim().Replace("'", "");
                bll.pais.DDI = textBox5.Text.Trim().Replace("'", "");
                bll.pais.colacao = textBox4.Text.Trim().Replace("'", "");
                bll.pais.sigla = textBox6.Text.Trim().Replace("'", "");
                bll.pais.fusoHorario = textBox7.Text.Trim().Replace("'", "");
                bll.pais.continenteIdcontinete.idcontinente = Guid.Parse(comboBox1.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.pais.idpais = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.pais.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo País com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";
                    bll.pais.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado País com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                    
            }
        }

        private void FrmPais_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdpais = new DataGridViewTextBoxColumn();
                columnIdpais.HeaderText = "idpais";
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

                var columnColacao = new DataGridViewTextBoxColumn();
                columnColacao.HeaderText = "Colação";
                columnColacao.Name = "colacao";
                columnColacao.DataPropertyName = "colacao";

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

                var columnIdcontinente = new DataGridViewTextBoxColumn();
                columnIdcontinente.HeaderText = "idcontinente";
                columnIdcontinente.Name = "idcontinente";
                columnIdcontinente.DataPropertyName = "idcontinente";
                columnIdcontinente.Visible = false;

                var columnContinente = new DataGridViewTextBoxColumn();
                columnContinente.HeaderText = "Continente";
                columnContinente.Name = "continente";
                columnContinente.DataPropertyName = "continente";

                var columnIdtipoContinente = new DataGridViewTextBoxColumn();
                columnIdtipoContinente.HeaderText = "idtipoContinente";
                columnIdtipoContinente.Name = "idtipoContinente";
                columnIdtipoContinente.DataPropertyName = "idtipoContinente";
                columnIdtipoContinente.Visible = false;

                var columnTipoContinente = new DataGridViewTextBoxColumn();
                columnTipoContinente.HeaderText = "Tipo Continente";
                columnTipoContinente.Name = "tipoContinente";
                columnTipoContinente.DataPropertyName = "tipoContinente";

                var columnTipoContinenteAtivo = new DataGridViewCheckBoxColumn();
                columnTipoContinenteAtivo.HeaderText = "Tipo Continente Ativo";
                columnTipoContinenteAtivo.Name = "tipoContinenteAtivo";
                columnTipoContinenteAtivo.DataPropertyName = "tipoContinenteAtivo";

                dataGridView1.Columns.Add(columnIdpais);
                dataGridView1.Columns.Add(columnPais);
                dataGridView1.Columns.Add(columnIdioma);
                dataGridView1.Columns.Add(columnColacao);
                dataGridView1.Columns.Add(columnDDI);
                dataGridView1.Columns.Add(columnSigla);
                dataGridView1.Columns.Add(columnFusoHorario);
                dataGridView1.Columns.Add(columnIdcontinente);
                dataGridView1.Columns.Add(columnContinente);
                dataGridView1.Columns.Add(columnIdtipoContinente);
                dataGridView1.Columns.Add(columnTipoContinente);
                dataGridView1.Columns.Add(columnTipoContinenteAtivo);

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarPais";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarPais";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();

                // popular combo box
                comboBox1.DataSource = new Bll("Continente").continente.Visualizar().Where(cont => cont.tipoContinenteIdtipoContinente.ativo).ToList();
                comboBox1.DisplayMember = "continente";
                comboBox1.ValueMember = "idcontinente";
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

            foreach (var item in bll.pais.Visualizar())
            {
                dataGridView1.Rows.Add(item.idpais, item.pais, item.idioma, item.colacao, item.DDI, item.sigla, item.fusoHorario, item.continenteIdcontinete.idcontinente, item.continenteIdcontinete.continente, item.continenteIdcontinete.tipoContinenteIdtipoContinente.idtipoContinente, item.continenteIdcontinete.tipoContinenteIdtipoContinente.tipoContinente, item.continenteIdcontinete.tipoContinenteIdtipoContinente.ativo);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarPais")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idpais"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["pais"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["idioma"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["colacao"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["DDI"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["sigla"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["fusoHorario"].Value.ToString();

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    bll.continente = (BLL.Classes.ClsContinente)comboBox1.Items[i];
                    if (bll.continente.idcontinente.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idcontinente"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarPais")
            {
                bll.pais.idpais = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idpais"].Value.ToString());
                bll.pais.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado pais com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Classes.ClsGlobal.somenteNumero(e.KeyChar.ToString()) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }
    }
}
