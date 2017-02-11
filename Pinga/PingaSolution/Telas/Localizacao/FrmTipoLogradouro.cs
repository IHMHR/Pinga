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
    public partial class FrmTipoLogradouro : Form
    {
        Bll bll = new Bll("Tipo_Logradouro");
        public FrmTipoLogradouro()
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
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                bll.tipoLogradouro.tipoLogradouro = textBox2.Text.Trim().Replace("'", "");
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.tipoLogradouro.idtipoLogradouro = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.tipoLogradouro.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Tipo Logradouro com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";

                    bll.tipoLogradouro.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Tipo Logradouro com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmTipoLogradouro_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdtipoLogradouro = new DataGridViewTextBoxColumn();
                columnIdtipoLogradouro.HeaderText = "ID Tipo Logradouro";
                columnIdtipoLogradouro.Name = "idtipoLogradouro";
                columnIdtipoLogradouro.DataPropertyName = "idtipoLogradouro";
                columnIdtipoLogradouro.Visible = false;

                var columnTipoLogradouro = new DataGridViewTextBoxColumn();
                columnTipoLogradouro.HeaderText = "Tipo Logradouro";
                columnTipoLogradouro.Name = "tipoLogradouro";
                columnTipoLogradouro.DataPropertyName = "tipoLogradouro";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarTipoLogradouro";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarTipoLogradouro";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdtipoLogradouro);
                dataGridView1.Columns.Add(columnTipoLogradouro);
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

            foreach (var item in bll.tipoLogradouro.Visualizar())
            {
                dataGridView1.Rows.Add(item.idtipoLogradouro, item.tipoLogradouro);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarTipoLogradouro")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idtipoLogradouro"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["tipoLogradouro"].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarTipoLogradouro")
            {
                bll.tipoLogradouro.idtipoLogradouro = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idtipoLogradouro"].Value.ToString());
                bll.tipoLogradouro.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado cidade com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
