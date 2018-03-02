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

        public int PutCharacter(int id, Character character)
        {
            return _dal.PutCharacter(id, character);
        }

        public int PostCharacter(Character character)
        {
            return _dal.PostCharacter(character);
        }

        public int DeleteCharacter(int id)
        {
            return _dal.DeleteCharacter(id);
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

        public int PutTerritory(int id, Territory territory)
        {
            return _dal.PutTerritory(id, territory);
        }

        public int PostTerritory(Territory territory)
        {
            return _dal.PostTerritory(territory);
        }

        public int DeleteTerritory(int id)
        {
            return _dal.DeleteTerritory(id);
        }

        #endregion

        #region War

        public IEnumerable<War> GetAllWars()
        {
            return _dal.GetAllWars();
        }
        public IEnumerable<War> GetWarById(int id)
        {
            return _dal.GetWar(id);
        }

        public int PutWar(int id, War war)
        {
            return _dal.PutWar(id, war);
        }

        public int PostWar(War war)
        {
            return _dal.PostWar(war);
        }

        public int DeleteWar(int id)
        {
            return _dal.DeleteWar(id);
        }

        #endregion

        #region Fight

        public IEnumerable<Fight> GetAllFights()
        {
            return _dal.GetAllFights();
        }
        public IEnumerable<Fight> GetFightById(int id)
        {
            return _dal.GetFight(id);
        }

        public int PutFight(int id, Fight fight)
        {
            return _dal.PutFight(id, fight);
        }

        public int PostFight(Fight fight)
        {
            return _dal.PostFight(fight);
        }

        public int DeleteFight(int id)
        {
            return _dal.DeleteFight(id);
        }

        #endregion
    }
}
