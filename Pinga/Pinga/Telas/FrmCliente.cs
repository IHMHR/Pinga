using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pinga.Telas
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

                        com.CommandText = "INSERT INTO Pinga.cliente VALUES (NEWID(), @nome, (SELECT TOP 1 idendereco FROM Pinga.endereco ORDER BY created DESC), @visitado, GETDATE(), NULL);";
                        com.Parameters.AddWithValue("@nome", txtNome.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@visitado", checkVisitado.Checked == true ? "1" : "0");
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
                    MessageBox.Show("Erro desconhecido ao cadastrar cliente.", "Salvar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(!string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtCidade.Text)
                && !string.IsNullOrEmpty(txtCompl.Text) && !string.IsNullOrEmpty(txtNome.Text)
                && !string.IsNullOrEmpty(txtNum.Text) && !string.IsNullOrEmpty(txtRua.Text) && button1.Text == "Editar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "UPDATE Pinga.endereco SET logradouro = @rua, numero = @num, complemento = @compl, bairro = @bairro, cidade = @cidade, modified = GETDATE();";
                        com.Parameters.AddWithValue("@rua", txtRua.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@num", txtNum.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@compl", txtCompl.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@bairro", txtBairro.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@cidade", txtCidade.Text.Trim().Replace("'", "\'"));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();

                        com.CommandText = "UPDATE Pinga.cliente SET nome = @nome, visitado = @visitado, modified = GETDATE();";
                        com.Parameters.AddWithValue("@nome", txtNome.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@visitado", checkVisitado.Checked == true ? "1" : "0");
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();

                        button2_Click(this, new EventArgs());

                        PopularGrid();

                        button1.Text = "Salvar";
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Erro desconhecido ao alterar cliente.", "Alterar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe os dados corretamente.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            checkVisitado.Checked = false;
        }

        private void FrmCliente_Shown(object sender, EventArgs e)
        {
            PopularGrid();
        }

        private void PopularGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                {
                    string sql = "SELECT c.nome AS 'Nome Cliente', CASE WHEN c.visitado = 1 THEN 'Sim' ELSE 'Não' END AS 'Cliente Visitado',CONVERT(CHAR(10), c.created, 103) AS 'Data Cadastro', e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.uf, c.idcliente, e.idendereco, s.cliente AS 'Vnd' FROM pingaDB.Pinga.cliente c INNER JOIN pingaDB.Pinga.endereco e ON c.endereco = e.idendereco LEFT JOIN pingaDB.Pinga.saida s ON s.cliente = c.idcliente";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                }
            }
            catch(Exception)
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

                    txtNome.Text = dataGridView1.Rows[e.RowIndex].Cells["Nome Cliente"].Value.ToString();
                    txtBairro.Text = dataGridView1.Rows[e.RowIndex].Cells["bairro"].Value.ToString(); ;
                    txtCidade.Text = dataGridView1.Rows[e.RowIndex].Cells["cidade"].Value.ToString(); ;
                    txtCompl.Text = dataGridView1.Rows[e.RowIndex].Cells["complemento"].Value.ToString(); ;
                    txtNum.Text = dataGridView1.Rows[e.RowIndex].Cells["numero"].Value.ToString(); ;
                    txtRua.Text = dataGridView1.Rows[e.RowIndex].Cells["logradouro"].Value.ToString();
                    if (dataGridView1.Rows[e.RowIndex].Cells["Cliente Visitado"].Value.ToString() == "Sim")
                    {
                        checkVisitado.Checked = true;
                    }
                    else
                    {
                        checkVisitado.Checked = false;
                    }
                    txtIdCliente.Text = dataGridView1.Rows[e.RowIndex].Cells["idcliente"].Value.ToString();
                    txtIdEndereco.Text = dataGridView1.Rows[e.RowIndex].Cells["idendereco"].Value.ToString();
                    if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells["Vnd"].Value.ToString()))
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
