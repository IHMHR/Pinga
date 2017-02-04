using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClassLibrary1.Classes
{
    class ClsLogin
    {
        private static Dictionary<string, object> retorno = new Dictionary<string, object>();

        public ClsLogin()
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
            using (SqlConnection con = new SqlConnection(ClassLibrary1.Properties.Resources.connStringWinAut))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "SELECT 1 FROM adm.login WHERE lgn = @login AND pwd = @pwd AND ativo = 1;";
                com.Parameters.AddWithValue("@login", txtUser.Text.Trim().Replace("'", "\'"));
                com.Parameters.AddWithValue("@pwd", Classes.ClsGlobal.CalculateSHA1(txtPwd.Text.Trim().Replace("'", "\'")));
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

        private Dictionary<string, string> obterInfo()
        {
            var retorno = new Dictionary<string, string>();
            retorno.Add("Nome", "Igor");
            retorno.Add("SobreNome", "Martinelli");
            retorno.Add("Idade", "20");
            return retorno;
        }
    }
}
