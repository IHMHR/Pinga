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
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDescricao.Clear();
            txtListragem.Clear();
            txtValorUnitario.Clear();
            cmbUnidade.SelectedIndex = -1;  
            checkVendendo.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDescricao.Text) && !string.IsNullOrEmpty(txtListragem.Text)
                    && !string.IsNullOrEmpty(txtValorUnitario.Text) && button1.Text == "Salvar")
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "INSERT INTO Pinga.produto VALUES (NEWID(), @descricao, @litragem, @tipo_litragem, @vendedo, @valor_unitario, GETDATE(), NULL);";
                        com.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@litragem", txtListragem.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@tipo_litragem", cmbUnidade.SelectedValue.ToString());
                        com.Parameters.AddWithValue("@vendedo", checkVendendo.Checked ? "1" : "0");
                        com.Parameters.AddWithValue("@valor_unitario", txtValorUnitario.Text.Trim().Replace("'", "\'").Replace(",", "."));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();

                        button2_Click(sender, new EventArgs());

                        FillDataGrid();
                    }
                }
                else if (!string.IsNullOrEmpty(txtDescricao.Text) && !string.IsNullOrEmpty(txtListragem.Text)
                        && !string.IsNullOrEmpty(txtValorUnitario.Text) && button1.Text == "Editar")
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "UPDATE Pinga.produto SET descricao = @descricao, litragem = @litragem, tipo_litragem = @tipo_litragem, vendedo = @vendedo, valor_unitario = @valor_unitario, modified = GETDATE() WHERE idproduto = " + txtId.Text;
                        com.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@litragem", txtListragem.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@tipo_litragem", cmbUnidade.SelectedValue.ToString());
                        com.Parameters.AddWithValue("@vendedo", checkVendendo.Checked ? "1" : "0");
                        com.Parameters.AddWithValue("@valor_unitario", txtValorUnitario.Text.Trim().Replace("'", "\'").Replace(",", "."));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();

                        button1.Text = "Salvar";

                        button2_Click(sender, new EventArgs());

                        FillDataGrid();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Informe os dados corretamente.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmProduto_Shown(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            dataGridView1.DataSource = Classes.ClsGlobal.PopularGrid("SELECT idproduto, p.descricao, litragem, tl.descricao AS Unidade, CASE WHEN p.vendendo = 1 THEN 'Vendendo' ELSE 'Fora do mercado' END AS Vendendo, p.valor_unitario FROM Pinga.produto p INNER JOIN Pinga.tipo_litragem tl ON p.tipo_litragem = tl.idtipo_litragem");
            dataGridView1.Columns[1].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.ToString() != "0")
                {
                    button1.Text = "Editar";

                    txtDescricao.Text = dataGridView1.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
                    txtListragem.Text = dataGridView1.Rows[e.RowIndex].Cells["litragem"].Value.ToString();
                    txtValorUnitario.Text = dataGridView1.Rows[e.RowIndex].Cells["valor_unitario"].Value.ToString();
                    cmbUnidade.SelectedIndex = cmbUnidade.Items.IndexOf(dataGridView1.Rows[e.RowIndex].Cells["litragem"].Value);
                    
                    if (dataGridView1.Rows[e.RowIndex].Cells["Vendendo"].Value.ToString().Equals("Vendendo"))
                    {
                        checkVendendo.Checked = false;
                    }
                    else
                    {
                        checkVendendo.Checked = true;
                    }
                }
                else
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                        {
                            SqlCommand com = new SqlCommand("DELETE FROM Pinga.produto WHERE idproduto = '" + dataGridView1.Rows[e.RowIndex].Cells["idproduto"].Value.ToString() + "'", con);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();

                            FillDataGrid();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro desconhecido ao apagar cliente.", "Apagar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}
