using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEmailLocalidade : IGeneric<ClsEmailLocalidade>
    {
        public Guid idemailLocalidade { get; set; }
        public string emailLocalidade { get; set; }
        public bool status { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEmailLocalidade> Visualizar()
        {
            return null;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
            }
            else if (crud == CRUD.update)
            {

            }
            else if (crud == CRUD.delete)
            {

            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }
    }
}
