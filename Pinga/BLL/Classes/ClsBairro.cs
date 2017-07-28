using System;

namespace BLL.Classes
{
    public sealed class ClsBairro
    {
        public Guid idbairro { get; set; }
        public string bairro { get; set; }
        public string regiao { get; set; }
        public ClsCidade cidadeIdcidade { get; set; }

        public ClsBairro()
        {
            cidadeIdcidade = new ClsCidade();
        }      
    }
}
