using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        public LinkedList<Character> Housers { get; set; }
        public String Name { get; set; }
        public int NumberOfUnits { get; set; }

        public House() { }

        public House(String name,int nbUnit)
        {
            this.Name = name;
            this.NumberOfUnits = nbUnit;
            Housers = new LinkedList<Character>();
        }

        override public String ToString()
        {
            var builder = new StringBuilder();
            builder.Append("House:");
            builder.Append(Name);
            builder.Append(" Units:");
            builder.Append(NumberOfUnits);
            return builder.ToString();
        }

    }


}
