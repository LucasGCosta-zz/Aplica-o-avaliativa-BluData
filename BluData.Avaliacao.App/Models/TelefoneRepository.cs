using BluData.Avaliacao.Database.DAL;
using BluData.Avaliacao.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace BluData.Avaliacao.App.Models
{
    public class TelefoneRepository : EntityRepository<Telefone>
    {
        public TelefoneRepository(BluDataContext context)
            :base(context)
        {

        }

    }
}
