using BluData.Avaliacao.App.Models;
using BluData.Avaliacao.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BluData.Avaliacao.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class EntityController<TEntity> : ControllerBase
         where TEntity : Entity, new()
    {
        protected readonly IRepository<TEntity> _repository;

        public EntityController(IRepository<TEntity> repository)
            => _repository = repository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual ActionResult<IEnumerable<TEntity>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual ActionResult<TEntity> GetEntity(int id)
        {
            TEntity entity = _repository.Find(id);

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual ActionResult<TEntity> PostEntity(TEntity entity)
        {
            _repository.Insert(entity);

            return CreatedAtAction(nameof(PostEntity), new TEntity() { Id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual ActionResult PutEntity(int id, TEntity entity)
        {
            if (!_repository.Update(id, entity))
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual ActionResult<TEntity> Delete(int id)
        {
            var (success, entity) = _repository.Delete(id);

            if (!success)
                return NotFound();

            return Ok(entity);
        }
    }
}
