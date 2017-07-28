using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEmailLocalidade : IGeneric<ClsEmailLocalidade>
    {
        public Guid idemailLocalidade { get; set; }
        public string emailLocalidade { get; set; }
        public bool status { get; set; }

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
                if (string.IsNullOrEmpty(emailLocalidade.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a Localidade do email");
                }
                else if (status != true && status != false)
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
                if (idemailLocalidade.ToString() == "00000000-0000-0000-0000-000000000000")
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
