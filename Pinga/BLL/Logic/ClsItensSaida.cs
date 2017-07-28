using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsItensSaida : IGeneric<ClsItensSaida>
    {
        public Guid iditensSaida { get; set; }
        public ClsSaida saidaIdsaida { get; set; }
        public ClsProduto produtoIdproduto { get; set; }
        public int quantidade { get; set; }
        public decimal valorSaida { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsItensSaida()
        {
            saidaIdsaida = new ClsSaida();
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
                    com.CommandText = "Pinga.usp_InserirNovoItenSaida";
                    com.Parameters.AddWithValue("@saidaIdsaida", saidaIdsaida.idsaida);
                    com.Parameters.AddWithValue("@produtoIdproduto", produtoIdproduto.idproduto);
                    com.Parameters.AddWithValue("@quantidade", quantidade);
                    com.Parameters.AddWithValue("@valorSaida", valorSaida);

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
                    com.CommandText = "UPDATE Pinga.itens_saida SET saida_idsaida = @saidaIdsaida, produto_idproduto = @produtoIdproduto, quantidade = @quantidade, valor_saida = @valorSaida WHERE iditens_saida = @id";
                    com.Parameters.AddWithValue("@saidaIdsaida", saidaIdsaida.idsaida);
                    com.Parameters.AddWithValue("@produtoIdproduto", produtoIdproduto.idproduto);
                    com.Parameters.AddWithValue("@quantidade", quantidade);
                    com.Parameters.AddWithValue("@valorSaida", valorSaida);
                    com.Parameters.AddWithValue("@id", iditensSaida);

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
                    com.CommandText = "DELETE FROM Pinga.itens_saida WHERE iditens_saida = @id";
                    com.Parameters.AddWithValue("@id", iditensSaida);

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

        public List<ClsItensSaida> Visualizar()
        {
            return null;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (saidaIdsaida.idsaida.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a saida.");
                }
                else if (produtoIdproduto.idproduto.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o produto.");
                }
                else if (string.IsNullOrEmpty(quantidade.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe a quantidade.");
                }
                else if (string.IsNullOrEmpty(valorSaida.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe o parcelamento.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (iditensSaida.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do item saida.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsItensSaida BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
