using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Classes
{
    public sealed class ClsLoginBO
    {
        private static Dictionary<string, object> retorno = new Dictionary<string, object>();

        public string usuario { get; set; }
        public string senha { get; set; }

        public ClsLoginBO()
        {
            retorno.Add("Acao", false);
            retorno.Add("Mensagem", "Falha no login");
        }

        public Dictionary<string, object> logar()
        {
            if (realizarLogin())
            {
                retorno["Acao"] = true;
                retorno["Mensagem"] = "Login realizado com sucesso";
                retorno.Add("Dados", obterInfo());
            }

            return retorno;
        }

        private bool realizarLogin()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(BLL.Properties.Settings.Default.connStringUserAut))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "SELECT 1 FROM adm.login WHERE lgn = @login AND pwd = @pwd AND status = 1;";
                    com.Parameters.AddWithValue("@login", usuario.Trim().Replace("'", "\'"));
                    com.Parameters.AddWithValue("@pwd", CalculateSHA1(senha.Trim().Replace("'", "\'")));
                    con.Open();
                    com.Connection = con;
                    object result = com.ExecuteScalar();
                    con.Close();
                    con.Dispose();

                    if (result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Dictionary<string, string> obterInfo()
        {
            var retorno = new Dictionary<string, string>();
            retorno.Add("Nome", "Igor");
            retorno.Add("SobreNome", "Martinelli");
            retorno.Add("Idade", "20");
            return retorno;
        }

        public static string CalculateSHA1(string text)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
                string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
                return hash;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
    }
}
