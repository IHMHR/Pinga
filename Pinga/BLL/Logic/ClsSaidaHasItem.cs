using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsSaidaHasItemBO : IGeneric<ClsSaidaHasItem>
    {
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
                    com.CommandText = "Pinga.usp_InserirNovaSaidaHasItem";
                    com.Parameters.AddWithValue("@itemIditem", item_iditem);
                    com.Parameters.AddWithValue("@saidaIdsaida", saida_idsaida);

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
                    com.CommandText = "UPDATE Pinga.saida_has_item SET item_iditem = @iditem, saida_idsaida = @idsaida WHERE idsaida_has_item = @id";
                    com.Parameters.AddWithValue("@idsaida", saida_idsaida);
                    com.Parameters.AddWithValue("@iditem", item_iditem);
                    com.Parameters.AddWithValue("@id", idsaida_has_item);
                    con.Open();
                    com.Connection = con;

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
                    com.CommandText = "DELETE FROM Pinga.saida_has_item WHERE idsaida_has_item = @id";
                    com.Parameters.AddWithValue("@id", idsaida_has_item);
                    con.Open();
                    com.Connection = con;

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

        public List<ClsSaidaHasItem> Visualizar()
        {
            List<ClsSaidaHasItem> retorno = new List<ClsSaidaHasItem>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT shi.idsaida_has_item, shi.saida_idsaida, shi.item_iditem FROM Pinga.saida_has_item shi INNER JOIN Pinga.saida s ON shi.saida_idsaida = s.idsaida INNER JOIN Pinga.item i ON shi.item_iditem = i.iditem";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsSaidaHasItem shi = new ClsSaidaHasItem();
                        shi.idsaida_has_item = Guid.Parse(read["idsaida_has_item"].ToString());
                        shi.saida_idsaida = new ClsSaida().BuscaPeloId(Guid.Parse(read["saida_idsaida"].ToString()));
                        shi.item_iditem = new ClsItem().BuscaPeloId(Guid.Parse(read["item_iditem"].ToString()));

                        retorno.Add(shi);
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
                if (saida_idsaida.idsaida.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a entrada.");
                }
                else if (item_iditem.iditem.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o item.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idsaida_has_item.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID da Operadora.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsSaidaHasItem BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT shi.idsaida_has_item, shi.saida_idsaida, shi.item_iditem FROM Pinga.saida_has_item shi INNER JOIN Pinga.saida s ON shi.saida_idsaida = s.idsaida INNER JOIN Pinga.item i ON shi.item_iditem = i.iditem WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    ClsSaidaHasItem shi = new ClsSaidaHasItem();
                    shi.idsaida_has_item = Guid.Parse(read["idsaida_has_item"].ToString());
                    shi.saida_idsaida = new ClsSaida().BuscaPeloId(Guid.Parse(read["saida_idsaida"].ToString()));
                    shi.item_iditem = new ClsItem().BuscaPeloId(Guid.Parse(read["item_iditem"].ToString()));
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }
        #endregion
    }
}
