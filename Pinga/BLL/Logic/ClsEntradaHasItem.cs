using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsEntradaHasItemBO : IGeneric<ClsEntradaHasItem>
    {
        private static ClsEntradaHasItem e = null;

        public ClsEntradaHasItemBO()
        {
            e = new ClsEntradaHasItem();
        }

        public ClsEntradaHasItemBO(ClsEntradaHasItem entradaHasItemClass)
        {
            e = entradaHasItemClass ?? new ClsEntradaHasItem();
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
                    com.CommandText = "Pinga.usp_InserirNovaEntradaHasItem";
                    com.Parameters.AddWithValue("@itemIditem", e.item_iditem);
                    com.Parameters.AddWithValue("@entradaIdentrada", e.entrada_identrada);

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
                    com.CommandText = "UPDATE Pinga.entrada_has_item SET item_iditem = @iditem, entrada_identrada = @identrada WHERE identrada_has_item = @id";
                    com.Parameters.AddWithValue("@idsaida", e.entrada_identrada);
                    com.Parameters.AddWithValue("@iditem", e.item_iditem);
                    com.Parameters.AddWithValue("@id", e.identrada_has_item);
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
                    com.CommandText = "DELETE FROM Pinga.entrada_has_item WHERE identrada_has_item = @id";
                    com.Parameters.AddWithValue("@id", e.identrada_has_item);
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

        public List<ClsEntradaHasItem> Visualizar()
        {
            List<ClsEntradaHasItem> retorno = new List<ClsEntradaHasItem>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT ehi.identrada_has_item, ehi.entrada_identrada, ehi.item_iditem FROM Pinga.entrada_has_item ehi INNER JOIN Pinga.entrada e ON ehi.entrada_identrada = e.identrada INNER JOIN Pinga.item i ON ehi.item_iditem = i.iditem";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsEntradaHasItem ehi = new ClsEntradaHasItem();
                        ehi.identrada_has_item = Guid.Parse(read["identrada_has_item"].ToString());
                        ehi.entrada_identrada = new ClsEntradaBO().BuscaPeloId(Guid.Parse(read["entrada_identrada"].ToString()));
                        ehi.item_iditem = new ClsItemBO().BuscaPeloId(Guid.Parse(read["item_iditem"].ToString()));

                        retorno.Add(ehi);
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
                if (e.entrada_identrada.identrada.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a entrada.");
                }
                else if (e.item_iditem.iditem.ToString() == "00000000-0000-0000-0000-000000000000")
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
                if (e.identrada_has_item.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID da Operadora.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsEntradaHasItem BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT ehi.identrada_has_item, ehi.entrada_identrada, ehi.item_iditem FROM Pinga.entrada_has_item ehi INNER JOIN Pinga.entrada e ON ehi.entrada_identrada = e.identrada INNER JOIN Pinga.item i ON ehi.item_iditem = i.iditem WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    ClsEntradaHasItem ehi = new ClsEntradaHasItem();
                    ehi.identrada_has_item = Guid.Parse(read["identrada_has_item"].ToString());
                    ehi.entrada_identrada = new ClsEntradaBO().BuscaPeloId(Guid.Parse(read["entrada_identrada"].ToString()));
                    ehi.item_iditem = new ClsItemBO().BuscaPeloId(Guid.Parse(read["item_iditem"].ToString()));
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return e;
        }
        #endregion
    }
}
