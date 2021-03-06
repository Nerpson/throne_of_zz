﻿using System;
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
            // _manager = new StubDalManager();
            //_manager = new SQLDalManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\")) + @"zzdb.mdf;Integrated Security=True;Connect Timeout=30");
            // elegant solution doesnt work when called from other place than root directory of project ( ex : unit tests)
            _manager = new SQLDalManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Travail\zz2\Service Web\throne_of_zz\zzdb.mdf;Integrated Security=True;Connect Timeout=30");
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

        public IEnumerable<House> GetAllHouses()
        {
            return _manager.GetAllHouses();
        }
        
        public IEnumerable<House> GetHouse(int id)
        {
            return _manager.GetHouse(id);
        }

        public IEnumerable<House> GetAllBigHouses()
        {
            return _manager.GetAllBigHouses();
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

        public IEnumerable<Territory> GetAllTerritories()
        {
            return _manager.GetAllTerritories();
        }
        
        public IEnumerable<Territory> GetTerritory(int id)
        {
            return _manager.GetTerritory(id);
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

        public IEnumerable<Character> GetAllCharacters()
        {
            return _manager.GetAllCharacters();
        }

        public IEnumerable<Character> GetCharacter(int id)
        {
            return _manager.GetCharacter(id);
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

        public IEnumerable<War> GetWar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fight> GetFight(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<War> GetAllWars()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fight> GetAllFights()
        {
            throw new NotImplementedException();
        }

        public int PostWar(War war)
        {
            throw new NotImplementedException();
        }

        public int PostFight(Fight fight)
        {
            throw new NotImplementedException();
        }

        public int PutWar(int id, War war)
        {
            throw new NotImplementedException();
        }

        public int PutFight(int id, Fight fight)
        {
            throw new NotImplementedException();
        }

        public int DeleteWar(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteFight(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
