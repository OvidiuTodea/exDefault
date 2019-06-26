using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exDefault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private IEntitiesService entityService;
        public EntitiesController(IEntitiesService entityService)
        {
            this.entityService = entityService;
        }

        /// <summary>
        /// Gets all the entities.
        /// </summary>
        /// <param name="from">Optional, filter by minimum DatePicked.</param>
        /// <param name="to">Optional, filter by maximum DatePicked.</param>
        /// <returns>A list of Flower objects.</returns>
        [HttpGet]
        public IEnumerable<EntityGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            return entityService.GetAll(from, to);
        }

        // GET: api/Entities/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var found = entityService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] EntityPostModel entity)
        {
            entityService.Create(entity);
        }

        // PUT: api/Flowers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entity entity)
        {
            var result = entityService.Upsert(id, entity);
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = entityService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}