using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Territory : EntityObject
    {
        public TerritoryType TerritoryType;

        public Territory(TerritoryType territoryType)
        {
            TerritoryType = territoryType;
        }

        public House Owner { get; set; }
    }
}
