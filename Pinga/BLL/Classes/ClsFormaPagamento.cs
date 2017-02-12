﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsFormaPagamento : IGeneric<ClsFormaPagamento>
    {
        public Guid idformaPagamento { get; set; }
        public string formaPagamento { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        {
            if (string.IsNullOrEmpty(formaPagamento))
            {
                throw new ArgumentNullException("Por favor informe a Forma Pagamento");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovaFormaPagamento";
                    com.Parameters.AddWithValue("@formaPagamento", formaPagamento);

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
            if (idformaPagamento == null)
            {
                throw new ArgumentNullException("Por favor informe o ID da Forma de Pagamento");
            }
            else if (string.IsNullOrEmpty(formaPagamento))
            {
                throw new ArgumentNullException("Por favor informe a Forma de Pagamento");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.forma_pagamento SET forma_pagamento = @formaPagamento WHERE idforma_pagamento = @id";
                    com.Parameters.AddWithValue("@id", idformaPagamento);
                    com.Parameters.AddWithValue("@formaPagamento", formaPagamento);

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
            if (idformaPagamento == null)
            {
                throw new ArgumentNullException("Por favor informe o ID da Forma de Pagamento");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.forma_pagamento WHERE idforma_pagamento = @id";
                    com.Parameters.AddWithValue("@id", idformaPagamento);

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

        public List<ClsFormaPagamento> Visualizar()
        {
            List<ClsFormaPagamento> retorno = new List<ClsFormaPagamento>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idforma_pagamento, forma_pagamento, created, modified FROM Pinga.forma_pagamento";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsFormaPagamento fp = new ClsFormaPagamento();
                        fp.idformaPagamento = Guid.Parse(read["idforma_pagamento"].ToString());
                        fp.formaPagamento = read["forma_pagamento"].ToString();
                        fp.created = DateTime.Parse(read["created"].ToString());
                        if(!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            fp.modified = DateTime.Parse(read["modified"].ToString());
                        }

                        retorno.Add(fp);
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
