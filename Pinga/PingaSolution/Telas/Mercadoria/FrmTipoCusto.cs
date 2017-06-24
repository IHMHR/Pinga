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
    public partial class FrmTipoCusto : Form
    {
        Bll bll = new Bll("Tipo_Custo");
        public FrmTipoCusto()
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

        private void FrmTipoCusto_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdtipoCusto = new DataGridViewTextBoxColumn();
                columnIdtipoCusto.HeaderText = "ID Tipo Custo";
                columnIdtipoCusto.Name = "idtipoCusto";
                columnIdtipoCusto.DataPropertyName = "idtipoCusto";
                columnIdtipoCusto.Visible = false;

                var columnTipoCusto = new DataGridViewTextBoxColumn();
                columnTipoCusto.HeaderText = "Tipo Custo";
                columnTipoCusto.Name = "tipoCusto";
                columnTipoCusto.DataPropertyName = "tipoCusto";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarTipoCusto";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarTipoCusto";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdtipoCusto);
                dataGridView1.Columns.Add(columnTipoCusto);
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

            foreach (var item in bll.tipoCusto.Visualizar())
            {
                dataGridView1.Rows.Add(item.idtipoCusto, item.tipoCusto);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox2.Text))
            {
                bll.tipoCusto.tipoCusto = textBox2.Text.Trim().Replace("'", "");
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.tipoCusto.idtipoCusto = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.tipoCusto.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Tipo Custo com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";

                    bll.tipoCusto.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Tipo Custo com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarTipoCusto")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idtipoCusto"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["tipoCusto"].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarTipoCusto")
            {
                bll.tipoCusto.idtipoCusto = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idtipoCusto"].Value.ToString());
                bll.tipoCusto.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado Tipo Custo com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
