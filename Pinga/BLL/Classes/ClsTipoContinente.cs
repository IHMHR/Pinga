﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsTipoContinente : IGeneric<ClsTipoContinente>
    {
        #region Atributos
        public Guid idtipoContinente { get; set; }
        public string tipoContinente { get; set; }
        public bool ativo { get; set; }
        #endregion

        #region CRUD Functions
        public void Inserir()
        {
            if(string.IsNullOrEmpty(tipoContinente.Trim()))
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
                    com.CommandText = "Pinga.usp_InserirNovoTipoContinente";
                    com.Parameters.AddWithValue("@tipoContinente", tipoContinente);
                    com.Parameters.AddWithValue("@ativo", ativo);

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
            if (string.IsNullOrEmpty(idtipoContinente.ToString()))
            {
                throw new ArgumentNullException("Por favor informe o ID do tipo de continente.");
            }
            else if (string.IsNullOrEmpty(tipoContinente.Trim()))
            {
                throw new ArgumentNullException("Por favor informe o tipo de continente.");
            }
            else if(ativo != false && ativo != true)
            {
                throw new ArgumentNullException("Por favor informe se o tipo de continente está ativo.");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Pinga.tipo_continente SET tipo_continente = @tipoContinente, ativo = @ativo WHERE idtipo_continente = @id";
                    com.Parameters.AddWithValue("@id", idtipoContinente);
                    com.Parameters.AddWithValue("@tipoContinente", tipoContinente);
                    com.Parameters.AddWithValue("@ativo", ativo);

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
            if (string.IsNullOrEmpty(idtipoContinente.ToString()))
            {
                throw new ArgumentNullException("Por favor informe o ID do tipo de continente.");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Pinga.tipo_continente WHERE idtipo_continente = @id";
                    com.Parameters.AddWithValue("@id", idtipoContinente);

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

        public List<ClsTipoContinente> Visualizar()
        {
            List<ClsTipoContinente> retorno = new List<ClsTipoContinente>();
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtipo_continente AS idtipoContinente, tipo_continente AS tipoContinente, ativo "
                                    + "FROM Pinga.tipo_continente ORDER BY tipo_continente ASC, ativo DESC;";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsTipoContinente tipoCont = new ClsTipoContinente();
                        tipoCont.idtipoContinente = Guid.Parse(read["idtipoContinente"].ToString());
                        tipoCont.tipoContinente = read["tipoContinente"].ToString();
                        tipoCont.ativo = (bool)read["ativo"];

                        retorno.Add(tipoCont);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return retorno;
        }
        #endregion
    }
}