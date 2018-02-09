﻿using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThroneAPI.Models;

namespace ThroneAPI.Controllers
{
    public class HousesController : ApiController
    {
        private ThronesTournamentManager _manager = new ThronesTournamentManager();

        // GET: api/Houses
        public IEnumerable<HouseDto> Get()
        {
            return _manager.getBigHouses().Select(h => h.toDto<HouseDto>());
        }

        // GET: api/Houses/5
        public IEnumerable<HouseDto> Get(int id)
        {
            return _manager.getHouseById(id).Select(HashSet => HashSet.toDto<HouseDto>());
        }

        // POST: api/Houses
        public void Post([FromBody]HouseDto house)
        {
            _manager.PostHouse(house.toDto<House>());
        }

        // PUT: api/Houses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Houses/5
        public void Delete(int id)
        {
        }
    }
}
