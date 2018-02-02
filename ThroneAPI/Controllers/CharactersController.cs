using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThroneAPI.Controllers
{
    public class CharactersController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET api/<controller>
        public IEnumerable<CharacterDto> Get()
        {
            return _manager.getCharacters().Select(h => h.toDto<CharacterDto>());
        }

        // GET api/<controller>/5
        public IEnumerable<CharacterDto> Get(int id)
        {
            return _manager.getCharacter(id).Select(h => h.toDto<CharacterDto>());
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