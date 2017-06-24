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
    public partial class FrmTipoLitragem : Form
    {
        Bll bll = new Bll("Tipo_Litragem");
        public FrmTipoLitragem()
        {
            InitializeComponent();
        }

        private void FrmTipoLitragem_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdtipoLitragem = new DataGridViewTextBoxColumn();
                columnIdtipoLitragem.HeaderText = "ID Tipo Litragem";
                columnIdtipoLitragem.Name = "idtipoLitragem";
                columnIdtipoLitragem.DataPropertyName = "idtipoLitragem";
                columnIdtipoLitragem.Visible = false;

                var columnTipoLitragem = new DataGridViewTextBoxColumn();
                columnTipoLitragem.HeaderText = "Tipo Litragem";
                columnTipoLitragem.Name = "tipoLitragem";
                columnTipoLitragem.DataPropertyName = "tipoLitragem";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarTipoLitragem";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarTipoLitragem";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdtipoLitragem);
                dataGridView1.Columns.Add(columnTipoLitragem);
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

            foreach (var item in bll.tipoLitragem.Visualizar())
            {
                dataGridView1.Rows.Add(item.idtipoLitragem, item.tipoLitragem);
            }
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
                bll.tipoLitragem.tipoLitragem = textBox2.Text.Trim().Replace("'", "");
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.tipoLitragem.idtipoLitragem = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.tipoLitragem.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Tipo Litragem com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";

                    bll.tipoLitragem.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Tipo Litragem com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarTipoLitragem")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idtipoLitragem"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["tipoLitragem"].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarTipoLitragem")
            {
                bll.tipoLitragem.idtipoLitragem= Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idtipoLitragem"].Value.ToString());
                bll.tipoLitragem.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado Tipo Litragem com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
