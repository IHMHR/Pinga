using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsInformacoesCliente : IGeneric<ClsInformacoesCliente>
    {
        public Guid idinformacoesCliente { get; set; }
        public ClsCliente clienteIdcliente { get; set; }
        public string tipoCliente { get; set; }
        public bool visitado { get; set; }
        public Nullable<DateTime> created { get; set; }
        public Nullable<DateTime> modified { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsInformacoesCliente> Visualizar()
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
