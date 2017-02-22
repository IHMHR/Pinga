using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace PingaSolution.Classes
{
    public static class ClsGlobal
    {
        public static string nome { get; set; }
        public static string sobrenome { get; set; }
        public static int idade { get; set; }

        public static int qntProdutos { get; set; }
        public static int pointX { get; set; }
        public static int pointY { get; set; }

        public static void ClearForm(GroupBox gpb)
        {
            gpb.Controls.OfType<TextBox>().ToList().ForEach(txt => txt.Clear());
            gpb.Controls.OfType<ComboBox>().ToList().ForEach(cmb => cmb.SelectedIndex = -1);
            gpb.Controls.OfType<CheckBox>().ToList().ForEach(chk => chk.Checked = false);
            gpb.Controls.OfType<RadioButton>().ToList().ForEach(rdb => rdb.Checked = false);
        }

        public static bool somenteNumero(object input)
        {
            try
            {
                Convert.ToInt16(input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
