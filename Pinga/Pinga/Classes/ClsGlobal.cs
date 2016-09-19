using System;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Pinga.Classes
{
    public static class ClsGlobal
    {
        public static string login { get; set; }

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

        public static DataTable PopularGrid(string sql)
        {
            if (!string.IsNullOrWhiteSpace(sql))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sql, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Erro desconhecido ao listar");
                }
            }
            return null;
        }
    }
}
