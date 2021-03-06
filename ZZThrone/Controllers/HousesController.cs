﻿using BusinessLayer;
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
    public class HousesController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET: api/Houses
        public IEnumerable<HouseDto> Get()
        {
            return _manager.GetBigHouses().Select(h => h.ToDto<HouseDto>());
        }

        // GET: api/Houses/5
        public IEnumerable<HouseDto> Get(int id)
        {
            return _manager.GetHouseById(id).Select(HashSet => HashSet.ToDto<HouseDto>());
        }

        // POST: api/Houses
        public void Post([FromBody]HouseDto house)
        {
            _manager.PostHouse(house.ToDto<House>());
        }

        // PUT: api/Houses/5
        public void Put(int id, [FromBody]HouseDto house)
        {
            _manager.PutHouse(id, house.ToDto<House>());
        }

        // DELETE: api/Houses/5
        public void Delete(int id)
        {
            _manager.DeleteHouse(id);
        }
    }
}
