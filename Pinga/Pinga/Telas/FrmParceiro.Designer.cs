namespace Pinga.Telas
{
    partial class FrmParceiro
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkCompra = new System.Windows.Forms.CheckBox();
            this.checkAtivo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Endereço = new System.Windows.Forms.GroupBox();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtCompl = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ApagarColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIdParceiro = new System.Windows.Forms.TextBox();
            this.txtIdEndereco = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.Endereço.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkCompra);
            this.groupBox1.Controls.Add(this.checkAtivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Endereço);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados cadastrais";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Parceiro já fez compra";
            // 
            // checkCompra
            // 
            this.checkCompra.AutoSize = true;
            this.checkCompra.Enabled = false;
            this.checkCompra.Location = new System.Drawing.Point(14, 68);
            this.checkCompra.Name = "checkCompra";
            this.checkCompra.Size = new System.Drawing.Size(15, 14);
            this.checkCompra.TabIndex = 10;
            this.checkCompra.UseVisualStyleBackColor = true;
            // 
            // checkAtivo
            // 
            this.checkAtivo.AutoSize = true;
            this.checkAtivo.Location = new System.Drawing.Point(14, 46);
            this.checkAtivo.Name = "checkAtivo";
            this.checkAtivo.Size = new System.Drawing.Size(15, 14);
            this.checkAtivo.TabIndex = 9;
            this.checkAtivo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parceria ativa";
            // 
            // Endereço
            // 
            this.Endereço.Controls.Add(this.txtUF);
            this.Endereço.Controls.Add(this.txtCidade);
            this.Endereço.Controls.Add(this.label9);
            this.Endereço.Controls.Add(this.label8);
            this.Endereço.Controls.Add(this.label7);
            this.Endereço.Controls.Add(this.label6);
            this.Endereço.Controls.Add(this.txtBairro);
            this.Endereço.Controls.Add(this.txtCompl);
            this.Endereço.Controls.Add(this.txtNum);
            this.Endereço.Controls.Add(this.label5);
            this.Endereço.Controls.Add(this.txtRua);
            this.Endereço.Controls.Add(this.label4);
            this.Endereço.Location = new System.Drawing.Point(206, 12);
            this.Endereço.Name = "Endereço";
            this.Endereço.Size = new System.Drawing.Size(294, 85);
            this.Endereço.TabIndex = 7;
            this.Endereço.TabStop = false;
            this.Endereço.Text = "Endereço";
            // 
            // txtUF
            // 
            this.txtUF.Enabled = false;
            this.txtUF.Location = new System.Drawing.Point(210, 56);
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(84, 20);
            this.txtUF.TabIndex = 11;
            this.txtUF.Text = "MG";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(73, 56);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(104, 20);
            this.txtCidade.TabIndex = 10;
            this.txtCidade.Text = "Belo Horizonte";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "UF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Cidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Bairro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Complemento";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(218, 34);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(76, 20);
            this.txtBairro.TabIndex = 5;
            // 
            // txtCompl
            // 
            this.txtCompl.Location = new System.Drawing.Point(73, 34);
            this.txtCompl.Name = "txtCompl";
            this.txtCompl.Size = new System.Drawing.Size(107, 20);
            this.txtCompl.TabIndex = 4;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(243, 13);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(45, 20);
            this.txtNum.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Número";
            // 
            // txtRua
            // 
            this.txtRua.Location = new System.Drawing.Point(73, 13);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(114, 20);
            this.txtRua.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Logradouro";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(52, 15);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(148, 20);
            this.txtNome.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIdEndereco);
            this.groupBox2.Controls.Add(this.txtIdParceiro);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(2, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 153);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clientes Cadastrados";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApagarColumn});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(488, 128);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ApagarColumn
            // 
            this.ApagarColumn.HeaderText = "Apagar";
            this.ApagarColumn.Name = "ApagarColumn";
            this.ApagarColumn.ReadOnly = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(425, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Fechar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Limpar Tela";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIdParceiro
            // 
            this.txtIdParceiro.Location = new System.Drawing.Point(363, 109);
            this.txtIdParceiro.Name = "txtIdParceiro";
            this.txtIdParceiro.Size = new System.Drawing.Size(30, 20);
            this.txtIdParceiro.TabIndex = 16;
            this.txtIdParceiro.Visible = false;
            // 
            // txtIdEndereco
            // 
            this.txtIdEndereco.Location = new System.Drawing.Point(402, 109);
            this.txtIdEndereco.Name = "txtIdEndereco";
            this.txtIdEndereco.Size = new System.Drawing.Size(30, 20);
            this.txtIdEndereco.TabIndex = 17;
            this.txtIdEndereco.Visible = false;
            // 
            // FrmParceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 290);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmParceiro";
            this.Text = "FrmParceiro";
            this.Shown += new System.EventHandler(this.FrmParceiro_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Endereço.ResumeLayout(false);
            this.Endereço.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkCompra;
        private System.Windows.Forms.CheckBox checkAtivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox Endereço;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtCompl;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn ApagarColumn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIdEndereco;
        private System.Windows.Forms.TextBox txtIdParceiro;

    }
}