using BluData.Avaliacao.App.Extensions;
using BluData.Avaliacao.Database.DAL;
using BluData.Avaliacao.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluData.Avaliacao.App.Models
{
    public class EmpresaRepository : EntityRepository<Empresa>
    {
        public EmpresaRepository(BluDataContext context) 
            : base(context)
        {
        }
    }
}
