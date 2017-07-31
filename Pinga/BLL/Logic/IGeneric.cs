using System;
using System.Collections.Generic;

namespace BLL.Logic
{
    public interface IGeneric<T>
    {
        void Inserir();

        void Alterar();

        void Apagar();

        List<T> Visualizar();

        T BuscaPeloId(Guid rowGuidCol);

        void ValidarClasse(CRUD crud);
    }

    public enum CRUD
    {
        insert,
        delete,
        update
    }
}
