using System;
using System.Collections.Generic;

namespace BLL.Classes
{
    public sealed class ClsOperadora : IGeneric<ClsOperadora>
    {
        public Guid idoperadora { get; set; }
        public string operadora { get; set; }
        public string razaoSocial { get; set; }
        public bool status { get; set; }

        public void Inserir()
        { }

        public void Alterar()
        { }

        public void Apagar()
        { }

        public List<ClsOperadora> Visualizar()
        {
            return null;
        }

        public void ValidarClasse(CRUD crud)
        {
            if (crud == CRUD.insert)
            {
                if (string.IsNullOrEmpty(operadora.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a operadora.");
                }
                else if (string.IsNullOrEmpty(razaoSocial.Trim()))
                {
                    throw new ArgumentNullException("Por favor informe a Razão Social.");
                }
                else if (status != true && status != false)
                {
                    throw new ArgumentNullException("Por favor informe o Status.");
                }
            }
            else if (crud == CRUD.update)
            {
                ValidarClasse(CRUD.insert);
                ValidarClasse(CRUD.delete);
            }
            else if (crud == CRUD.delete)
            {
                if (idoperadora.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    throw new ArgumentNullException("Por favor informe o ID da Operadora.");
                }
            }
            else
            {
                throw new ArgumentException("Falha interna do Programar ao informar qual operação deve ser validada.");
            }
        }

        public ClsOperadora BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }
    }
}
