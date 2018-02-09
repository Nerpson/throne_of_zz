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
        IEnumerable<House> getHouse(int id);
        IEnumerable<Territory> getTerritory(int id);
        IEnumerable<Character> getCharacter(int id);


        IEnumerable<House> getAllHouses();
        IEnumerable<House> getAllBigHouses();
        IEnumerable<Territory> getAllTerritories();
        IEnumerable<Character> getAllCharacters();

        int PostHouse(House house);
    }
}
