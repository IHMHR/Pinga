﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsCusto : IGeneric<ClsCusto>
    {
        public Guid idcusto { get; set; }
        public ClsTipoCusto tipoCustoIdtipoCusto { get; set; }
        public decimal valor { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public ClsCusto()
        {
            tipoCustoIdtipoCusto = new ClsTipoCusto();
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
                    com.CommandText = "Pinga.usp_InserirNovoCusto";
                    com.Parameters.AddWithValue("@tipoCustoIdtipoCusto", tipoCustoIdtipoCusto.idtipoCusto);
                    com.Parameters.AddWithValue("@valor", valor);

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
                    com.CommandText = "UPDATE Pinga.custo SET valor = @valor, tipo_custo_idtipo_custo = @tipoCusto, modified = GETDATE() WHERE idcusto = @id";
                    com.Parameters.AddWithValue("@id", idcusto);
                    com.Parameters.AddWithValue("@tipoCusto", tipoCustoIdtipoCusto.idtipoCusto);
                    com.Parameters.AddWithValue("@valor", valor);

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
                    com.CommandText = "DELETE FROM Pinga.custo WHERE idcusto = @id";
                    com.Parameters.AddWithValue("@id", idcusto);

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

        public List<ClsCusto> Visualizar()
        {
            List<ClsCusto> retorno = new List<ClsCusto>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT c.idcusto, c.valor, c.created, c.modified, tc.idtipo_custo, tc.tipo_custo FROM Pinga.custo c INNER JOIN Pinga.tipo_custo tc ON c.tipo_custo_idtipo_custo = tc.idtipo_custo";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsCusto cus = new ClsCusto();
                        cus.idcusto = Guid.Parse(read["idcusto"].ToString());
                        cus.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            cus.modified = DateTime.Parse(read["modified"].ToString());
                        }
                        cus.valor = (decimal)read["valor"];
                        cus.tipoCustoIdtipoCusto.idtipoCusto = Guid.Parse(read["idtipo_custo"].ToString());
                        cus.tipoCustoIdtipoCusto.tipoCusto = read["tipo_custo"].ToString();

                        retorno.Add(cus);
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
                if (string.IsNullOrEmpty(valor.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe o valor");
                }
                else if (tipoCustoIdtipoCusto.idtipoCusto.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o tipo custo");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idcusto.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do custo");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsCusto BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT c.idcusto, c.valor, c.created, c.modified, tc.idtipo_custo, tc.tipo_custo FROM Pinga.custo c INNER JOIN Pinga.tipo_custo tc ON c.tipo_custo_idtipo_custo = tc.idtipo_custo WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    idcusto = Guid.Parse(read["idcusto"].ToString());
                    created = DateTime.Parse(read["created"].ToString());
                    if (!string.IsNullOrEmpty(read["modified"].ToString()))
                    {
                        modified = DateTime.Parse(read["modified"].ToString());
                    }
                    valor = (decimal)read["valor"];
                    tipoCustoIdtipoCusto.idtipoCusto = Guid.Parse(read["idtipo_custo"].ToString());
                    tipoCustoIdtipoCusto.tipoCusto = read["tipo_custo"].ToString();
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
