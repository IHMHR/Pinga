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
    public partial class FrmCusto : Form
    {
        Bll bll = new Bll("Custo");
        public FrmCusto()
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

        private void FrmCusto_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdCusto = new DataGridViewTextBoxColumn();
                columnIdCusto.HeaderText = "ID Custo";
                columnIdCusto.Name = "idcusto";
                columnIdCusto.DataPropertyName = "idcusto";
                columnIdCusto.Visible = false;

                var columnValor = new DataGridViewTextBoxColumn();
                columnValor.HeaderText = "valor";
                columnValor.Name = "valor";
                columnValor.DataPropertyName = "valor";

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
                columnEditar.Name = "editarCusto";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarCusto";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdCusto);
                dataGridView1.Columns.Add(columnValor);
                dataGridView1.Columns.Add(columnIdtipoCusto);
                dataGridView1.Columns.Add(columnTipoCusto);
                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();

                comboBox1.DataSource = new Bll("Tipo_Custo").tipoCusto.Visualizar();
                comboBox1.DisplayMember = "tipoCusto";
                comboBox1.ValueMember = "idtipoCusto";
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

            foreach (var item in bll.custo.Visualizar())
            {
                dataGridView1.Rows.Add(item.idcusto, item.valor, item.tipoCustoIdtipoCusto.idtipoCusto, item.tipoCustoIdtipoCusto.tipoCusto);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1)
            {
                bll.custo.valor = decimal.Parse(textBox2.Text.Trim().Replace("'", ""));
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.custo.idcusto = Guid.Parse(textBox1.Text);
                }
                bll.custo.tipoCustoIdtipoCusto.idtipoCusto = Guid.Parse(comboBox1.SelectedValue.ToString());

                if (button1.Text == "Salvar")
                {
                    bll.custo.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Custo com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";
                    bll.custo.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Custo com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarCusto")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idcusto"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["valor"].Value.ToString();

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    bll.tipoCusto = (BLL.Classes.ClsTipoCusto)comboBox1.Items[i];
                    if (bll.tipoCusto.idtipoCusto.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idtipoCusto"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarCusto")
            {
                bll.custo.idcusto = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idcusto"].Value.ToString());
                bll.custo.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado custo com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
