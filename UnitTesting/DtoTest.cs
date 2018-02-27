using EntitiesLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZThrone.Models;

namespace UnitTesting
{
    [TestClass]
    public class DtoTest
    {

        /*
         * Check the automatic conversion of Entitie into Dto equivalent
         * */
        [TestMethod]
        public void checkDtoUtils()
        {
            // try to cast a House into HouseDto type
            House h = new House("DTOtest",4000);
            HouseDto hdto = DtoUtils.ToDto<HouseDto>(h);
            Assert.AreEqual(h.Name, hdto.Name);
            Assert.AreEqual(h.ID, hdto.ID);
            Assert.AreEqual(h.NumberOfUnits, hdto.NumberOfUnits);

            // try to cast a Character into CharacterDto type
            Character c = new Character();
            CharacterDto ctdo = DtoUtils.ToDto<CharacterDto>(c);
            Assert.AreEqual(c.Bravoury, ctdo.Bravoury);

            // try to cast a house into CharacterDto type
            House house = new House("Casting", 10);
            house.ID = 122;
            CharacterDto mutated_bastard_house_into_character = DtoUtils.ToDto<CharacterDto>(house);
            // this should be the only matching property
            Assert.AreEqual(house.ID, mutated_bastard_house_into_character.ID);
            // the others CharacterDto properties should be default or null depending on type
            Assert.IsNull(mutated_bastard_house_into_character.LastName);
            Assert.AreEqual(0,mutated_bastard_house_into_character.Bravoury);
        }
    }
}
