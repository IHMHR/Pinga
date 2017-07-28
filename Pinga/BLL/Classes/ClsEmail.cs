using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsEmail
    {
        public Guid idemail { get; set; }
        public string email { get; set; }
        public ClsEmailDominio emailDominioIdemailDominio { get; set; }
        public ClsEmailLocalidade emailLocalidadeIdemailLocalidade { get; set; }

        public ClsEmail()
        {
            emailDominioIdemailDominio = new ClsEmailDominio();
            emailLocalidadeIdemailLocalidade = new ClsEmailLocalidade();
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
                if (string.IsNullOrEmpty(email.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe o email");
                }
                else if (emailDominioIdemailDominio.idemailDominio.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o dominio do email");
                }
                else if (emailLocalidadeIdemailLocalidade.idemailLocalidade.ToString() == "00000000-0000-0000-0000-000000000000")
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
                if (idemail.ToString() == "00000000-0000-0000-0000-000000000000")
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
