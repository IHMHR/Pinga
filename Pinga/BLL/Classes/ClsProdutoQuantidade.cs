using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsProdutoQuantidade : IGeneric<ClsProdutoQuantidade>
    {
        public Guid idprodutoQuantidade { get; set; }
        public int quantidadeMinima { get; set; }
        public int quantidadeMaxima { get; set; }
        public int quantidadeRecomendaEstoque { get; set; }
        public int quantidadeSolicitarCompra { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        {
            if (string.IsNullOrEmpty(quantidadeMinima.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Minima");
            }
            else if (string.IsNullOrEmpty(quantidadeMaxima.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Máxima");
            }
            else if (string.IsNullOrEmpty(quantidadeRecomendaEstoque.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Recomendada");
            }
            else if (string.IsNullOrEmpty(quantidadeSolicitarCompra.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Solicitar Compra");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovaProdutoQuantidade";
                    com.Parameters.AddWithValue("@qntMin", quantidadeMinima);
                    com.Parameters.AddWithValue("@qntMax", quantidadeMaxima);
                    com.Parameters.AddWithValue("@qntSolicitarCompra", quantidadeSolicitarCompra);
                    com.Parameters.AddWithValue("@qntRecomendaEstoque", quantidadeRecomendaEstoque);

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
            if (idprodutoQuantidade == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do Produto Quantidade");
            }
            else if (string.IsNullOrEmpty(quantidadeMinima.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Minima");
            }
            else if (string.IsNullOrEmpty(quantidadeMaxima.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Máxima");
            }
            else if (string.IsNullOrEmpty(quantidadeRecomendaEstoque.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Recomendada");
            }
            else if (string.IsNullOrEmpty(quantidadeSolicitarCompra.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Quantidade Solicitar Compra");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.produto_quantidade SET quantidade_minima = @qntMin, quantidade_maxima = @qntMax, quantidade_recomenda_compra = @qntRecomendaEstoque, quantidade_solicitar_compra = @qntSolicitarCompra, modified = GETDATE() WHERE idproduto_quantidade = @id";
                    com.Parameters.AddWithValue("@id", idprodutoQuantidade);
                    com.Parameters.AddWithValue("@qntMin", quantidadeMinima);
                    com.Parameters.AddWithValue("@qntMax", quantidadeMaxima);
                    com.Parameters.AddWithValue("@qntSolicitarCompra", quantidadeSolicitarCompra);
                    com.Parameters.AddWithValue("@qntRecomendaEstoque", quantidadeRecomendaEstoque);

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
            if(idprodutoQuantidade == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do Produto Quantidade");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.produto_quantidade WHERE idproduto_quantidade = @id";
                    com.Parameters.AddWithValue("@id", idprodutoQuantidade);

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

        public List<ClsProdutoQuantidade> Visualizar()
        {
            List<ClsProdutoQuantidade> retorno = new List<ClsProdutoQuantidade>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT idproduto_quantidade, quantidade_minima, quantidade_maxima, quantidade_recomenda_estoque, quantidade_solicitar_compra FROM Pinga.produto_quantidade";

                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsProdutoQuantidade pq = new ClsProdutoQuantidade();
                        pq.idprodutoQuantidade = Guid.Parse(read["idproduto_quantidade"].ToString());
                        pq.quantidadeMinima = (int)read["quantidade_minima"];
                        pq.quantidadeMaxima = (int)read["quantidade_maxima"];
                        pq.quantidadeRecomendaEstoque = (int)read["quantidade_recomenda_estoque"];
                        pq.quantidadeSolicitarCompra = (int)read["quantidade_solicitar_compra"];

                        retorno.Add(pq);
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return retorno;
        }
    }
}
