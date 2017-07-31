using BLL.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Logic
{
    public sealed class ClsEntradaBO : IGeneric<ClsEntrada>
    {
        private static ClsEntrada e = null;

        public ClsEntradaBO()
        {
            e = new ClsEntrada();
        }

        public ClsEntradaBO(ClsEntrada entradaClass)
        {
            e = entradaClass ?? new ClsEntrada();
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
                    com.CommandText = "Pinga.usp_InserirNovaEntrada";
                    com.Parameters.AddWithValue("@data", e.data);
                    com.Parameters.AddWithValue("@litragem", e.litragem);
                    com.Parameters.AddWithValue("@tipoLitragemIdtipoLitragem", e.tipoLitragemIdtipoLitragem.idtipoLitragem);
                    com.Parameters.AddWithValue("@custoIdcusto", e.custoIdcusto.idcusto);
                    com.Parameters.AddWithValue("@parcelamentoIdparcelamento", e.parcelamentoIdparcelamento.idparcelamento);

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
                    com.CommandText = "UPDATE Pinga.entrada SET data = @data, litragem = @litragem, tipo_litragem_idtipo_litragem = @tipoLitragemIdtipoLitragem, custo_idcusto = @custoIdcusto, parcelamento_idparcelamento = @parcelamentoIdparcelamento WHERE identrada = @id";
                    com.Parameters.AddWithValue("@id", e.identrada);
                    com.Parameters.AddWithValue("@data", e.data);
                    com.Parameters.AddWithValue("@litragem", e.litragem);
                    com.Parameters.AddWithValue("@tipoLitragemIdtipoLitragem", e.tipoLitragemIdtipoLitragem.idtipoLitragem);
                    com.Parameters.AddWithValue("@custoIdcusto", e.custoIdcusto.idcusto);
                    com.Parameters.AddWithValue("@parcelamentoIdparcelamento", e.parcelamentoIdparcelamento.idparcelamento);

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
                    com.CommandText = "DELETE FROM Pinga.entrada WHERE identrada = @id";
                    com.Parameters.AddWithValue("@id", e.identrada);

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

        public List<ClsEntrada> Visualizar()
        {
            List<ClsEntrada> retorno = new List<ClsEntrada>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT e.identrada, e.data, e.litragem, e.created, e.modified, tl.idtipo_litragem, tl.tipo_litragem, c.idcusto, c.valor AS valorCusto, tc.idtipo_custo, tc.tipo_custo, p.idparcelamento, p.data_pagamento, p.data_vencimento, p.juros, p.parcelas FROM Pinga.entrada e INNER JOIN Pinga.tipo_litragem tl ON e.tipo_litragem_idtipo_litragem = tl.idtipo_litragem INNER JOIN Pinga.custo c ON e.custo_idcusto = c.idcusto INNER JOIN Pinga.tipo_custo tc ON c.tipo_custo_idtipo_custo = tc.idtipo_custo INNER JOIN Pinga.parcelamento p ON e.parcelamento_idparcelamento = p.idparcelamento;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsEntrada ent = new ClsEntrada();
                        ent.identrada = Guid.Parse(read["identrada"].ToString());
                        ent.data = DateTime.Parse(read["data"].ToString());
                        ent.litragem = (int)read["litragem"];
                        ent.created = DateTime.Parse(read["created"].ToString());
                        if (!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            ent.modified = DateTime.Parse(read["modified"].ToString());
                        }
                        ent.tipoLitragemIdtipoLitragem.idtipoLitragem = Guid.Parse(read["idtipo_litragem"].ToString());
                        ent.tipoLitragemIdtipoLitragem.tipoLitragem = read["tipo_litragem"].ToString();
                        ent.custoIdcusto.idcusto = Guid.Parse(read["idcusto"].ToString());
                        ent.custoIdcusto.valor = (decimal)read["valorCusto"];
                        ent.custoIdcusto.tipoCustoIdtipoCusto.idtipoCusto = Guid.Parse(read["idtipo_custo"].ToString());
                        ent.custoIdcusto.tipoCustoIdtipoCusto.tipoCusto = read["tipo_custo"].ToString();
                        ent.parcelamentoIdparcelamento.idparcelamento = Guid.Parse(read["idparcelamento"].ToString());
                        ent.parcelamentoIdparcelamento.dataPagamento = DateTime.Parse(read["data_pagamento"].ToString());
                        ent.parcelamentoIdparcelamento.dataVencimento = DateTime.Parse(read["data_vencimento"].ToString());
                        ent.parcelamentoIdparcelamento.juros = (decimal)read["juros"];
                        ent.parcelamentoIdparcelamento.parcelas = (int)read["parcelas"];

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

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(e.data.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe a Data");
                }
                else if (string.IsNullOrEmpty(e.litragem.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe a Litragem");
                }
                else if (e.custoIdcusto == null)
                {
                    throw new ArgumentNullException("Por favor informe o Custo");
                }
                else if (e.parcelamentoIdparcelamento.idparcelamento.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o Parcelametno");
                }
                else if (e.tipoLitragemIdtipoLitragem.idtipoLitragem.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o Tipo Litragem");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (e.identrada.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a ID da Entrada");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsEntrada BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT e.identrada, e.data, e.litragem, e.created, e.modified, tl.idtipo_litragem, tl.tipo_litragem, c.idcusto, c.valor AS valorCusto, tc.idtipo_custo, tc.tipo_custo, p.idparcelamento, p.data_pagamento, p.data_vencimento, p.juros, p.parcelas FROM Pinga.entrada e INNER JOIN Pinga.tipo_litragem tl ON e.tipo_litragem_idtipo_litragem = tl.idtipo_litragem INNER JOIN Pinga.custo c ON e.custo_idcusto = c.idcusto INNER JOIN Pinga.tipo_custo tc ON c.tipo_custo_idtipo_custo = tc.idtipo_custo INNER JOIN Pinga.parcelamento p ON e.parcelamento_idparcelamento = p.idparcelamento WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    e.identrada = Guid.Parse(read["identrada"].ToString());
                    e.data = DateTime.Parse(read["data"].ToString());
                    e.litragem = (int)read["litragem"];
                    e.created = DateTime.Parse(read["created"].ToString());
                    if (!string.IsNullOrEmpty(read["modified"].ToString()))
                    {
                        e.modified = DateTime.Parse(read["modified"].ToString());
                    }
                    e.tipoLitragemIdtipoLitragem.idtipoLitragem = Guid.Parse(read["idtipo_litragem"].ToString());
                    e.tipoLitragemIdtipoLitragem.tipoLitragem = read["tipo_litragem"].ToString();
                    e.custoIdcusto.idcusto = Guid.Parse(read["idcusto"].ToString());
                    e.custoIdcusto.valor = (decimal)read["valorCusto"];
                    e.custoIdcusto.tipoCustoIdtipoCusto.idtipoCusto = Guid.Parse(read["idtipo_custo"].ToString());
                    e.custoIdcusto.tipoCustoIdtipoCusto.tipoCusto = read["tipo_custo"].ToString();
                    e.parcelamentoIdparcelamento.idparcelamento = Guid.Parse(read["idparcelamento"].ToString());
                    e.parcelamentoIdparcelamento.dataPagamento = DateTime.Parse(read["data_pagamento"].ToString());
                    e.parcelamentoIdparcelamento.dataVencimento = DateTime.Parse(read["data_vencimento"].ToString());
                    e.parcelamentoIdparcelamento.juros = (decimal)read["juros"];
                    e.parcelamentoIdparcelamento.parcelas = (int)read["parcelas"];
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return e;
        }
    }
}
