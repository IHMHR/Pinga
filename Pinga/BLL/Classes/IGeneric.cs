using System.Collections.Generic;

namespace BLL.Classes
{
    public interface IGeneric<T>
    {
        void Inserir();

        void Alterar();

        void Apagar();

        List<T> Visualizar();

        void ValidarClasse(CRUD crud);
    }

    public enum CRUD
    {
        insert,
        delete,
        update
    }
}
