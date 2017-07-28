using System;

namespace BLL.Classes
{
    public sealed class ClsCidade
    {
        public Guid idcidade { get; set; }
        public string cidade { get; set; }
        public string DDD { get; set; }
        public bool capital { get; set; }
        public ClsEstado estadoIdestado { get; set; }

        public ClsCidade()
        {
            estadoIdestado = new ClsEstado();
        }
    }
}
