using DataAccessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ThronesTournamentManager
    {
        private IDalManager _dal = DalManager.GetInstance();

        #region House

        public IEnumerable<String> GetHousesNames()
        {
            var houses = _dal.GetAllHouses();
            var ret = houses.Select(x => x.Name);
            return ret;
        }
        public IEnumerable<House> GetBigHouses()
        {
            return _dal.GetAllBigHouses();
        }

        public IEnumerable<House> GetAllHouses()
        {
            return _dal.GetAllHouses();
        }

        public IEnumerable<House> GetHouseById(int id)
        {
            return _dal.GetHouse(id);
        }

        public int PostHouse(House house)
        {
            return _dal.PostHouse(house);
        }

        public int PutHouse(int id, House house)
        {
            return _dal.PutHouse(id, house);
        }

        public int DeleteHouse(int id)
        {
            return _dal.DeleteHouse(id);
        }

        #endregion

        #region Character

        public IEnumerable<String> GetStrongCharacter()
        {
            var houses = _dal.GetAllCharacters();
            var ret = houses.Where(c => c.Pv>=50 && c.Bravoury>=3).Select(x => String.Format("{0} {1}",x.FirstName,x.LastName));
            return ret;
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _dal.GetAllCharacters();
        }

        public IEnumerable<Character> GetCharacterById(int id)
        {
            return _dal.GetCharacter(id);
        }

        public int PutTerritory(int id, Territory territory)
        {
            return PutTerritory(id, territory);
        }
        public int PutCharacter(int id, Character character)
        {
            return PutCharacter(id, character);
        }

        #endregion

        #region Territory

        public IEnumerable<Territory> GetAllTerritories()
        {
            return _dal.GetAllTerritories();
        }
        public IEnumerable<Territory> GetTerritoryById(int id)
        {
            return _dal.GetTerritory(id);
        }

        public int DeleteTerritory(int id)
        {
            return DeleteTerritory(id);
        }
        public int DeleteCharacter(int id)
        {
            return DeleteCharacter(id);
        }

        #endregion
    }
}
