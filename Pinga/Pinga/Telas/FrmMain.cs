using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinga
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            userLabel.Text = Classes.ClsGlobal.login;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.FrmCliente))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.FrmCliente();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.FrmEstoque))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.FrmEstoque();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.FrmVenda))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.FrmVenda();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void parceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.FrmParceiro))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.FrmParceiro();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.FrmFormaPagamento))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.FrmFormaPagamento();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void unidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.FrmTipoLitragem))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.FrmTipoLitragem();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void proutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.FrmProduto))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.FrmProduto();
            newForm.MdiParent = this;
            newForm.Show();
        }
    }
}
