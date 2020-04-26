using BluData.Avaliacao.App.Models;
using BluData.Avaliacao.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BluData.Avaliacao.App.Controllers
{
    public class FornecedorController : EntityController<Fornecedor>
    {
        public FornecedorController(IRepository<Fornecedor> repository)
            : base(repository)
        {

        }

        [HttpGet("{id}/telefones")]
        public ActionResult<object> Telefones(int id)
        {
            return Ok(new { telefones = _repository.Find(id).Telefones });
        }
    }
}
