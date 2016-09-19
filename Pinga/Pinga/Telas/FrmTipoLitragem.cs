using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pinga.Telas
{
    public partial class FrmTipoLitragem : Form
    {
        public FrmTipoLitragem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && button1.Text == "Salvar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "INSERT INTO Pinga.tipo_litragem VALUES (NEWID(), @descricao)";
                        com.Parameters.AddWithValue("@descricao", textBox1.Text.Trim());
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                        textBox1.Clear();

                        PopularGrid();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro desconhecido ao salvar tipo litragem.", "salvar tipo litragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!string.IsNullOrEmpty(textBox1.Text) && button1.Text == "Editar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "UPDATE Pinga.tipo_litragem SET descricao = @descricao WHERE idtipo_litragem = @id";
                        com.Parameters.AddWithValue("@descricao", textBox1.Text.Trim());
                        com.Parameters.AddWithValue("@id", txtId.Text);
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                        textBox1.Clear();

                        PopularGrid();

                        button1.Text = "Salvar";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro desconhecido ao alterar tipo litragem.", "Alterar tipo litragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string sql = "SELECT descricao, idtipo_litragem FROM Pinga.tipo_litragem";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[2].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro desconhecido ao listar tipo litragem.", "Listar tipo litragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmTipoLitragem_Shown(object sender, EventArgs e)
        {
            PopularGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.ToString() != "0")
                {
                    button1.Text = "Editar";

                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
                    txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["idtipo_litragem"].Value.ToString();
                }
                else
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                        {
                            SqlCommand com = new SqlCommand("DELETE FROM Pinga.tipo_litragem WHERE idtipo_litragem = '" + dataGridView1.Rows[e.RowIndex].Cells["idtipo_litragem"].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();

                            PopularGrid();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro desconhecido ao apagar tipo litragem.", "Apagar tipo litragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}
