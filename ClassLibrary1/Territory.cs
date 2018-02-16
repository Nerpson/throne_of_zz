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
        public String Name
        { get; set; }

        public House Owner
        { get; set; }

        public Territory(String name,TerritoryType territoryType)
        {
            Name = name;
            TerritoryType = territoryType;
        }
    }
}
