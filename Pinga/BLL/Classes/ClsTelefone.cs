using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsTelefone : IGeneric<ClsTelefone>
    {
        #region Atributos
        public Guid idtelefone { get; set; }
        public string telefone { get; set; }
        public ClsCidade cidadeDDD { get; set; }
        public ClsTipoTelefone tipoTelefoneIdtipoTelefone { get; set; }
        public ClsOperadora operadoraIdoperadora { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }
        #endregion

        public ClsTelefone()
        {
            cidadeDDD = new ClsCidade();
            tipoTelefoneIdtipoTelefone = new ClsTipoTelefone();
            operadoraIdoperadora = new ClsOperadora();
        }

        #region CRUD Functions
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
                    com.CommandText = "Pinga.usp_InserirNovoTelefone";
                    com.Parameters.AddWithValue("@telefone", telefone);
                    com.Parameters.AddWithValue("@cidadeDDD", cidadeDDD.idcidade);
                    com.Parameters.AddWithValue("@tipoTelefoneIdtipoTelefone", tipoTelefoneIdtipoTelefone.idtipoTelefone);
                    com.Parameters.AddWithValue("@operadoraIdoperadora", operadoraIdoperadora.idoperadora);

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
                    com.CommandText = "UPDATE Pinga.telefone SET telefone = @telefone, cidade_ddd = @cidadeDDD, tipo_telefone_idtipo_telefone = @tipoTelefoneIdtipoTelefone, operadora_idoperadora = @operadoraIdoperadora WHERE idtelefone = @id";
                    com.Parameters.AddWithValue("@telefone", telefone);
                    com.Parameters.AddWithValue("@cidadeDDD", cidadeDDD.idcidade);
                    com.Parameters.AddWithValue("@tipoTelefoneIdtipoTelefone", tipoTelefoneIdtipoTelefone.idtipoTelefone);
                    com.Parameters.AddWithValue("@operadoraIdoperadora", operadoraIdoperadora.idoperadora);
                    com.Parameters.AddWithValue("@id", idtelefone);

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
                    com.CommandText = "DELETE FROM Pinga.telefone WHERE idtelefone = @id";
                    com.Parameters.AddWithValue("@id", idtelefone);

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

        public List<ClsTelefone> Visualizar()
        {
            List<ClsTelefone> retorno = new List<ClsTelefone>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idtelefone, telefone, idcidade, cidade, DDD, idtipo_telefone, tipo_telefone, idoperadora, operadora, created, modified FROM Pinga.telefone t INNER JOIN Pinga.cidade c ON t.cidade_ddd = c.idcidade INNER JOIN Pinga.tipo_telefone tt ON t.tipo_telefone_idtipo_telefone = tt.idtipo_telefone INNER JOIN Pinga.operadora o ON t.operadora_idoperadora = o.idoperadora";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsTelefone tel = new ClsTelefone();
                        tel.idtelefone = Guid.Parse(read["idtelefone"].ToString());
                        tel.telefone = read["telefone"].ToString();
                        tel.created = DateTime.Parse(read["created"].ToString());
                        if(!string.IsNullOrEmpty(read["modified"].ToString()))
                        {
                            tel.modified = DateTime.Parse(read["modified"].ToString());
                        }
                        tel.tipoTelefoneIdtipoTelefone.idtipoTelefone = Guid.Parse(read["idtipotelefone"].ToString());
                        tel.tipoTelefoneIdtipoTelefone.tipoTelefone = read["tipo_telefone"].ToString();
                        tel.operadoraIdoperadora.idoperadora = Guid.Parse(read["idoperadora"].ToString());
                        tel.operadoraIdoperadora.operadora = read["operadora"].ToString();
                        tel.cidadeDDD.idcidade = Guid.Parse(read["idcidade"].ToString());
                        tel.cidadeDDD.DDD = read["DDD"].ToString();
                        tel.cidadeDDD.cidade = read["cidade"].ToString();

                        retorno.Add(tel);
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
                if (string.IsNullOrEmpty(telefone))
                {
                    throw new ArgumentNullException("Por favor informe o Telefone");
                }
                else if (cidadeDDD.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o DDD");
                }
                else if (tipoTelefoneIdtipoTelefone.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o Tipo Telefnoe");
                }
                else if (operadoraIdoperadora.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a Operadora");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idtelefone.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do Telefone");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }
        #endregion
    }
}
