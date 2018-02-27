using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using EntitiesLayer;
using System.Linq;
using System.Diagnostics;

namespace UnitTesting
{
    [TestClass]
    public class ThronesTournamentManagerTest
    {
        [TestMethod]
        public void CheckDataBaseConnection()
        {
            try
            {
                ThronesTournamentManager manager = new ThronesTournamentManager();
                manager.GetAllHouses();
            }
            catch(Exception e)
            {
                Assert.Fail("Expected no exception when instantiating manager but got :" + e.Message);
            }
        }

        [TestMethod]
        public void checkHouses()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            House h = new House("Test1", 10);
            var result = manager.GetAllHouses();
            int numberBefore = result.Count();
            manager.PostHouse(h);
            result = manager.GetAllHouses();
            var inserted_house = result.First(house => house.Name == "Test1");
            
            Assert.IsNotNull(inserted_house,"A house couldn't be inserted in db");
            Assert.AreEqual(numberBefore + 1, result.Count(), "The number of house is not correct");

            manager.DeleteHouse(inserted_house.ID);
            result = manager.GetAllHouses();
            Assert.AreEqual(numberBefore, result.Count(), "The house couldn't be deleted from db");
        }
    }
}
