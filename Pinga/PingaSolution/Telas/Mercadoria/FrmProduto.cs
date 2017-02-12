using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace PingaSolution.Telas.Mercadoria
{
    public partial class FrmProduto : Form
    {
        Bll bll = new Bll("Produto");
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdProduto = new DataGridViewTextBoxColumn();
                columnIdProduto.HeaderText = "ID Produto";
                columnIdProduto.Name = "idproduto";
                columnIdProduto.DataPropertyName = "idproduto";
                columnIdProduto.Visible = false;

                var columnProduto = new DataGridViewTextBoxColumn();
                columnProduto.HeaderText = "Produto";
                columnProduto.Name = "produto";
                columnProduto.DataPropertyName = "produto";

                var columnIdTipoLitragem = new DataGridViewTextBoxColumn();
                columnIdTipoLitragem.HeaderText = "ID Tipo Litragem";
                columnIdTipoLitragem.Name = "idtipoLitragem";
                columnIdTipoLitragem.DataPropertyName = "idtipoLitragem";
                columnIdTipoLitragem.Visible = false;

                var columnTipoLitragem = new DataGridViewTextBoxColumn();
                columnTipoLitragem.HeaderText = "Tipo Litragem";
                columnTipoLitragem.Name = "tipoLitragem";
                columnTipoLitragem.DataPropertyName = "tipoLitragem";

                var columnLitragem = new DataGridViewTextBoxColumn();
                columnLitragem.HeaderText = "Litragem";
                columnLitragem.Name = "litragem";
                columnLitragem.DataPropertyName = "litragem";

                var columnVendendo = new DataGridViewCheckBoxColumn();
                columnVendendo.HeaderText = "Produto a Venda";
                columnVendendo.Name = "vendendo";
                columnVendendo.DataPropertyName = "vendendo";

                var columnValorUnitario = new DataGridViewTextBoxColumn();
                columnValorUnitario.HeaderText = "Valor Unitário";
                columnValorUnitario.Name = "valorUnitario";
                columnValorUnitario.DataPropertyName = "valorUnitario";

                var columnIdProdutoQuantidade = new DataGridViewTextBoxColumn();
                columnIdProdutoQuantidade.HeaderText = "ID Produto Quantidade";
                columnIdProdutoQuantidade.Name = "idprodutoQuantidade";
                columnIdProdutoQuantidade.DataPropertyName = "idprodutoQuantidade";
                columnIdProdutoQuantidade.Visible = false;

                var columnProdutoQuantidade = new DataGridViewTextBoxColumn();
                columnProdutoQuantidade.HeaderText = "Produto Quantidade";
                columnProdutoQuantidade.Name = "produtoQuantidade";
                columnProdutoQuantidade.DataPropertyName = "produtoQuantidade";

                var columnQuantidadeMinima = new DataGridViewTextBoxColumn();
                columnQuantidadeMinima.HeaderText = "Produto Quantidade Minima";
                columnQuantidadeMinima.Name = "quantidadaMinima";
                columnQuantidadeMinima.DataPropertyName = "quantidadaMinima";

                var columnQuantidadeMaxima = new DataGridViewTextBoxColumn();
                columnQuantidadeMaxima.HeaderText = "Produto Quantidade Máxima";
                columnQuantidadeMaxima.Name = "quantidadaMaxima";
                columnQuantidadeMaxima.DataPropertyName = "quantidadaMaxima";

                var columnQuantidadeRecomendada = new DataGridViewTextBoxColumn();
                columnQuantidadeRecomendada.HeaderText = "Produto Quantidade Recomendada";
                columnQuantidadeRecomendada.Name = "quantidadaRecomendada";
                columnQuantidadeRecomendada.DataPropertyName = "quantidadaRecomendada";

                var columnQuantidadeSolicitarCompra = new DataGridViewTextBoxColumn();
                columnQuantidadeSolicitarCompra.HeaderText = "Produto Quantidade Solicitar Compra";
                columnQuantidadeSolicitarCompra.Name = "quantidadaSolicitarCompra";
                columnQuantidadeSolicitarCompra.DataPropertyName = "quantidadaSolicitarCompra";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarProduto";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarProduto";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdProduto);
                dataGridView1.Columns.Add(columnProduto);
                dataGridView1.Columns.Add(columnVendendo);
                dataGridView1.Columns.Add(columnIdTipoLitragem);
                dataGridView1.Columns.Add(columnTipoLitragem);
                dataGridView1.Columns.Add(columnLitragem);
                dataGridView1.Columns.Add(columnValorUnitario);
                dataGridView1.Columns.Add(columnIdProdutoQuantidade);
                dataGridView1.Columns.Add(columnQuantidadeMinima);
                dataGridView1.Columns.Add(columnQuantidadeMaxima);
                dataGridView1.Columns.Add(columnQuantidadeRecomendada);
                dataGridView1.Columns.Add(columnQuantidadeSolicitarCompra);
                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();

                // popular combo box
                comboBox1.DataSource = new Bll("Tipo_Litragem").tipoLitragem.Visualizar();
                comboBox1.DisplayMember = "tipoLitragem";
                comboBox1.ValueMember = "idtipoLitragem";
                comboBox1.SelectedIndex = -1;

                // popular combo box
                comboBox2.DataSource = new Bll("Produto_Quantidade").produtoQuantidade.Visualizar();
                comboBox2.DisplayMember = "quantidadeMaxima";
                comboBox2.ValueMember = "idprodutoQuantidade";
                comboBox2.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in bll.produto.Visualizar())
            {
                dataGridView1.Rows.Add(item.idproduto, item.produto, item.vendendo, item.tipoLitragemIdtipoLitragem.idtipoLitragem, item.tipoLitragemIdtipoLitragem.tipoLitragem, item.litragem, item.valorUnitario, item.produtoQuantidadeIdprodutoQuantidade.idprodutoQuantidade, item.produtoQuantidadeIdprodutoQuantidade.quantidadeMinima, item.produtoQuantidadeIdprodutoQuantidade.quantidadeMaxima, item.produtoQuantidadeIdprodutoQuantidade.quantidadeRecomendaEstoque, item.produtoQuantidadeIdprodutoQuantidade.quantidadeSolicitarCompra);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.ClsGlobal.ClearForm(groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                bll.produto.produto = textBox2.Text.Trim().Replace("'", "");
                bll.produto.vendendo = checkBox1.Checked;
                bll.produto.litragem = int.Parse(textBox3.Text.Trim().Replace(",", "."));
                bll.produto.valorUnitario = decimal.Parse(textBox4.Text.Trim().Replace("'", ""));
                bll.produto.tipoLitragemIdtipoLitragem.idtipoLitragem = Guid.Parse(comboBox1.SelectedValue.ToString());
                bll.produto.produtoQuantidadeIdprodutoQuantidade.idprodutoQuantidade = Guid.Parse(comboBox2.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.produto.idproduto = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.produto.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado novo Produto com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    button1.Text = "Salvar";

                    bll.produto.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Produto com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarProduto")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idproduto"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["produto"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["litragem"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["valorUnitario"].Value.ToString();
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells["vendendo"].Value)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    bll.tipoLitragem = (BLL.Classes.ClsTipoLitragem)comboBox1.Items[i];
                    if (bll.tipoLitragem.idtipoLitragem.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idtipoLitragem"].Value.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    bll.produtoQuantidade = (BLL.Classes.ClsProdutoQuantidade)comboBox2.Items[i];
                    if (bll.produtoQuantidade.idprodutoQuantidade.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idprodutoQuantidade"].Value.ToString())
                    {
                        comboBox2.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarProduto")
            {
                bll.produto.idproduto = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["idproduto"].Value.ToString());
                bll.produto.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado Produto com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox2_Format(object sender, ListControlConvertEventArgs e)
        {
            int qntMinima = ((BLL.Classes.ClsProdutoQuantidade)e.ListItem).quantidadeMinima;
            int qntMaxima = ((BLL.Classes.ClsProdutoQuantidade)e.ListItem).quantidadeMaxima;
            int qntSolCom = ((BLL.Classes.ClsProdutoQuantidade)e.ListItem).quantidadeSolicitarCompra;
            int qntRecom = ((BLL.Classes.ClsProdutoQuantidade)e.ListItem).quantidadeRecomendaEstoque;
            e.Value = string.Format("Min: {0}, Max: {1}, Qnt Rec: {2}, Qnt SolCom: {3}", qntMinima, qntMaxima, qntSolCom, qntRecom);
        }
    }
}
