using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZZThrone.Models
{
    public class FightDto
    {
        public HouseDto HouseChallenging
        { get; set; }

        public HouseDto HouseChallenged
        { get; set; }

        public HouseDto WinningHouse
        { get; set; }
    }
}