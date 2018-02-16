using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZZThrone.Models
{
    public class CharacterDto
    {
        public int ID { get; set; }
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Pv { get; set; }
        // TODO public Dictionary<RelationShipEnum, List<Character>> RelationShips { get; set; }
    }
}