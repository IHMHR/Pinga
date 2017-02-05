﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsContinente : IGeneric<ClsContinente>
    {
        public Guid idcontinente { get; set; }
        public string continente { get; set; }
        public ClsTipoContinente tipoContinenteIdtipoContinente { get; set; }

        public ClsContinente()
        {
            tipoContinenteIdtipoContinente = new ClsTipoContinente();
        }

        public void Inserir()
        {
            if (string.IsNullOrEmpty(continente.Trim()))
            {
                throw new ArgumentNullException("Por favor informe o continente.");
            }
            else if(tipoContinenteIdtipoContinente == null)
            {
                throw new ArgumentNullException("Por favor informe o tipo de continente.");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Pinga.usp_InserirNovoContinente";
                    com.Parameters.AddWithValue("@continente", continente);
                    com.Parameters.AddWithValue("@tipoContienteidtipoContinente", tipoContinenteIdtipoContinente.idtipoContinente);

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
            if (string.IsNullOrEmpty(continente.Trim()))
            {
                throw new ArgumentNullException("Por favor informe o continente.");
            }
            else if (tipoContinenteIdtipoContinente == null)
            {
                throw new ArgumentNullException("Por favor informe o tipo de continente.");
            }
            else if (idcontinente == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do continente.");
            }

            using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "UPDATE Pinga.continente SET continente = @continente, tipo_continente_idtipo_continente = @idtipoContinente WHERE idcontinente = @id";
                com.Parameters.AddWithValue("@id", idcontinente);
                com.Parameters.AddWithValue("@continente", continente);
                com.Parameters.AddWithValue("@idtipoContinente", tipoContinenteIdtipoContinente.idtipoContinente);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Apagar()
        {
            if (idcontinente == null)
            {
                throw new ArgumentNullException("Por favor informe o ID do continente.");
            }

            using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "DELETE FROM Pinga.continente WHERE idcontinente = @id";
                com.Parameters.AddWithValue("@id", idcontinente);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<ClsContinente> Visualizar()
        {
            List<ClsContinente> retorno = new List<ClsContinente>();
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT c.idcontinente, c.continente, tc.idtipo_continente, tc.tipo_continente, tc.ativo "
                                    + "FROM Pinga.continente c INNER JOIN Pinga.tipo_continente tc ON c.tipo_continente_idtipo_continente = tc.idtipo_continente "
                                    + "ORDER BY c.continente ASC, tc.ativo DESC;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsContinente cont = new ClsContinente();
                        cont.idcontinente = Guid.Parse(read["idcontinente"].ToString());
                        cont.continente = read["continente"].ToString();
                        cont.tipoContinenteIdtipoContinente.idtipoContinente = Guid.Parse(read["idtipo_continente"].ToString());
                        cont.tipoContinenteIdtipoContinente.tipoContinente = read["tipo_continente"].ToString();
                        cont.tipoContinenteIdtipoContinente.ativo = (bool)read["ativo"];

                        retorno.Add(cont);
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