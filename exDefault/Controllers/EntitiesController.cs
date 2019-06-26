using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exDefault.Models;
using exDefault.Services;
using exDefault.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exDefault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private IEntityService entityService;
        public EntitiesController(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        /// <summary>
        /// Gets all the entities.
        /// </summary>
        /// <param name="from">Optional, filter by minimum DatePicked.</param>
        /// <param name="to">Optional, filter by maximum DatePicked.</param>
        /// <returns>A list of Entities objects.</returns>
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <remarks>
        /// Sample request - POST
        /// 
        /// {
        ///        "name": "string",
        ///        "isOrNot": true,
        ///        "dateOn": "2019-06-26T19:41:41.005Z",
        ///        "dateOff": "2019-06-26T19:41:41.005Z",
        ///        "entityType": "string",
        ///        "comments" : [
        ///            {
        ///                "text": "test",
        ///                "important" : true
        ///                },
        ///            {
        ///                "text": "test1",
        ///                "important" : false
        ///                }
        ///            ]
        ///      }
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] EntityPostModel entity)
        {
            entityService.Create(entity);
        }

        // PUT: api/Entities/5
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