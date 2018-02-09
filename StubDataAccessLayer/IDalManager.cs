using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDalManager
    {
        IEnumerable<House> GetHouse(int id);
        IEnumerable<Territory> GetTerritory(int id);
        IEnumerable<Character> GetCharacter(int id);


        IEnumerable<House> GetAllHouses();
        IEnumerable<House> GetAllBigHouses();
        IEnumerable<Territory> GetAllTerritories();
        IEnumerable<Character> GetAllCharacters();

        int PostHouse(House house);
        int PostTerritory(Territory territory);
        int PostCharacter(Character character);

        int PutHouse(int id, House house);
        int PutTerritory(int id, Territory territory);
        int PutCharacter(int id, Character character);

        int DeleteHouse(int id);
        int DeleteTerritory(int id);
        int DeleteCharacter(int id);
    }
}
