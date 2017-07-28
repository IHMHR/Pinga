using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    public sealed class ClsEntradaHasItem
    {
        #region Atributos
        public Guid identrada_has_item { get; set; }
        public ClsEntrada entrada_identrada { get; set; }
        public ClsItem item_iditem { get; set; }
        #endregion

        public ClsEntradaHasItem()
        {
            entrada_identrada = new ClsEntrada();
            item_iditem = new ClsItem();
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
                    com.Parameters.AddWithValue("@itemIditem", item_iditem);
                    com.Parameters.AddWithValue("@entradaIdentrada", entrada_identrada);

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
                    com.Parameters.AddWithValue("@idsaida", entrada_identrada);
                    com.Parameters.AddWithValue("@iditem", item_iditem);
                    com.Parameters.AddWithValue("@id", identrada_has_item);
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
                    com.Parameters.AddWithValue("@id", identrada_has_item);
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
                        ehi.entrada_identrada = new ClsEntrada().BuscaPeloId(Guid.Parse(read["entrada_identrada"].ToString()));
                        ehi.item_iditem = new ClsItem().BuscaPeloId(Guid.Parse(read["item_iditem"].ToString()));

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
                if (entrada_identrada.identrada.ToString() == "00000000-0000-0000-0000-000000000000")
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
                if (identrada_has_item.ToString() == "00000000-0000-0000-0000-000000000000")
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
                    ehi.entrada_identrada = new ClsEntrada().BuscaPeloId(Guid.Parse(read["entrada_identrada"].ToString()));
                    ehi.item_iditem = new ClsItem().BuscaPeloId(Guid.Parse(read["item_iditem"].ToString()));
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
