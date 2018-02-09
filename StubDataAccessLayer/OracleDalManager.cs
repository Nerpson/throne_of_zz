using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    class OracleDalManager : IDalManager
    {
        public IEnumerable<House> getAllBigHouses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> getAllCharacters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<House> getAllHouses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Territory> getAllTerritories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> getCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<House> getHouse(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Territory> getTerritory(int id)
        {
            throw new NotImplementedException();
        }

        public int PostHouse(House house)
        {
            throw new NotImplementedException();
        }

        public int DeleteHouse(int id)
        {
            throw new NotImplementedException();
        }

        public int PutHouse(int id, House house)
        {
            throw new NotImplementedException();
        }

        public int PostTerritory(Territory territory)
        {
            throw new NotImplementedException();
        }

        public int PostCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public int PutTerritory(int id, Territory territory)
        {
            throw new NotImplementedException();
        }

        public int PutCharacter(int id, Character character)
        {
            throw new NotImplementedException();
        }

        public int DeleteTerritory(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteCharacter(int id)
        {
            throw new NotImplementedException();
        }
    }
}
