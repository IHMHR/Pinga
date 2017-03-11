﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    public sealed class ClsSaidaHasItem : IGeneric<ClsSaidaHasItem>
    {
        public Guid idsaida_has_item { get; set; }
        public ClsSaida saida_idsaida { get; set; }
        public ClsItem item_iditem { get; set; }

        public ClsSaidaHasItem()
        {
            saida_idsaida = new ClsSaida();
            item_iditem = new ClsItem();
        }

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public void Alterar()
        {
            throw new NotImplementedException();
        }

        public void Apagar()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
