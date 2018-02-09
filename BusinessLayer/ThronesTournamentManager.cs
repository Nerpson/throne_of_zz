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

        public IEnumerable<String> getHousesNames()
        {
            var houses = _dal.getAllHouses();
            var ret = houses.Select(x => x.Name);
            return ret;
        }
        public IEnumerable<House> getBigHouses()
        {
            return _dal.getAllBigHouses();
        }

        public IEnumerable<House> getAllHouses()
        {
            return _dal.getAllHouses();
        }

        public IEnumerable<House> getHouseById(int id)
        {
            return _dal.getHouse(id);
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

        public IEnumerable<String> getStrongCharacter()
        {
            var houses = _dal.getAllCharacters();
            var ret = houses.Where(c => c.Pv>=50 && c.Bravoury>=3).Select(x => String.Format("{0} {1}",x.FirstName,x.LastName));
            return ret;
        }

        public IEnumerable<Character> getAllCharacters()
        {
            return _dal.getAllCharacters();
        }

        public IEnumerable<Character> getCharacterById(int id)
        {
            return _dal.getCharacter(id);
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

        public IEnumerable<Territory> getAllTerritories()
        {
            return _dal.getAllTerritories();
        }
        public IEnumerable<Territory> getTerritoryById(int id)
        {
            return _dal.getTerritory(id);
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
