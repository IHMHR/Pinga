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
    public partial class FrmTipoComplemento : Form
    {
        Bll bll = new Bll("Tipo_Complemento");
        public FrmTipoComplemento()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                bll.tipoComplemento.tipoComplemento = textBox2.Text.Trim().Replace("'", "");
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.tipoComplemento.idtipoComplemento = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.tipoComplemento.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Tipo Complemento com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";

                    bll.tipoComplemento.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Tipo Complemento com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmTipoComplemento_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdtipoComplemento = new DataGridViewTextBoxColumn();
                columnIdtipoComplemento.HeaderText = "ID Tipo Complemento";
                columnIdtipoComplemento.Name = "idtipoComplemento";
                columnIdtipoComplemento.DataPropertyName = "idtipoComplemento";
                columnIdtipoComplemento.Visible = false;

                var columnTipoComplemento = new DataGridViewTextBoxColumn();
                columnTipoComplemento.HeaderText = "Tipo Complemento";
                columnTipoComplemento.Name = "tipoComplemento";
                columnTipoComplemento.DataPropertyName = "tipoComplemento";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarTipoComplemento";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarTipoComplemento";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdtipoComplemento);
                dataGridView1.Columns.Add(columnTipoComplemento);
                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in bll.tipoComplemento.Visualizar())
            {
                dataGridView1.Rows.Add(item.idtipoComplemento, item.tipoComplemento);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarTipoComplemento")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idtipoComplemento"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["tipoComplemento"].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarTipoComplemento")
            {
                bll.tipoComplemento.idtipoComplemento = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idtipoComplemento"].Value.ToString());
                bll.tipoComplemento.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado Tipo Complemento com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
