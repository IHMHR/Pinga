using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Pinga
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPwd.Text) && !string.IsNullOrEmpty(txtUser.Text))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "SELECT 1 FROM adm.login WHERE lgn = @login AND pwd = @pwd AND ativo = 1;";
                        //com.CommandText = "SELECT 1 FROM adm.login WHERE lgn = @login AND pwd = @pwd AND ativo = 1 OR 1=1;";
                        com.Parameters.AddWithValue("@login", txtUser.Text.Trim().Replace("'", "\'"));
                        com.Parameters.AddWithValue("@pwd", Classes.ClsGlobal.CalculateSHA1(txtPwd.Text.Trim().Replace("'", "\'")));
                        con.Open();
                        com.Connection = con;
                        object result = com.ExecuteScalar();
                        con.Close();
                        con.Dispose();

                        if (result != null)
                        {
                            Classes.ClsGlobal.login = txtUser.Text;
                            FrmMain main = new FrmMain();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Senha ou usuário incorreto.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro desconhecido ao efetuar login.", "Erro login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe os dados para login corretamente.", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Telas.FrmUsuarios f = new Telas.FrmUsuarios();
            f.Show();
        }
    }
}
