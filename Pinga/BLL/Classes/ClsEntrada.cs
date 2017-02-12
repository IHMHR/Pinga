using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsEntrada : IGeneric<ClsEntrada>
    {
        public Guid identrada { get; set; }
        public Nullable<DateTime> data { get; set; }
        public int litragem { get; set; }
        public ClsTipoLitragem tipoLitragemIdtipoLitragem { get; set; }
        public decimal valor { get; set; }
        public ClsCusto custoIdcusto { get; set; }
        public ClsParcelamento parcelamentoIdparcelamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsEntrada()
        {
            tipoLitragemIdtipoLitragem = new ClsTipoLitragem();
            custoIdcusto = new ClsCusto();
            parcelamentoIdparcelamento = new ClsParcelamento();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEntrada> Visualizar()
        {
            List<ClsEntrada> retorno = new List<ClsEntrada>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT identrada, data, litragem, tipo_litragem_idtipo_litragem,e. valor, custo_idcusto, parcelamento_idparcelamento, e.created, e.modified, tl.idtipo_litragem, tl.tipo_litragem, c.idcusto, c.valor, tc.idtipo_custo, tc.tipo_custo, p.idparcelamento, p.data_pagamento, p.data_vencimento, p.juros, p.parcelas FROM Pinga.entrada e INNER JOIN Pinga.tipo_litragem tl ON e.tipo_litragem_idtipo_litragem = tl.idtipo_litragem INNER JOIN Pinga.custo c ON e.custo_idcusto = c.idcusto INNER JOIN Pinga.tipo_custo tc ON c.tipo_custo_idtipo_custo = tc.idtipo_custo INNER JOIN Pinga.parcelamento p ON e.parcelamento_idparcelamento = p.idparcelamento;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsEntrada ent = new ClsEntrada();

                        retorno.Add(ent);
                    }
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
