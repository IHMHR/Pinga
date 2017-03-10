using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    class ClsEntradaHasItem : IGeneric<ClsEntradaHasItem>
    {
        public Guid identrada_has_item { get; set; }
        public ClsEntradaHasItem entrada_identrada { get; set; }
        public ClsItem item_iditem { get; set; }

        public ClsEntradaHasItem()
        {
            entrada_identrada = new ClsEntradaHasItem();
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

        public List<ClsEntradaHasItem> Visualizar()
        {
            List<ClsEntradaHasItem> retorno = new List<ClsEntradaHasItem>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsEntradaHasItem ehi = new ClsEntradaHasItem();


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
                if (entrada_identrada.identrada_has_item.ToString() == "00000000-0000-0000-0000-000000000000")
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
            throw new NotImplementedException();
        }
    }
}
