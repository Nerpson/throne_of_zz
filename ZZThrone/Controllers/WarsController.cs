using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ZZThrone.Models;

namespace ZZThrone.Controllers
{
    public class WarsController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET api/<controller>
        public IEnumerable<WarDto> Get()
        {
            return _manager.GetAllWars().Select(h => h.ToDto<WarDto>());
        }

        // GET api/<controller>/5
        public IEnumerable<WarDto> Get(int id)
        {
            return _manager.GetWarById(id).Select(h => h.ToDto<WarDto>());
        }

        // POST api/<controller>
        public void Post([FromBody]WarDto war)
        {
            _manager.PostWar(war.ToDto<War>());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]WarDto war)
        {
            _manager.PutWar(id, war.ToDto<War>());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _manager.DeleteWar(id);
        }
    }
}