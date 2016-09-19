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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "INSERT INTO adm.login (lgn, pwd, ativo, created) VALUES (@login, @senha, 1, GETDATE())";
                        com.Parameters.AddWithValue("@login", textBox1.Text);
                        com.Parameters.AddWithValue("@senha", Classes.ClsGlobal.CalculateSHA1(textBox2.Text));
                        com.Connection = con;
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message.ToString());
                }
                finally
                {
                    this.Close();
                }
            }
        }
    }
}
