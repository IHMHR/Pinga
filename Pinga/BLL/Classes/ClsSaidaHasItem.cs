using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    class ClsSaidaHasItem : IGeneric<ClsSaidaHasItem>
    {
        public Guid idsaida_has_ { get; set; }

        public void Alterar()
        {
            throw new NotImplementedException();
        }

        public void Apagar()
        {
            throw new NotImplementedException();
        }

        public ClsSaidaHasItem BuscaPeloId(Guid rowGuidCol)
        {
            throw new NotImplementedException();
        }

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public void ValidarClasse(CRUD crud)
        {
            throw new NotImplementedException();
        }

        public List<ClsSaidaHasItem> Visualizar()
        {
            throw new NotImplementedException();
        }
    }
}
