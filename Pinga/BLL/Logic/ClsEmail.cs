using BLL.Classes;
using System;
using System.Collections.Generic;

namespace BLL.Logic
{
    public sealed class ClsEmailBO : IGeneric<ClsEmail>
    {
        private static ClsEmail e = null;

        public ClsEmailBO()
        {
            e = new ClsEmail();
        }

        public ClsEmailBO(ClsEmail emailClass)
        {
            e = emailClass ?? new ClsEmail();
        }
        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEmail> Visualizar()
        {
            return null;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(e.email.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o email");
                }
                else if (e.emailDominioIdemailDominio.idemailDominio.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o dominio do email");
                }
                else if (e.emailLocalidadeIdemailLocalidade.idemailLocalidade.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe a localidade do email");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (e.idemail.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID do email");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsEmail BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
