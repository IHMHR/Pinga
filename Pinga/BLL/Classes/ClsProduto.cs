using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsProduto : IGeneric<ClsProduto>
    {
        #region Atributos
        public Guid idproduto { get; set; }
        public string produto { get; set; }
        public ClsTipoLitragem tipoLitragemIdtipoLitragem { get; set; }
        public Nullable<int> litragem { get; set; }
        public bool vendendo { get; set; }
        public decimal valorUnitario { get; set; }
        public ClsProdutoQuantidade produtoQuantidadeIdprodutoQuantidade { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
        #endregion

        public ClsProduto()
        {
            tipoLitragemIdtipoLitragem = new ClsTipoLitragem();
            produtoQuantidadeIdprodutoQuantidade = new ClsProdutoQuantidade();
        }

        #region CRUD Functions
        public void Inserir()
        {
            ValidarClasse(CRUD.insert);

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovoProduto";
                    com.Parameters.AddWithValue("@descricao", produto);
                    com.Parameters.AddWithValue("@tipoLitragemIdtipoLitragem", tipoLitragemIdtipoLitragem.idtipoLitragem);
                    com.Parameters.AddWithValue("@litragem", litragem);
                    com.Parameters.AddWithValue("@vendendo", vendendo);
                    com.Parameters.AddWithValue("@valorUnitario", valorUnitario);
                    com.Parameters.AddWithValue("@produtoQuantidadeIdprodutoQuantidade", produtoQuantidadeIdprodutoQuantidade.idprodutoQuantidade);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Alterar()
        {
            ValidarClasse(CRUD.update);

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.produto SET produto = @produto, tipo_litragem_idtipo_litragem = @tipoLitragemIdtipoLitragem, litragem = @litragem, vendendo = @vendendo, valor_unitario = @valorUnitario, produto_quantidade_idproduto_quantidade = @produtoQuantidadeIdprodutoQuantidade, modified = GETDATE() WHERE idproduto = @id";
                    com.Parameters.AddWithValue("@id", idproduto);
                    com.Parameters.AddWithValue("@produto", produto);
                    com.Parameters.AddWithValue("@tipoLitragemIdtipoLitragem", tipoLitragemIdtipoLitragem.idtipoLitragem);
                    com.Parameters.AddWithValue("@litragem", litragem);
                    com.Parameters.AddWithValue("@vendendo", vendendo);
                    com.Parameters.AddWithValue("@valorUnitario", valorUnitario);
                    com.Parameters.AddWithValue("@produtoQuantidadeIdprodutoQuantidade", produtoQuantidadeIdprodutoQuantidade.idprodutoQuantidade);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Apagar()
        {
            ValidarClasse(CRUD.delete);

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.produto WHERE idproduto = @id";
                    com.Parameters.AddWithValue("@id", idproduto);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ClsProduto> Visualizar()
        {
            List<ClsProduto> retorno = new List<ClsProduto>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT p.idproduto, p.produto, p.litragem, p.vendendo, p.valor_unitario, p.created, p.modified, tl.idtipo_litragem, tl.tipo_litragem, pq.idproduto_quantidade, pq.quantidade_minima, pq.quantidade_maxima, pq.quantidade_recomenda_estoque, pq.quantidade_solicitar_compra FROM Pinga.produto p INNER JOIN Pinga.tipo_litragem tl ON p.tipo_litragem_idtipo_litragem = tl.idtipo_litragem INNER JOIN Pinga.produto_quantidade pq ON p.produto_quantidade_idproduto_quantidade = pq.idproduto_quantidade";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsProduto pro = new ClsProduto();
                        pro.idproduto = Guid.Parse(read["idproduto"].ToString());
                        pro.produto = read["produto"].ToString();
                        pro.vendendo = (bool)read["vendendo"];
                        pro.litragem = (int)read["litragem"];
                        pro.valorUnitario = (decimal)read["valor_unitario"];
                        pro.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            pro.modified = DateTime.Parse(read["modified"].ToString());
                        }
                        pro.tipoLitragemIdtipoLitragem.idtipoLitragem = Guid.Parse(read["idtipo_litragem"].ToString());
                        pro.tipoLitragemIdtipoLitragem.tipoLitragem = read["tipo_litragem"].ToString();
                        pro.produtoQuantidadeIdprodutoQuantidade.idprodutoQuantidade = Guid.Parse(read["idproduto_quantidade"].ToString());
                        pro.produtoQuantidadeIdprodutoQuantidade.quantidadeMinima = (int)read["quantidade_minima"];
                        pro.produtoQuantidadeIdprodutoQuantidade.quantidadeMaxima = (int)read["quantidade_maxima"];
                        pro.produtoQuantidadeIdprodutoQuantidade.quantidadeRecomendaEstoque = (int)read["quantidade_recomenda_estoque"];
                        pro.produtoQuantidadeIdprodutoQuantidade.quantidadeSolicitarCompra = (int)read["quantidade_solicitar_compra"];

                        retorno.Add(pro);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return retorno;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(produto))
                {
                    throw new ArgumentNullException("Por favor informe o Produto");
                }
                else if (tipoLitragemIdtipoLitragem.idtipoLitragem.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o Tipo Litragem");
                }
                else if (vendendo != true && vendendo != false)
                {
                    throw new ArgumentNullException("Por favor informe o produto esta a venda");
                }
                else if (string.IsNullOrEmpty(valorUnitario.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe o Valor Unitário");
                }
                else if (produtoQuantidadeIdprodutoQuantidade.idprodutoQuantidade.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o Produto Quantidade");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idproduto.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do Produto");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsProduto BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
