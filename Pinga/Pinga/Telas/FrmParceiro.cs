using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinga.Telas
{
    public partial class FrmParceiro : Form
    {
        public FrmParceiro()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBairro.Clear();
            txtCidade.Clear();
            txtCompl.Clear();
            txtNome.Clear();
            txtNum.Clear();
            txtRua.Clear();
            txtUF.Clear();
            checkCompra.Checked = false;
            checkAtivo.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtCidade.Text)
                && !string.IsNullOrEmpty(txtCompl.Text) && !string.IsNullOrEmpty(txtNome.Text)
                && !string.IsNullOrEmpty(txtNum.Text) && !string.IsNullOrEmpty(txtRua.Text) && button1.Text == "Salvar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "INSERT INTO Pinga.endereco VALUES (NEWID(), @rua, @num, @compl, @bairro, @cidade, 'MG', 'Brasil', GETDATE(), NULL);";
                        com.Parameters.AddWithValue("@rua", txtRua.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@num", txtNum.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@compl", txtCompl.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@bairro", txtBairro.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@cidade", txtCidade.Text.Trim().Replace("'", "\'"));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();

                        com.CommandText = "INSERT INTO Pinga.parceiro VALUES (NEWID(), @nome, (SELECT TOP 1 idendereco FROM Pinga.endereco ORDER BY created DESC), @ativo, GETDATE(), NULL)";
                        com.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                        com.Parameters.AddWithValue("@ativo", checkAtivo.Checked == true ? "1" : "0");
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();

                        button2_Click(this, new EventArgs());

                        PopularGrid();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Falha ao salvar parceiro.", "Salvar Parceiro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (!string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtCidade.Text)
                && !string.IsNullOrEmpty(txtCompl.Text) && !string.IsNullOrEmpty(txtNome.Text)
                && !string.IsNullOrEmpty(txtNum.Text) && !string.IsNullOrEmpty(txtRua.Text) && button1.Text == "Editar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "UPDATE Pinga.endereco SET logradouro = @rua, numero = @num, complemento = @compl, bairro = @bairro, cidade = @cidade, modified = GETDATE()";
                        com.Parameters.AddWithValue("@rua", txtRua.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@num", txtNum.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@compl", txtCompl.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@bairro", txtBairro.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@cidade", txtCidade.Text.Trim().Replace("'", "\'"));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();

                        com.CommandText = "UPDATE Pinga.parceiro SET nome = @nome, ativo = @ativo, modified = GETDATE()";
                        com.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                        com.Parameters.AddWithValue("@ativo", checkAtivo.Checked == true ? "1" : "0");
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();

                        button1.Text = "Salvar";

                        button2_Click(this, new EventArgs());

                        PopularGrid();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Falha ao alterar parceiro.", "Alterar Parceiro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string sql = "SELECT p.idparceiro, p.nome, CASE WHEN p.ativo = 1 THEN 'Sim' ELSE 'Não' END AS ativo, e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.uf, s.parceiro FROM Pinga.parceiro p INNER JOIN Pinga.endereco e ON e.idendereco = p.endereco LEFT JOIN Pinga.saida s ON s.cliente = p.idparceiro";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro desconhecido ao listar clientes.", "Listar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.ToString() != "0")
                {
                    button1.Text = "Editar";

                    txtNome.Text = dataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                    txtBairro.Text = dataGridView1.Rows[e.RowIndex].Cells["bairro"].Value.ToString(); ;
                    txtCidade.Text = dataGridView1.Rows[e.RowIndex].Cells["cidade"].Value.ToString(); ;
                    txtCompl.Text = dataGridView1.Rows[e.RowIndex].Cells["complemento"].Value.ToString(); ;
                    txtNum.Text = dataGridView1.Rows[e.RowIndex].Cells["numero"].Value.ToString(); ;
                    txtRua.Text = dataGridView1.Rows[e.RowIndex].Cells["logradouro"].Value.ToString();
                    if (dataGridView1.Rows[e.RowIndex].Cells["ativo"].Value.ToString() == "Sim")
                    {
                        checkAtivo.Checked = true;
                    }
                    else
                    {
                        checkAtivo.Checked = false;
                    }
                    if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells["parceiro"].Value.ToString()))
                    {
                        checkCompra.Checked = false;
                    }
                    else
                    {
                        checkCompra.Checked = true;
                    }
                    txtUF.Text = "MG";
                }
                else
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                        {
                            SqlCommand com = new SqlCommand("DELETE FROM Pinga.parceiro WHERE idparceiro = '" + dataGridView1.Rows[e.RowIndex].Cells["idparceiro"].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();

                            PopularGrid();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro desconhecido ao apagar parceiro.", "Apagar parceiro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void FrmParceiro_Shown(object sender, EventArgs e)
        {
            PopularGrid();
        }
    }
}
