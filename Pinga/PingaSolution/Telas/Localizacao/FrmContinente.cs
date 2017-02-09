using System;
using System.Windows.Forms;
using BLL;
using System.Drawing;

namespace PingaSolution.Telas.Localizacao
{
    public partial class FrmContinente : Form
    {
        Bll bll = new Bll("Continente");

        public FrmContinente()
        {
            InitializeComponent();
        }

        private void FrmContinente_Load(object sender, EventArgs e)
        {
            try
            {
                fillDataGrid();

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarContinente";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarContinente";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                // popular combo box
                comboBox1.DataSource = new Bll("Tipo_Continente").tipoContinente.Visualizar();
                comboBox1.DisplayMember = "tipoContinente";
                comboBox1.ValueMember = "idtipoContinente";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            var lista = bll.continente.Visualizar();

            var columnIdcontinente = new DataGridViewTextBoxColumn();
            columnIdcontinente.HeaderText = "idcontinente";
            columnIdcontinente.Name = "idcontinente";
            columnIdcontinente.DataPropertyName = "idcontinente";
            columnIdcontinente.Visible = false;

            var columnIdtipoContinente = new DataGridViewTextBoxColumn();
            columnIdtipoContinente.HeaderText = "idtipoContinente";
            columnIdtipoContinente.Name = "idtipoContinente";
            columnIdtipoContinente.DataPropertyName = "idtipoContinente";
            columnIdtipoContinente.Visible = false;

            var columnContinente = new DataGridViewTextBoxColumn();
            columnContinente.HeaderText = "Continente";
            columnContinente.Name = "continente";
            columnContinente.DataPropertyName = "continente";

            var columnTipoContinente = new DataGridViewTextBoxColumn();
            columnTipoContinente.HeaderText = "Tipo Continente";
            columnTipoContinente.Name = "tipoContinente";
            columnTipoContinente.DataPropertyName = "tipoContinente";

            var columnTipoContinenteAtivo = new DataGridViewCheckBoxColumn();
            columnTipoContinenteAtivo.HeaderText = "Tipo Continente Ativo";
            columnTipoContinenteAtivo.Name = "tipoContinenteAtivo";
            columnTipoContinenteAtivo.DataPropertyName = "tipoContinenteAtivo";

            dataGridView1.Columns.Add(columnIdcontinente);
            dataGridView1.Columns.Add(columnIdtipoContinente);
            dataGridView1.Columns.Add(columnContinente);
            dataGridView1.Columns.Add(columnTipoContinente);
            dataGridView1.Columns.Add(columnTipoContinenteAtivo);

            foreach (var item in lista)
            {
                dataGridView1.Rows.Add(item.idcontinente, item.tipoContinenteIdtipoContinente.idtipoContinente, item.continente, item.tipoContinenteIdtipoContinente.tipoContinente, item.tipoContinenteIdtipoContinente.ativo);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.ClsGlobal.ClearForm(groupBox1);
            button1.Text = "Salvar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1)
            {
                bll.continente.continente = textBox2.Text.Trim().Replace("'", "");
                bll.continente.tipoContinenteIdtipoContinente.idtipoContinente = Guid.Parse(comboBox1.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.continente.idcontinente = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.continente.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo tipo continente com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";
                    bll.continente.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado tipo continente com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarContinente")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idcontinente"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["continente"].Value.ToString();
                // make selection on combobox
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    bll.tipoContinente = (BLL.Classes.ClsTipoContinente) comboBox1.Items[i];
                    if (bll.tipoContinente.idtipoContinente.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idtipoContinente"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarContinente")
            {
                bll.continente.idcontinente = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idcontinente"].Value.ToString());
                bll.continente.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado continente com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
