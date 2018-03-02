using EntitiesLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class EntitiesTest
    {
        [TestMethod]
        public void Houses()
        {
            House h = new House("Name",14);
            Assert.AreEqual(h.Name, "Name");
            Assert.AreEqual(h.NumberOfUnits, 14);
            h.NumberOfUnits = 12;
            Assert.AreEqual(h.NumberOfUnits, 12);
        }
        [TestMethod]
        public void Character()
        {
            Character c = new Character();
            Assert.AreEqual(0,c.Bravoury);
            Assert.AreEqual(0,c.Crazyness);
            Assert.AreEqual(null, c.FirstName);

            Character c2 = new Character(12, 15, "FName", "LName", 55);
            Assert.AreEqual(55, c2.Pv);
            Assert.AreEqual(15, c2.Crazyness);
            Assert.AreEqual("FName", c2.FirstName);
            Assert.AreEqual("LName", c2.LastName);
        }



    }
}
