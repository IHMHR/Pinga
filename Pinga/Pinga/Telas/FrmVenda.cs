using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pinga.Telas
{
    public partial class FrmVenda : Form
    {
        public FrmVenda()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                {
                    string sql = "SELECT idfase, descricao FROM Pinga.fase";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Situacao");
                    cmbFase.DisplayMember = "descricao";
                    cmbFase.ValueMember = "idfase";
                    cmbFase.DataSource = ds.Tables["Situacao"];

                    sql = "SELECT idparceiro, nome FROM Pinga.parceiro";
                    da = new SqlDataAdapter(sql, con);
                    ds = new DataSet();
                    da.Fill(ds, "parceiro");
                    cmbParceiro.DisplayMember = "nome";
                    cmbParceiro.ValueMember = "idparceiro";
                    cmbParceiro.DataSource = ds.Tables["parceiro"];

                    sql = "SELECT idforma_pagamento, descricao FROM Pinga.forma_pagamento";
                    da = new SqlDataAdapter(sql, con);
                    ds = new DataSet();
                    da.Fill(ds, "forma_pagamento");
                    cmbFormaPagamento.DisplayMember = "descricao";
                    cmbFormaPagamento.ValueMember = "idforma_pagamento";
                    cmbFormaPagamento.DataSource = ds.Tables["forma_pagamento"];

                    sql = "SELECT idcliente, nome FROM Pinga.cliente";
                    da = new SqlDataAdapter(sql, con);
                    ds = new DataSet();
                    da.Fill(ds, "cliente");
                    cmbCliente.DisplayMember = "nome";
                    cmbCliente.ValueMember = "idcliente";
                    cmbCliente.DataSource = ds.Tables["cliente"];
                    con.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Falha ao preencher os campos", "Preencher combo boxes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = -1;
            cmbFormaPagamento.SelectedIndex = -1;
            cmbParceiro.SelectedIndex = -1;
            cmbFase.SelectedIndex = -1;
            dtpDataVnd.Text = DateTime.Now.ToShortDateString();
        }

        private void FrmVenda_Shown(object sender, EventArgs e)
        {
            try
            {
                Classes.ClsGlobal.PopularGrid("");

                using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                {
                    string sql = "SELECT produto, quantidade, (p.descricao + N' - ' + quantidade) AS item FROM Pinga.estoque e INNER JOIN Pinga.produto p ON p.idproduto = e.produto";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "estoque");
                    listBox1.DataSource = ds.Tables["estoque"];
                    listBox1.DisplayMember = "item";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro desconhecido ao listar estoque.", "Listar estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDataGridView()
        {
            try
            {
                dataGridView1.DataSource = Classes.ClsGlobal.PopularGrid("SELECT * FROM Pinga.saida");
                //dataGridView1.Columns[10].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro desconhecido ao listar tipo litragem.", "Listar tipo litragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedIndex);
        }
    }
}
