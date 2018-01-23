using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    class DalManager : IDalManager
    {
        private static DalManager _instance;
        private IDalManager _manager;
        private static object mutex = new object();

        private DalManager()
        {

        }

        public static DalManager GetInstance()
        {
            lock (mutex)
            {
                if (_instance == null)
                {
                    _instance = new DalManager();
                }
            }
            return _instance;
        }

       public IEnumerable<House> getAllHouses()
        {
            return _manager.getAllHouses();
        }

        public IEnumerable<House> getAllBigHouses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Territory> getAllTerritories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> getAllCharacters()
        {
            throw new NotImplementedException();
        }

    }
}
