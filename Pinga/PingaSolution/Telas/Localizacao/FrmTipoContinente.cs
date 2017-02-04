using System;
using System.Windows.Forms;
using BLL;

namespace PingaSolution.Telas.Localizacao
{
    public partial class FrmTipoContinente : Form
    {
        Bll bll = new Bll("Tipo_Continente");

        public FrmTipoContinente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && (radioButton1.Checked || radioButton2.Checked))
            {
                bll.tipoContinente.tipoContinente = textBox2.Text.Trim().Replace("'", "");
                bll.tipoContinente.ativo = radioButton1.Checked ? true : false;
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.tipoContinente.idtipoContinente = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                { 
                    bll.tipoContinente.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo tipo continente com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";
                    bll.tipoContinente.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado tipo continente com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                textBox1.Clear();
                textBox2.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmTipoContinente_Load(object sender, EventArgs e)
        {
            try
            {
                fillDataGrid();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Tipo de Continente";
                dataGridView1.Columns[2].HeaderText = "Ativado";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarTipoContinente";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarTipoContinente";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.AddRange(columnEditar);
                dataGridView1.Columns.AddRange(columnApagar);
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            dataGridView1.DataSource = bll.tipoContinente.Visualizar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarTipoContinente")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idtipoContinente"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["tipoContinente"].Value.ToString();
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells["ativo"].Value)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarTipoContinente")
            {
                bll.tipoContinente.idtipoContinente = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idtipoContinente"].Value.ToString());
                bll.tipoContinente.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado tipo continente com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
