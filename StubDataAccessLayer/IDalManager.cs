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
        IEnumerable<House> getAllHouses();
        IEnumerable<House> getAllBigHouses();

        IEnumerable<Territory> getAllTerritories();

        IEnumerable<Character> getAllCharacters();

    }
}
