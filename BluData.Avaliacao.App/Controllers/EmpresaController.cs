using BluData.Avaliacao.App.Models;
using BluData.Avaliacao.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluData.Avaliacao.App.Controllers
{
    public class EmpresaController : EntityController<Empresa>
    {
        public EmpresaController(IRepository<Empresa> repository)
            : base(repository)
        {

        }
    }
}
