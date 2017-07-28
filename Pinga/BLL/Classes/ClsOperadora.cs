using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.Classes
{
    public sealed class ClsOperadora
    {
        public Guid idoperadora { get; set; }
        public string operadora { get; set; }
        public string razaoSocial { get; set; }
        public bool status { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsOperadora> Visualizar()
        {
            List<ClsOperadora> retorno = new List<ClsOperadora>();

            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idoperadora, operadora, razao_social, [status] FROM Pinga.operadora";
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ClsOperadora op = new ClsOperadora();
                        op.idoperadora = Guid.Parse(read["idoperadora"].ToString());
                        op.operadora = read["operadora"].ToString();
                        op.razaoSocial = read["razao_social"].ToString();
                        op.status = (bool)read["status"];

                        retorno.Add(op);
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
                if (string.IsNullOrEmpty(operadora.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a operadora.");
                }
                else if (string.IsNullOrEmpty(razaoSocial.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a Razão Social.");
                }
                else if (status != true && status != false)
                {
                    throw new ArgumentNullException("Por favor informe o Status.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idoperadora.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID da Operadora.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsOperadora BuscaPeloId(Guid rowGuidCol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT idoperadora, operadora, razao_social, [status] FROM Pinga.operadora WHERE rowguicol = @id";
                    com.Parameters.AddWithValue("@id", rowGuidCol);
                    con.Open();
                    com.Connection = con;

                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    idoperadora = Guid.Parse(read["idoperadora"].ToString());
                    operadora = read["operadora"].ToString();
                    razaoSocial = read["razao_social"].ToString();
                    status = (bool)read["status"];
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
