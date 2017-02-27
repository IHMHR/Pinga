using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEstoque : IGeneric<ClsEstoque>
    {
        public Guid idestoque { get; set; }
        public ClsProduto produtoIdproduto { get; set; }
        public int quantidade { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEstoque> Visualizar()
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
