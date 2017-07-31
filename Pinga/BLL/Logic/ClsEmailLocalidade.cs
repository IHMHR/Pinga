using BLL.Classes;
using System;
using System.Collections.Generic;

namespace BLL.Logic
{
    public sealed class ClsEmailLocalidadeBO : IGeneric<ClsEmailLocalidade>
    {
        private static ClsEmailLocalidade e = null;

        public ClsEmailLocalidadeBO()
        {
            e = new ClsEmailLocalidade();
        }

        public ClsEmailLocalidadeBO(ClsEmailLocalidade emailLocalidadeClass)
        {
            e = emailLocalidadeClass ?? new ClsEmailLocalidade();
        }
        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsEmailLocalidade> Visualizar()
        {
            return null;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(e.emailLocalidade.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a Localidade do email");
                }
                else if (e.status != true && e.status != false)
                {
                    throw new ArgumentNullException("Por favor informe o status da Localidade do email");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (e.idemailLocalidade.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID da Localidade do email");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsEmailLocalidade BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
