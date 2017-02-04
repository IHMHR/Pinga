using System.Data;

namespace BLL.Classes
{
    interface IGeneric
    {
        void Inserir();

        void Alterar();

        void Apagar();

        DataTable Visualizar();
    }
}
