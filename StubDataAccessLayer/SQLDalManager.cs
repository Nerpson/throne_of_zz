using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    class SQLDalManager : IDalManager
    {
        private readonly String _connectionString;

        private DataTable selectRequest(string request)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        private int UpdateRequest(string request, DataTable dataTable)
        {
            int result = 0;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.DeleteCommand = builder.GetDeleteCommand();

                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                result = adapter.Update(dataTable);
            }

            return result;
        }

        public SQLDalManager(String connectionString)
        {
            _connectionString = connectionString;
        }

        #region Character

        public IEnumerable<Character> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();

            DataTable result = selectRequest("SELECT * FROM character");

            foreach (DataRow row in result.Rows)
            {
                characters.Add(new Character(row.Field<int>(1), row.Field<int>(2), row.Field<string>(3), row.Field<string>(4), row.Field<int>(5)) { ID = row.Field<int>(0) });
            }

            return characters;
        }

        public IEnumerable<Character> GetCharacter(int id)
        {
            List<Character> characters = new List<Character>();

            DataTable result = selectRequest("SELECT * FROM character WHERE id = " + id);

            foreach (DataRow row in result.Rows)
            {
                characters.Add(new Character(row.Field<int>(1), row.Field<int>(2), row.Field<string>(3), row.Field<string>(4), row.Field<int>(5)) { ID = row.Field<int>(0) });
            }

            return characters;
        }
        
        public int PostCharacter(Character character)
        {
            const string req = "SELECT * FROM character";
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Add(null, character.Bravoury, character.Crazyness, character.FirstName, character.LastName, character.Pv);
            return UpdateRequest(req, dataTable);
        }

        public int PutCharacter(int id, Character character)
        {
            var req = "SELECT * FROM character WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows[0][1] = character.Bravoury;
            dataTable.Rows[0][2] = character.Crazyness;
            dataTable.Rows[0][3] = character.FirstName;
            dataTable.Rows[0][4] = character.LastName;
            dataTable.Rows[0][5] = character.Pv;
            return UpdateRequest(req, dataTable);
        }

        public int DeleteCharacter(int id)
        {
            var req = "SELECT * FROM character WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Clear();
            return UpdateRequest(req, dataTable);
        }

        #endregion

        #region Fight

        public IEnumerable<Fight> GetAllFights()
        {
            List<Fight> wars = new List<Fight>();

            DataTable result = selectRequest("SELECT * FROM fight");

            foreach (DataRow row in result.Rows)
            {

                House challenging = GetHouse(row.Field<int>(1)).ElementAt(0);
                House challenged = GetHouse(row.Field<int>(2)).ElementAt(0);
                House winning = GetHouse(row.Field<int>(3)).ElementAt(0);

                wars.Add(new Fight(challenging, challenged, winning) { ID = row.Field<int>(0) });
            }

            return wars;
        }

        public IEnumerable<Fight> GetFight(int id)
        {
            List<Fight> fights = new List<Fight>();
            DataTable result = selectRequest("SELECT * FROM fight WHERE id = " + id);

            foreach (DataRow row in result.Rows)
            {

                House challenging = GetHouse(row.Field<int>(1)).ElementAt(0);
                House challenged = GetHouse(row.Field<int>(2)).ElementAt(0);
                House winning = GetHouse(row.Field<int>(3)).ElementAt(0);

                fights.Add(new Fight(challenging, challenged, winning) { ID = row.Field<int>(0) });
            }

            return fights;
        }

        public int PostFight(Fight fight)
        {
            const string req = "SELECT * FROM fight";
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Add(null, fight.HouseChallenging, fight.HouseChallenged, fight.WinningHouse);
            return UpdateRequest(req, dataTable);
        }

        public int PutFight(int id, Fight fight)
        {
            var req = "SELECT * FROM fight WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows[0][1] = fight.HouseChallenging;
            dataTable.Rows[0][1] = fight.HouseChallenged;
            dataTable.Rows[0][1] = fight.WinningHouse;
            return UpdateRequest(req, dataTable);
        }

        public int DeleteFight(int id)
        {
            var req = "SELECT * FROM fight WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Clear();
            return UpdateRequest(req, dataTable);
        }

        #endregion

        #region House

        public IEnumerable<House> GetAllHouses()
        {
            List<House> houses = new List<House>();

            DataTable result = selectRequest("SELECT * FROM house");

            foreach (DataRow row in result.Rows)
            {
                houses.Add(new House(row.Field<string>(1), row.Field<int>(2)) { ID = row.Field<int>(0) });
            }

            return houses;
        }

        public IEnumerable<House> GetAllBigHouses()
        {
            List<House> houses = new List<House>();

            DataTable result = selectRequest("SELECT * FROM house WHERE nbUnit > 500");
            //Todo no foreach
            foreach (DataRow row in result.Rows)
            {
                houses.Add(new House(row.Field<string>(1), row.Field<int>(2)) { ID = row.Field<int>(0) });
            }

            return houses;
        }

        public IEnumerable<House> GetHouse(int id)
        {
            List<House> houses = new List<House>();
            DataTable result = selectRequest("SELECT * FROM house WHERE id = " + id);

            foreach (DataRow row in result.Rows)
            {
                houses.Add(new House(row.Field<string>(1), row.Field<int>(2)) { ID = row.Field<int>(0) });
            }

            return houses;
        }

        public int PostHouse(House house)
        {
            const string req = "SELECT * FROM house";
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Add(null, house.Name, house.NumberOfUnits);
            return UpdateRequest(req, dataTable);
        }

        public int PutHouse(int id, House house)
        {
            var req = "SELECT * FROM house WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows[0][1] = house.Name;
            dataTable.Rows[0][2] = house.NumberOfUnits;
            return UpdateRequest(req, dataTable);
        }

        public int DeleteHouse(int id)
        {
            var req = "SELECT * FROM house WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Clear();
            return UpdateRequest(req, dataTable);
        }

        #endregion

        #region Territory

        public IEnumerable<Territory> GetAllTerritories()
        {
            List<Territory> territories = new List<Territory>();

            DataTable result = selectRequest("SELECT * FROM territory");

            foreach (DataRow row in result.Rows)
            {
                territories.Add(new Territory(row.Field<string>(1), row.Field<TerritoryType>(2)) { ID = row.Field<int>(0) });
            }

            return territories;
        }

        public IEnumerable<Territory> GetTerritory(int id)
        {
            List<Territory> territories = new List<Territory>();
            DataTable result = selectRequest("SELECT * FROM territory WHERE id = " + id);

            foreach (DataRow row in result.Rows)
            {
                territories.Add(new Territory(row.Field<string>(1), row.Field<TerritoryType>(2)) { ID = row.Field<int>(0) });
            }

            return territories;
        }

        public int PostTerritory(Territory territory)
        {
            const string req = "SELECT * FROM territory";
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Add(null, territory.Name, territory.TerritoryType);
            return UpdateRequest(req, dataTable);
        }

        public int PutTerritory(int id, Territory territory)
        {
            var req = "SELECT * FROM territory WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows[0][1] = territory.Name;
            dataTable.Rows[0][2] = territory.TerritoryType;
            return UpdateRequest(req, dataTable);
        }

        public int DeleteTerritory(int id)
        {
            var req = "SELECT * FROM territory WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Clear();
            return UpdateRequest(req, dataTable);
        }

        #endregion

        #region War

        public IEnumerable<War> GetAllWars()
        {
            List<War> wars = new List<War>();

            DataTable result = selectRequest("SELECT * FROM war");

            foreach (DataRow row in result.Rows)
            {
                wars.Add(new War(row.Field<string>(1)) { ID = row.Field<int>(0) });
            }

            return wars;
        }

        public IEnumerable<War> GetWar(int id)
        {
            List<War> wars = new List<War>();
            DataTable result = selectRequest("SELECT * FROM war WHERE id = " + id);

            foreach (DataRow row in result.Rows)
            {
                wars.Add(new War(row.Field<string>(1)) { ID = row.Field<int>(0) });
            }

            return wars;
        }

        public int PostWar(War war)
        {
            const string req = "SELECT * FROM war";
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Add(null, war.Name);
            return UpdateRequest(req, dataTable);
        }

        public int PutWar(int id, War war)
        {
            var req = "SELECT * FROM war WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows[0][1] = war.Name;
            return UpdateRequest(req, dataTable);
        }

        public int DeleteWar(int id)
        {
            var req = "SELECT * FROM war WHERE id = " + id;
            DataTable dataTable = selectRequest(req);
            dataTable.Rows.Clear();
            return UpdateRequest(req, dataTable);
        }

        #endregion
    }
}
