namespace Pinga
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.userLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parceiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formaDePagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(996, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // userLabel
            // 
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(57, 17);
            this.userLabel.Text = "userLabel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.estoqueToolStripMenuItem,
            this.vendaToolStripMenuItem,
            this.parceiroToolStripMenuItem,
            this.formaDePagamentoToolStripMenuItem,
            this.unidadeToolStripMenuItem,
            this.proutoToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Cadastro";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // estoqueToolStripMenuItem
            // 
            this.estoqueToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.estoqueToolStripMenuItem.Name = "estoqueToolStripMenuItem";
            this.estoqueToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.estoqueToolStripMenuItem.Text = "Estoque";
            this.estoqueToolStripMenuItem.Click += new System.EventHandler(this.estoqueToolStripMenuItem_Click);
            // 
            // vendaToolStripMenuItem
            // 
            this.vendaToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.vendaToolStripMenuItem.Name = "vendaToolStripMenuItem";
            this.vendaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.vendaToolStripMenuItem.Text = "Venda";
            this.vendaToolStripMenuItem.Click += new System.EventHandler(this.vendaToolStripMenuItem_Click);
            // 
            // parceiroToolStripMenuItem
            // 
            this.parceiroToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.parceiroToolStripMenuItem.Name = "parceiroToolStripMenuItem";
            this.parceiroToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.parceiroToolStripMenuItem.Text = "Parceiro";
            this.parceiroToolStripMenuItem.Click += new System.EventHandler(this.parceiroToolStripMenuItem_Click);
            // 
            // formaDePagamentoToolStripMenuItem
            // 
            this.formaDePagamentoToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.formaDePagamentoToolStripMenuItem.Name = "formaDePagamentoToolStripMenuItem";
            this.formaDePagamentoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.formaDePagamentoToolStripMenuItem.Text = "Forma de Pagamento";
            this.formaDePagamentoToolStripMenuItem.Click += new System.EventHandler(this.formaDePagamentoToolStripMenuItem_Click);
            // 
            // unidadeToolStripMenuItem
            // 
            this.unidadeToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.unidadeToolStripMenuItem.Name = "unidadeToolStripMenuItem";
            this.unidadeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.unidadeToolStripMenuItem.Text = "Unidade";
            this.unidadeToolStripMenuItem.Click += new System.EventHandler(this.unidadeToolStripMenuItem_Click);
            // 
            // proutoToolStripMenuItem
            // 
            this.proutoToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.proutoToolStripMenuItem.Name = "proutoToolStripMenuItem";
            this.proutoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.proutoToolStripMenuItem.Text = "Produto";
            this.proutoToolStripMenuItem.Click += new System.EventHandler(this.proutoToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 548);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel userLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parceiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formaDePagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proutoToolStripMenuItem;
    }
}