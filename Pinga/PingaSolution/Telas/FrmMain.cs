using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingaSolution.Telas
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Olá {0} {1}, seja bem-vindo !", Classes.ClsGlobal.nome, Classes.ClsGlobal.sobrenome);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tipoContinenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmTipoContinente))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmTipoContinente();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void continenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmContinente))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmContinente();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void paisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmPais))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmPais();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmEstado))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmEstado();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmCidade))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmCidade();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void bairroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmBairro))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmBairro();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void tipoLogradouroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmTipoLogradouro))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmTipoLogradouro();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void tipoComplementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Localizacao.FrmTipoComplemento))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Localizacao.FrmTipoComplemento();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void cadastroProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Mercadoria.FrmProduto))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Mercadoria.FrmProduto();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void tipoCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Mercadoria.FrmTipoCusto))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Mercadoria.FrmTipoCusto();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void custosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Mercadoria.FrmCusto))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Mercadoria.FrmCusto();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Mercadoria.FrmFormaPagamento))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Mercadoria.FrmFormaPagamento();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void tipoLitragemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Telas.Mercadoria.FrmTipoLitragem))
                {
                    form.Activate();
                    return;
                }
            }

            Form newForm = new Telas.Mercadoria.FrmTipoLitragem();
            newForm.MdiParent = this;
            newForm.Show();
        }
    }
}
