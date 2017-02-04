using System.Collections.Generic;

namespace BLL.Classes
{
    interface IGeneric<T>
    {
        void Inserir();

        void Alterar();

        void Apagar();

        List<T> Visualizar();
    }
}
