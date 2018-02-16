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
    public class FightsController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET api/<controller>
        public IEnumerable<FightDto> Get()
        {
            return _manager.GetAllFights().Select(h => h.ToDto<FightDto>());
        }

        // GET api/<controller>/5
        public IEnumerable<FightDto> Get(int id)
        {
            return _manager.GetFightById(id).Select(h => h.ToDto<FightDto>());
        }

        // POST api/<controller>
        public void Post([FromBody]FightDto fight)
        {
            _manager.PostFight(fight.ToDto<Fight>());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]FightDto fight)
        {
            _manager.PutFight(id, fight.ToDto<Fight>());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _manager.DeleteFight(id);
        }
    }
    }
}