using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZZThrone.Models;

namespace ThroneAPI.Controllers
{
    public class TerritoriesController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET api/<controller>
        public IEnumerable<TerritoryDto> Get()
        {
            return _manager.GetAllTerritories().Select(h => h.ToDto<TerritoryDto>());
        }

        // GET api/<controller>/5
        public IEnumerable<TerritoryDto> Get(int id)
        {
            return _manager.GetTerritoryById(id).Select(h => h.ToDto<TerritoryDto>());
        }

        // POST api/<controller>
        public void Post([FromBody]TerritoryDto territory)
        {
            _manager.PostTerritory(territory.ToDto<Territory>());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]TerritoryDto territory)
        {
            _manager.PutTerritory(id, territory.ToDto<Territory>());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _manager.DeleteTerritory(id);
        }
    }
}