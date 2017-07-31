using BLL.Classes;
using System;
using System.Collections.Generic;

namespace BLL.Logic
{
    public sealed class ClsEmailDominioBO : IGeneric<ClsEmailDominio>
    {
        private static ClsEmailDominio e = null;

        public ClsEmailDominioBO()
        {
            e = new ClsEmailDominio();
        }

        public ClsEmailDominioBO(ClsEmailDominio emailDominioClass)
        {
            e = emailDominioClass ?? new ClsEmailDominio();
        }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEmailDominio> Visualizar()
        {
            return null;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(e.emailDominio.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o Dominio do email");
                }
                else if (e.status != true && e.status != false)
                {
                    throw new ArgumentNullException("Por favor informe o status do Dominio do email");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (e.idemailDominio.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do Dominio do email");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsEmailDominio BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
