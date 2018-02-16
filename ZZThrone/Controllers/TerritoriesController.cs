using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThroneAPI.Controllers
{
    public class TerritoriesController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET api/<controller>
        public IEnumerable<TerritoryDto> Get()
        {
            return _manager.getTerritories().Select(h => h.toDto<TerritoryDto>());
        }

        // GET api/<controller>/5
        public IEnumerable<TerritoryDto> Get(int id)
        {
            return _manager.getTerritory(id).Select(h => h.toDto<TerritoryDto>());
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}