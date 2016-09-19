using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        public static System.Data.DataTable PopularGrid(string sql)
        {
            if (!string.IsNullOrWhiteSpace(sql))
            {
                try
                {
                    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Server = .\SQLExpress; Database = PingaDB; Trusted_Connection = True;"))
                    {
                        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
                        System.Data.DataTable dt = new System.Data.DataTable();
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
