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
        IEnumerable<War> GetWar(int id);
        IEnumerable<Fight> GetFight(int id);


        IEnumerable<House> GetAllHouses();
        IEnumerable<House> GetAllBigHouses();
        IEnumerable<Territory> GetAllTerritories();
        IEnumerable<Character> GetAllCharacters();
        IEnumerable<War> GetAllWars();
        IEnumerable<Fight> GetAllFights();

        int PostHouse(House house);
        int PostTerritory(Territory territory);
        int PostCharacter(Character character);
        int PostWar(War war);
        int PostFight(Fight fight);

        int PutHouse(int id, House house);
        int PutTerritory(int id, Territory territory);
        int PutCharacter(int id, Character character);
        int PutWar(int id, War war);
        int PutFight(int id, Fight fight);

        int DeleteHouse(int id);
        int DeleteTerritory(int id);
        int DeleteCharacter(int id);
        int DeleteWar(int id);
        int DeleteFight(int id);
    }
}
