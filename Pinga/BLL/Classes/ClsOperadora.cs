using System;

namespace BLL.Classes
{
    public sealed class ClsOperadora
    {
        public Guid idoperadora { get; set; }
        public string operadora { get; set; }
        public string razaoSocial { get; set; }
        public bool status { get; set; }
    }
}
