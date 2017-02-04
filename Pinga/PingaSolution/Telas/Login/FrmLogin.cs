using System;
using System.Windows.Forms;
using BLL;
using System.Collections.Generic;

namespace PingaSolution.Telas.Login
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
                    Bll bll = new Bll("Login");
                    bll.login.usuario = txtUser.Text;
                    bll.login.senha = txtPwd.Text;
                    var retorno = bll.login.logar();
                    if ((bool)retorno["Acao"])
                    {
                        var temp = (Dictionary<string, string>)retorno["Dados"];
                        Classes.ClsGlobal.nome = temp["Nome"];
                        Classes.ClsGlobal.sobrenome = temp["SobreNome"];
                        Classes.ClsGlobal.idade = Convert.ToInt32(temp["Idade"]);

                        FrmMain main = new FrmMain();
                        main.Show();
                        this.Hide();
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
            //Telas.FrmUsuarios f = new Telas.FrmUsuarios();
            //f.Show();
            throw new NotImplementedException();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            // Gestao Logins
            throw new NotImplementedException();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
