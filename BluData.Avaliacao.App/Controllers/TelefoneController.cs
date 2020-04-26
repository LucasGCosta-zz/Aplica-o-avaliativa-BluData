using BluData.Avaliacao.App.Models;
using BluData.Avaliacao.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BluData.Avaliacao.App.Controllers
{
    public class TelefoneController : EntityController<Telefone>
    {
        public TelefoneController(IRepository<Telefone> repository)
            : base(repository)
        {

        }
    }
}