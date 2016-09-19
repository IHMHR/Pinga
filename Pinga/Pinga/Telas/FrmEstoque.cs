using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Pinga.Telas
{
    public partial class FrmEstoque : Form
    {
        public FrmEstoque()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtLitragem.Clear();
            txtValor.Clear();
            cmbUnidade.SelectedIndex = -1;
            dtpData.Text = DateTime.Now.ToShortDateString().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLitragem.Text) && !string.IsNullOrEmpty(txtValor.Text)
                && cmbUnidade.SelectedIndex > -1 && button1.Text == "Salvar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "INSERT INTO Pinga.entrada VALUES (NEWID(), @dt, @litragem, @tipo_litragem, @valor, GETDATE(), NULL)";
                        com.Parameters.AddWithValue("@dt", DateTime.Parse(dtpData.Text).ToString("yyyy-MM-dd"));
                        com.Parameters.AddWithValue("@litragem",txtLitragem.Text.Trim());
                        com.Parameters.AddWithValue("@tipo_litragem",cmbUnidade.SelectedIndex.ToString());
                        com.Parameters.AddWithValue("@valor",txtValor.Text.Trim().Replace(",","."));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                        button2_Click(this, new EventArgs());

                        PopularGrid();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Erro desconhecido ao cadastrar estoque.", "Salvar estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!string.IsNullOrEmpty(txtLitragem.Text) && !string.IsNullOrEmpty(txtValor.Text)
                && cmbUnidade.SelectedIndex > -1 && button1.Text == "Editar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "UPDATE Pinga.entrada SET data = @dt, litragem = @litragem, tipo_litragem = @tipo_litragem, valor = @valor, modified = GETDATE()";
                        com.Parameters.AddWithValue("@dt", DateTime.Parse(dtpData.Text).ToString("yyyy-MM-dd"));
                        com.Parameters.AddWithValue("@litragem", txtLitragem.Text.Trim());
                        com.Parameters.AddWithValue("@tipo_litragem", cmbUnidade.SelectedIndex.ToString());
                        com.Parameters.AddWithValue("@valor", txtValor.Text.Trim().Replace(",", "."));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();

                        button1.Text = "Salvar";

                        button2_Click(this, new EventArgs());

                        PopularGrid();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro desconhecido ao editar estoque.", "Alterar estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe os dados corretamente.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PopularGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                {
                    string sql = "SELECT";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Erro desconhecido ao listar estoque.", "Listar estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmEstoque_Shown(object sender, EventArgs e)
        {
            PopularGrid();

            //using (SqlConnection conn = new SqlConnection(@"Data Source=SHARKAWY;Initial Catalog=Booking;Persist Security Info=True;User ID=sa;Password=123456"))
            using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
            {
                try
                {
                    string sql = "SELECT idtipo_litragem, descricao FROM Pinga.tipo_litragem";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tipo_litragem");
                    cmbUnidade.DisplayMember = "descricao";
                    cmbUnidade.ValueMember = "idtipo_litragem";
                    cmbUnidade.DataSource = ds.Tables["tipo_litragem"];
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occured!");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.ToString() != "0")
                {
                    button1.Text = "Editar";

                    txtLitragem.Text = dataGridView1.Rows[e.RowIndex].Cells[""].Value.ToString();
                }
                else
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                        {
                            SqlCommand com = new SqlCommand("DELETE FROM Pinga.cliente WHERE idcliente = '" + dataGridView1.Rows[e.RowIndex].Cells["idcliente"].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();

                            PopularGrid();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro desconhecido ao apagar cliente.", "Apagar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception)
            { }
        }

    }
}
