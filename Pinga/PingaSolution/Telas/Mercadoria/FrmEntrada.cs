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
    public partial class FrmEntrada : Form
    {
        Bll bll = new Bll("Entrada");
        public FrmEntrada()
        {
            InitializeComponent();
        }

        private void FrmEntrada_Load(object sender, EventArgs e)
        {
            try
            {
                var columnIdentrada = new DataGridViewTextBoxColumn();
                columnIdentrada.HeaderText = "ID Entrada";
                columnIdentrada.Name = "identrada";
                columnIdentrada.DataPropertyName = "identrada";
                columnIdentrada.Visible = false;

                var columnEntradaData = new DataGridViewTextBoxColumn();
                columnEntradaData.HeaderText = "Entrada Data";
                columnEntradaData.Name = "dataEntrada";
                columnEntradaData.DataPropertyName = "dataEntrada";

                var columnEntradaLitragem = new DataGridViewTextBoxColumn();
                columnEntradaLitragem.HeaderText = "Entrada Litragem";
                columnEntradaLitragem.Name = "litragemEntrada";
                columnEntradaLitragem.DataPropertyName = "litragemEntrada";

                var columnEntradaIdTipoLitragem = new DataGridViewTextBoxColumn();
                columnEntradaIdTipoLitragem.HeaderText = "ID Tipo Litragem";
                columnEntradaIdTipoLitragem.Name = "idtipoLitragem";
                columnEntradaIdTipoLitragem.DataPropertyName = "idtipoLitragem";
                columnEntradaIdTipoLitragem.Visible = false;

                var columnTipoLitragem = new DataGridViewTextBoxColumn();
                columnTipoLitragem.HeaderText = "Tipo Litragem";
                columnTipoLitragem.Name = "tipoLitragem";
                columnTipoLitragem.DataPropertyName = "tipoLitragem";

                var columnIdCusto = new DataGridViewTextBoxColumn();
                columnIdCusto.HeaderText = "ID Custo";
                columnIdCusto.Name = "idcusto";
                columnIdCusto.DataPropertyName = "idcusto";
                columnIdCusto.Visible = false;

                var columnValor = new DataGridViewTextBoxColumn();
                columnValor.HeaderText = "Custo";
                columnValor.Name = "valor";
                columnValor.DataPropertyName = "valor";

                var columnIdTipoCusto = new DataGridViewTextBoxColumn();
                columnIdTipoCusto.HeaderText = "ID Tipo Custo";
                columnIdTipoCusto.Name = "idtipo_custo";
                columnIdTipoCusto.DataPropertyName = "idtipo_custo";
                columnIdTipoCusto.Visible = false;

                var columnTipoCusto = new DataGridViewTextBoxColumn();
                columnTipoCusto.HeaderText = "Tipo Custo";
                columnTipoCusto.Name = "tipo_custo";
                columnTipoCusto.DataPropertyName = "tipo_custo";

                var columnIdParcelamento = new DataGridViewTextBoxColumn();
                columnIdParcelamento.HeaderText = "ID Parcelamento";
                columnIdParcelamento.Name = "idparcelamento";
                columnIdParcelamento.DataPropertyName = "idparcelamento";
                columnIdParcelamento.Visible = false;

                var columnDataPagamento = new DataGridViewTextBoxColumn();
                columnDataPagamento.HeaderText = "Data Primeira Parcela";
                columnDataPagamento.Name = "data_pagamento";
                columnDataPagamento.DataPropertyName = "data_pagamento";

                var columnDataVencimento = new DataGridViewTextBoxColumn();
                columnDataVencimento.HeaderText = "Data Vencimento";
                columnDataVencimento.Name = "data_vencimento";
                columnDataVencimento.DataPropertyName = "data_vencimento";

                var columnParcelas = new DataGridViewTextBoxColumn();
                columnParcelas.HeaderText = "Quantidade Parcelas";
                columnParcelas.Name = "parcelas";
                columnParcelas.DataPropertyName = "parcelas";

                var columnJuros = new DataGridViewTextBoxColumn();
                columnJuros.HeaderText = "Juros";
                columnJuros.Name = "juros";
                columnJuros.DataPropertyName = "juros";

                var columnEditar = new DataGridViewButtonColumn();
                columnEditar.HeaderText = "Editar";
                columnEditar.Name = "editarEntrada";
                columnEditar.Text = "Editar";
                columnEditar.UseColumnTextForButtonValue = true;

                var columnApagar = new DataGridViewButtonColumn();
                columnApagar.HeaderText = "Apagar";
                columnApagar.Name = "apagarEntrada";
                columnApagar.Text = "Apagar";
                columnApagar.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(columnIdentrada);
                dataGridView1.Columns.Add(columnEntradaData);
                dataGridView1.Columns.Add(columnEntradaLitragem);
                dataGridView1.Columns.Add(columnEntradaIdTipoLitragem);
                dataGridView1.Columns.Add(columnTipoLitragem);
                dataGridView1.Columns.Add(columnValor);
                dataGridView1.Columns.Add(columnIdCusto);
                dataGridView1.Columns.Add(columnIdTipoCusto);
                dataGridView1.Columns.Add(columnTipoCusto);
                dataGridView1.Columns.Add(columnIdParcelamento);
                dataGridView1.Columns.Add(columnDataPagamento);
                dataGridView1.Columns.Add(columnDataVencimento);
                dataGridView1.Columns.Add(columnParcelas);
                dataGridView1.Columns.Add(columnJuros);
                dataGridView1.Columns.Add(columnEditar);
                dataGridView1.Columns.Add(columnApagar);

                fillDataGrid();

                // popular combo box
                comboBox1.DataSource = new Bll("Tipo_Litragem").tipoLitragem.Visualizar();
                comboBox1.DisplayMember = "tipoLitragem";
                comboBox1.ValueMember = "idtipoLitragem";
                comboBox1.SelectedIndex = -1;

                comboBox2.DataSource = new Bll("Custo").custo.Visualizar();
                comboBox2.DisplayMember = "valor";
                comboBox2.ValueMember = "idCusto";
                comboBox2.SelectedIndex = -1;

                comboBox3.DataSource = new Bll("Parcelamento").parcelamento.Visualizar();
                comboBox3.DisplayMember = "parcelas";
                comboBox3.ValueMember = "idparcelamento";
                comboBox3.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao popular o grid", "Falha de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillDataGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in bll.entrada.Visualizar())
            {
                dataGridView1.Rows.Add(item.identrada, item.data.ToShortDateString(), item.litragem, item.tipoLitragemIdtipoLitragem.idtipoLitragem, item.tipoLitragemIdtipoLitragem.tipoLitragem, item.custoIdcusto.valor, item.custoIdcusto.idcusto, item.custoIdcusto.tipoCustoIdtipoCusto.idtipoCusto, item.custoIdcusto.tipoCustoIdtipoCusto.tipoCusto, item.parcelamentoIdparcelamento.idparcelamento, item.parcelamentoIdparcelamento.dataPagamento.Value.ToShortDateString(), item.parcelamentoIdparcelamento.dataVencimento.Value.ToShortDateString(), item.parcelamentoIdparcelamento.parcelas, item.parcelamentoIdparcelamento.juros);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "editarEntrada")
            {
                button1.Text = "Editar";

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["identrada"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["litragemEntrada"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["dataEntrada"].Value.ToString());

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
                    bll.custo = (BLL.Classes.ClsCusto)comboBox2.Items[i];
                    if (bll.custo.idcusto.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idcusto"].Value.ToString())
                    {
                        comboBox2.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < comboBox3.Items.Count; i++)
                {
                    bll.parcelamento = (BLL.Classes.ClsParcelamento)comboBox3.Items[i];
                    if (bll.parcelamento.idparcelamento.ToString() == dataGridView1.Rows[e.RowIndex].Cells["idparcelamento"].Value.ToString())
                    {
                        comboBox3.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "apagarEntrada")
            {
                bll.entrada.identrada = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["identrada"].Value.ToString());
                bll.entrada.Apagar();
                fillDataGrid();
                MessageBox.Show("Apagado estado com sucesso", "Exclusão realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                bll.entrada.data = dateTimePicker1.Value;
                bll.entrada.tipoLitragemIdtipoLitragem.idtipoLitragem = Guid.Parse(comboBox1.SelectedValue.ToString());
                bll.entrada.custoIdcusto.idcusto = Guid.Parse(comboBox2.SelectedValue.ToString());
                bll.entrada.parcelamentoIdparcelamento.idparcelamento = Guid.Parse(comboBox3.SelectedValue.ToString());
                bll.entrada.litragem = int.Parse(textBox2.Text.Trim().Replace("'", ""));
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bll.entrada.identrada = Guid.Parse(textBox1.Text);
                }

                if (button1.Text == "Salvar")
                {
                    bll.entrada.Inserir();
                    fillDataGrid();
                    MessageBox.Show("Cadastrado nova Entrada com sucesso", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (button1.Text == "Editar")
                {
                    button1.Text = "Salvar";
                    bll.entrada.Alterar();
                    fillDataGrid();
                    MessageBox.Show("Alterado Entrada com sucesso", "Alteração realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Classes.ClsGlobal.ClearForm(groupBox1);
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Preencher campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox3_Format(object sender, ListControlConvertEventArgs e)
        {
            DateTime dtVencimento = (DateTime)((BLL.Classes.ClsParcelamento)e.ListItem).dataVencimento;
            DateTime dtPagamento = (DateTime)((BLL.Classes.ClsParcelamento)e.ListItem).dataPagamento;
            int parcelas = ((BLL.Classes.ClsParcelamento)e.ListItem).parcelas;
            decimal juros = ((BLL.Classes.ClsParcelamento)e.ListItem).juros;
            e.Value = string.Format("Dt Venc: {0}, Dt 1º P: {1}, Parcelas: {2}, Juros: {3}", dtVencimento.ToShortDateString(), dtPagamento.ToShortDateString(), parcelas, juros);
        }

        private void comboBox2_Format(object sender, ListControlConvertEventArgs e)
        {
            decimal valor = ((BLL.Classes.ClsCusto)e.ListItem).valor;
            e.Value = string.Format("R$ {0}", valor);
        }
    }
}
