using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class StubDalManager : IDalManager
    {
        private IList<House> _houses = new List<House>();
        private IList<Character> _chars = new List<Character>();

        public StubDalManager()
        {
            var h = new House("F5", 42);
            var h2 = new House("F2", 2);
            var h3 = new House("F3", 33);
            var h4 = new House("F4", 4);

            var c = new Character(5, 10, "M4z3", "No", 522);
            var c2 = new Character(3, 8, "ChabChab", "Roll", 57);
            var c3 = new Character(3, 3, "Typical", "F3", 53);
            var c4 = new Character(7, 8, "Benoit", "Bernay", 52);

            _chars.Add(c);
            _chars.Add(c2);
            _chars.Add(c3);
            _chars.Add(c4);

            h.Housers.AddFirst(c);
            h.NumberOfUnits = 1400;
            h2.Housers.AddFirst(c2);
            h3.Housers.AddFirst(c3);
            h4.Housers.AddFirst(c4);
            
            _houses.Add(h);
            _houses.Add(h2);
            _houses.Add(h3);
            _houses.Add(h4);

        }

        public IEnumerable<House> getAllBigHouses()
        {
            return _houses.Where(h => h.NumberOfUnits > 200);
        }

        public IEnumerable<Character> getAllCharacters()
        {
            return _chars;
        }

        public IEnumerable<House> getAllHouses()
        {
            return _houses;
        }

        public IEnumerable<Territory> getAllTerritories()
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

        public IEnumerable<Character> getCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public int PostHouse(House house)
        {
            throw new NotImplementedException();
        }

        public int PutHouse(int id, House house)
        {
            throw new NotImplementedException();
        }

        public int DeleteHouse(int id)
        {
            throw new NotImplementedException();
        }
    }
}
