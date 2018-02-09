using System;
using System.Collections.Generic;
using EntitiesLayer;
using System.IO;

namespace DataAccessLayer
{
    public class DalManager : IDalManager
    {
        private static DalManager _instance;
        private IDalManager _manager;
        private static object mutex = new object();

        private DalManager()
        {
            //_manager = new StubDalManager();
            _manager = new SQLDalManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\")) + @"zzdb.mdf;Integrated Security=True;Connect Timeout=30");
        }

        public static DalManager Instance
        {
            get
            {
                return GetInstance();
            }
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

        #region House

        public IEnumerable<House> getAllHouses()
        {
            return _manager.getAllHouses();
        }
        
        public IEnumerable<House> getHouse(int id)
        {
            return _manager.getHouse(id);
        }

        public IEnumerable<House> getAllBigHouses()
        {
            return _manager.getAllBigHouses();
        }
        public int PostHouse(House house)
        {
            return _manager.PostHouse(house);
        }

        public int PutHouse(int id, House house)
        {
            return _manager.PutHouse(id, house);
        }

        public int DeleteHouse(int id)
        {
            return _manager.DeleteHouse(id);
        }

        #endregion

        #region Territory

        public IEnumerable<Territory> getAllTerritories()
        {
            return _manager.getAllTerritories();
        }
        
        public IEnumerable<Territory> getTerritory(int id)
        {
            return _manager.getTerritory(id);
        }

        public int PostTerritory(Territory territory)
        {
            return _manager.PostTerritory(territory);
        }

        public int PutTerritory(int id, Territory territory)
        {
            return _manager.PutTerritory(id, territory);
        }

        public int DeleteTerritory(int id)
        {
            return _manager.DeleteTerritory(id);
        }

        #endregion

        #region Character

        public IEnumerable<Character> getAllCharacters()
        {
            return _manager.getAllCharacters();
        }

        public IEnumerable<Character> getCharacter(int id)
        {
            return _manager.getCharacter(id);
        }

        public int PostCharacter(Character character)
        {
            return _manager.PostCharacter(character);
        }

        public int PutCharacter(int id, Character character)
        {
            return _manager.PutCharacter(id, character);
        }
        
        public int DeleteCharacter(int id)
        {
            return _manager.DeleteCharacter(id);
        }

        #endregion
    }
}
