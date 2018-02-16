using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        public House HouseChallenging
        { get; set; }

        public House HouseChallenged
        { get; set; }

        public House WinningHouse
        { get; set; }

        public Fight(House challenging, House challenged, House winning)
        {
            HouseChallenging    = challenging;
            HouseChallenged     = challenged;
            WinningHouse        = winning;
        }
    }
}
