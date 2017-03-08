using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsEntrada : IGeneric<ClsEntrada>
    {
        public Guid identrada { get; set; }
        public DateTime data { get; set; }
        public int litragem { get; set; }
        public ClsTipoLitragem tipoLitragemIdtipoLitragem { get; set; }
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
                    com.Parameters.AddWithValue("@data", data);
                    com.Parameters.AddWithValue("@litragem", litragem);
                    com.Parameters.AddWithValue("@tipoLitragemIdtipoLitragem", tipoLitragemIdtipoLitragem.idtipoLitragem);
                    com.Parameters.AddWithValue("@custoIdcusto", custoIdcusto.idcusto);
                    com.Parameters.AddWithValue("@parcelamentoIdparcelamento", parcelamentoIdparcelamento.idparcelamento);

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
            if (identrada == null)
            {
                throw new ArgumentNullException("Por favor informe a ID da Entrada");
            }
            else if (string.IsNullOrEmpty(data.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Data");
            }
            else if (string.IsNullOrEmpty(litragem.ToString()))
            {
                throw new ArgumentNullException("Por favor informe a Litragem");
            }
            else if (custoIdcusto == null)
            {
                throw new ArgumentNullException("Por favor informe o Custo");
            }
            else if (parcelamentoIdparcelamento == null)
            {
                throw new ArgumentNullException("Por favor informe o Parcelametno");
            }
            else if (tipoLitragemIdtipoLitragem == null)
            {
                throw new ArgumentNullException("Por favor informe o Tipo Litragem");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.entrada SET data = @data, litragem = @litragem, tipo_litragem_idtipo_litragem = @tipoLitragemIdtipoLitragem, custo_idcusto = @custoIdcusto, parcelamento_idparcelamento = @parcelamentoIdparcelamento WHERE identrada = @id";
                    com.Parameters.AddWithValue("@id", identrada);
                    com.Parameters.AddWithValue("@data", data);
                    com.Parameters.AddWithValue("@litragem", litragem);
                    com.Parameters.AddWithValue("@tipoLitragemIdtipoLitragem", tipoLitragemIdtipoLitragem.idtipoLitragem);
                    com.Parameters.AddWithValue("@custoIdcusto", custoIdcusto.idcusto);
                    com.Parameters.AddWithValue("@parcelamentoIdparcelamento", parcelamentoIdparcelamento.idparcelamento);

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
                    com.Parameters.AddWithValue("@id", identrada);

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
                if (string.IsNullOrEmpty(data.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe a Data");
                }
                else if (string.IsNullOrEmpty(litragem.ToString()))
                {
                    throw new ArgumentNullException("Por favor informe a Litragem");
                }
                else if (custoIdcusto == null)
                {
                    throw new ArgumentNullException("Por favor informe o Custo");
                }
                else if (parcelamentoIdparcelamento.idparcelamento.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o Parcelametno");
                }
                else if (tipoLitragemIdtipoLitragem.idtipoLitragem.ToString() == "00000000-0000-0000-0000-000000000000")
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
                if (identrada.ToString() == "00000000-0000-0000-0000-000000000000")
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
                    identrada = Guid.Parse(read["identrada"].ToString());
                    data = DateTime.Parse(read["data"].ToString());
                    litragem = (int)read["litragem"];
                    created = DateTime.Parse(read["created"].ToString());
                    if (!string.IsNullOrEmpty(read["modified"].ToString()))
                    {
                        modified = DateTime.Parse(read["modified"].ToString());
                    }
                    tipoLitragemIdtipoLitragem.idtipoLitragem = Guid.Parse(read["idtipo_litragem"].ToString());
                    tipoLitragemIdtipoLitragem.tipoLitragem = read["tipo_litragem"].ToString();
                    custoIdcusto.idcusto = Guid.Parse(read["idcusto"].ToString());
                    custoIdcusto.valor = (decimal)read["valorCusto"];
                    custoIdcusto.tipoCustoIdtipoCusto.idtipoCusto = Guid.Parse(read["idtipo_custo"].ToString());
                    custoIdcusto.tipoCustoIdtipoCusto.tipoCusto = read["tipo_custo"].ToString();
                    parcelamentoIdparcelamento.idparcelamento = Guid.Parse(read["idparcelamento"].ToString());
                    parcelamentoIdparcelamento.dataPagamento = DateTime.Parse(read["data_pagamento"].ToString());
                    parcelamentoIdparcelamento.dataVencimento = DateTime.Parse(read["data_vencimento"].ToString());
                    parcelamentoIdparcelamento.juros = (decimal)read["juros"];
                    parcelamentoIdparcelamento.parcelas = (int)read["parcelas"];
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
