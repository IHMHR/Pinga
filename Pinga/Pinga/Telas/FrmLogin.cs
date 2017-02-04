using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using BLL;
using System.Collections.Generic;

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
                    Bll bll = new Bll();
                    bll.login.usuario = txtUser.Text;
                    bll.login.senha = txtPwd.Text;
                    var retorno = bll.login.logar();
                    if ((bool)retorno["Acao"])
                    {
                        foreach (KeyValuePair<string, string> dados in (Dictionary<string, string>)retorno["Dados"])
                        {
                        }


                        FrmMain main = new FrmMain();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(retorno["Mensagem"].ToString());
                    }
                }
                catch (Exception erro)
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

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            // Gestao Logins
            throw new NotImplementedException();
        }
    }
}
