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
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            button1.Text = "Salvar";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
