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
    public partial class FrmFormaPagamento : Form
    {
        public FrmFormaPagamento()
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
                        com.CommandText = "INSERT INTO Pinga.forma_pagamento VALUES (NEWID(), @descricao, GETDATE(), NULL)";
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
                    MessageBox.Show("Erro desconhecido ao salvar forma de pagamento.", "salvar forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(!string.IsNullOrEmpty(textBox1.Text) && button1.Text == "Editar")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "UPDATE Pinga.forma_pagamento SET descricao = @descricao, modified = GETDATE() WHERE idforma_pagamento = @id";
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
                    MessageBox.Show("Erro desconhecido ao alterar forma de pagamento.", "Alterar forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string sql = "SELECT descricao, idforma_pagamento FROM Pinga.forma_pagamento";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[2].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro desconhecido ao listar forma de pagamento.", "Listar forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.ToString() != "0")
                {
                    button1.Text = "Editar";

                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
                    txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["idforma_pagamento"].Value.ToString();
                }
                else
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                        {
                            SqlCommand com = new SqlCommand("DELETE FROM Pinga.forma_pagamento WHERE idforma_pagamento = '" + dataGridView1.Rows[e.RowIndex].Cells["idforma_pagamento"].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();

                            PopularGrid();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro desconhecido ao apagar forma de pagamento.", "Apagar forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void FrmFormaPagamento_Shown(object sender, EventArgs e)
        {
            PopularGrid();
        }
    }
}
