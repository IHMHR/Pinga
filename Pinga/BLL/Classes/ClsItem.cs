using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    public sealed class ClsItem
    {
        public Guid iditem { get; set; }
        public string item { get; set; }
        public ClsProduto produtoIdproduto { get; set; }
        public DateTime created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsItem()
        {
            produtoIdproduto = new ClsProduto();
        }

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
                    com.CommandText = "Pinga.usp_InserirNovoItem";
                    com.Parameters.AddWithValue("@item", item);
                    com.Parameters.AddWithValue("@produtoIdproduto", produtoIdproduto.idproduto);

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
                    com.CommandText = "UPDATE Pinga.item SET item = @item, produto_idproduto = @produtoIdproduto, modified = GETDATE() WHERE iditem = @id";
                    com.Parameters.AddWithValue("@item", item);
                    com.Parameters.AddWithValue("@produtoIdproduto", produtoIdproduto.idproduto); ;
                    com.Parameters.AddWithValue("@id", iditem);

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
                    com.CommandText = "DELETE FROM Pinga.item WHERE iditem = @id";
                    com.Parameters.AddWithValue("@id", iditem);

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

        public List<ClsItem> Visualizar()
        {
            List<ClsItem> retorno = new List<ClsItem>();
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT i.iditem, i.item, i.created, i.modified, p.idproduto, p.produto, p.litragem, p.vendendo, p.valor_unitario, tl.idtipo_litragem, tl.tipo_litragem, pq.idproduto_quantidade, pq.quantidade_maxima, pq.quantidade_minima, pq.quantidade_recomenda_estoque, pq.quantidade_solicitar_compra FROM Pinga.item i INNER JOIN Pinga.produto p ON i.produto_idproduto = p.idproduto INNER JOIN Pinga.tipo_litragem tl ON p.tipo_litragem_idtipo_litragem = tl.idtipo_litragem INNER JOIN Pinga.produto_quantidade pq ON p.produto_quantidade_idproduto_quantidade = pq.idproduto_quantidade";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsItem it = new ClsItem();
                        it.iditem = Guid.Parse(read["iditem"].ToString());
                        it.item = read["item"].ToString();
                        it.created = DateTime.Parse(read["created"].ToString());

                        retorno.Add(it);
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

            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {

            }
        }

        public ClsItem BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT i.iditem, i.item, i.produto_idproduto, i.created, i.modified FROM Pinga.item i WHERE i.iditem = @rowGuidCol;";
                    com.Parameters.AddWithValue("@rowGuidCol", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();

                    iditem = Guid.Parse(read["iditem"].ToString());
                    item = read["item"].ToString();
                    produtoIdproduto.idproduto = Guid.Parse(read["produto_idproduto"].ToString());
                    created = DateTime.Parse(read["created"].ToString());
                    if (!string.IsNullOrEmpty(read["modified"].ToString()))
                    {
                        modified = DateTime.Parse(read["modified"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }
    }
}
