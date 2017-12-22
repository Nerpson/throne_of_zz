using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Character : EntityObject
    {
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Pv { get; set; }
        public Dictionary<RelationShipEnum,List<Character>> RelationShips { get; set; }
   
        public Character(int bravoury, int crazyness, String fname, String lname, int pv)
        {
            this.Bravoury = bravoury;
            this.Crazyness = crazyness;
            this.FirstName = fname;
            this.LastName = lname;
            this.Pv = pv;
        }
        
    }
}
