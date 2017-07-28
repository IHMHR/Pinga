using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsParcelamento : IGeneric<ClsParcelamento>
    {
        #region Atributos
        public Guid idparcelamento { get; set; }
        public Nullable<DateTime> dataPagamento { get; set; }
        public Nullable<DateTime> dataVencimento { get; set; }
        public int parcelas { get; set; }
        public decimal juros { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
        #endregion

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        {
        }

        public List<ClsParcelamento> Visualizar()
        {
            List<ClsParcelamento> retorno = new List<ClsParcelamento>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idparcelamento, data_pagamento, data_vencimento, parcelas, juros, created, modified FROM Pinga.parcelamento";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsParcelamento p = new ClsParcelamento();
                        p.idparcelamento = Guid.Parse(read["idparcelamento"].ToString());
                        p.dataPagamento = DateTime.Parse(read["data_pagamento"].ToString());
                        p.dataVencimento = DateTime.Parse(read["data_vencimento"].ToString());
                        p.parcelas = (int)read["parcelas"];
                        p.juros = (decimal)read["juros"];
                        p.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            p.created = DateTime.Parse(read["modified"].ToString());
                        }

                        retorno.Add(p);
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
                if (string.IsNullOrEmpty(parcelas.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe o número de parcelas.");
                }
                else if (string.IsNullOrEmpty(juros.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe o juros.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idparcelamento.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID d Parcelamento.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsParcelamento BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idparcelamento, data_pagamento, data_vencimento, parcelas, juros, created, modified FROM Pinga.parcelamento WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    idparcelamento = Guid.Parse(read["idparcelamento"].ToString());
                    dataPagamento = DateTime.Parse(read["data_pagamento"].ToString());
                    dataVencimento = DateTime.Parse(read["data_vencimento"].ToString());
                    parcelas = (int)read["parcelas"];
                    juros = (decimal)read["juros"];
                    created = DateTime.Parse(read["created"].ToString());
                    if (!string.IsNullOrEmpty(read["modified"].ToString()))
                    {
                        created = DateTime.Parse(read["modified"].ToString());
                    }
                    con.Close();
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
