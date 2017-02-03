using System.Data;

namespace ClassLibrary1.Classes
{
    interface IGeneric
    {
        void Inserir();

        void Alterar();

        void Apagar();

        DataTable Visualizar();
    }
}
