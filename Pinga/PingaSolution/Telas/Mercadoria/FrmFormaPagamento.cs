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
    public partial class FrmFormaPagamento : Form
    {
        Bll bll = new Bll("Forma_Pagamento");
        public FrmFormaPagamento()
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
                bll.formaPagamento.formaPagamento = textBox2.Text.Trim().Replace("'", "");
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.formaPagamento.idformaPagamento = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.formaPagamento.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Forma de Pagamento com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";

                    bll.formaPagamento.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Forma de Pagamento com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmFormaPagamento_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdformaPagamento = new DataGridViewTextBoxColumn();
                columnIdformaPagamento.HeaderText = "ID Forma Pagamento";
                columnIdformaPagamento.Name = "idformaPagamento";
                columnIdformaPagamento.DataPropertyName = "idformaPagamento";
                columnIdformaPagamento.Visible = false;

                var columnFormaPagamento = new DataGridViewTextBoxColumn();
                columnFormaPagamento.HeaderText = "Forma Pagamento";
                columnFormaPagamento.Name = "formaPagamento";
                columnFormaPagamento.DataPropertyName = "formaPagamento";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarFormaPagamento";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarFormaPagamento";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdformaPagamento);
                dataGridView1.Columns.Add(columnFormaPagamento);
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

            foreach (var item in bll.formaPagamento.Visualizar())
            {
                dataGridView1.Rows.Add(item.idformaPagamento, item.formaPagamento);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarFormaPagamento")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idformaPagamento"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["formaPagamento"].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarFormaPagamento")
            {
                bll.formaPagamento.idformaPagamento = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idformaPagamento"].Value.ToString());
                bll.formaPagamento.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado Forma de Pagamento com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
