using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZZThrone.Models;

namespace ZZThrone.Controllers
{
    public class CharactersController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET api/<controller>
        public IEnumerable<CharacterDto> Get()
        {
            return _manager.GetAllCharacters().Select(h => h.ToDto<CharacterDto>());
        }

        // GET api/<controller>/5
        public IEnumerable<CharacterDto> Get(int id)
        {
            return _manager.GetCharacterById(id).Select(h => h.ToDto<CharacterDto>());
        }

        // POST api/<controller>
        public void Post([FromBody]CharacterDto character)
        {
            _manager.PostCharacter(character.ToDto<Character>());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]CharacterDto character)
        {
            _manager.PutCharacter(id, character.ToDto<Character>());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _manager.DeleteCharacter(id);
        }
    }
}