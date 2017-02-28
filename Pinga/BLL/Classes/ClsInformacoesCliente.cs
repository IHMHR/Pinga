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
                if (clienteIdcliente.idcliente.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o cliente.");
                }
                else if (string.IsNullOrEmpty(tipoCliente.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o tipo cliente.");
                }
                else if (visitado != true && visitado != false)
                {
                    throw new ArgumentNullException("Por favor informe se cliente foi visitado.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idinformacoesCliente.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do continente.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }
    }
}
