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

        // -------- CHARACTERS

        public IEnumerable<Character> getAllCharacters()
        {
            List<Character> characters = new List<Character>();

            DataTable result = selectRequest("SELECT * FROM character");

            foreach (DataRow row in result.Rows)
            {
                characters.Add(new Character(row.Field<int>(1), row.Field<int>(2), row.Field<string>(3), row.Field<string>(4), row.Field<int>(5)) { ID = row.Field<int>(0) });
            }

            return characters;
        }

        public IEnumerable<Character> getCharacter(int id)
        {
            List<Character> characters = new List<Character>();

            DataTable result = selectRequest("SELECT * FROM character WHERE id = " + id);

            foreach (DataRow row in result.Rows)
            {
                characters.Add(new Character(row.Field<int>(1), row.Field<int>(2), row.Field<string>(3), row.Field<string>(4), row.Field<int>(5)) { ID = row.Field<int>(0) });
            }

            return characters;
        }

        // -------- HOUSES

        public IEnumerable<House> getAllHouses()
        {
            List<House> houses = new List<House>();

            DataTable result = selectRequest("SELECT * FROM house");

            foreach (DataRow row in result.Rows)
            {
                houses.Add(new House(row.Field<string>(1), row.Field<int>(2)) { ID = row.Field<int>(0) });
            }

            return houses;
        }

        public IEnumerable<House> getAllBigHouses()
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

        public IEnumerable<House> getHouse(int id)
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
            DataTable dataTable = selectRequest("SELECT * FROM house");
            dataTable.Rows.Add(null, house.Name, house.NumberOfUnits);
            return UpdateRequest("SELECT * FROM house", dataTable);
        }

        public int PutHouse(int id, House house)
        {
            DataTable dataTable = selectRequest("SELECT * FROM house WHERE id = " + id);
            dataTable.Rows[0][1] = house.Name;
            dataTable.Rows[0][2] = house.NumberOfUnits;
            return UpdateRequest("SELECT * FROM house WHERE id = " + id, dataTable);
        }

        public int DeleteHouse(int id)
        {
            DataTable dataTable = selectRequest("SELECT * FROM house WHERE id = " + id);
            dataTable.Rows.Clear();
            return UpdateRequest("SELECT * FROM house WHERE id = " + id, dataTable);
        }

        // -------- TERRITORIES

        public IEnumerable<Territory> getAllTerritories()
        {
            List<Territory> territories = new List<Territory>();

            DataTable result = selectRequest("SELECT * FROM territory");

            foreach (DataRow row in result.Rows)
            {
                territories.Add(new Territory(row.Field<string>(1), row.Field<TerritoryType>(2)) { ID = row.Field<int>(0) });
            }

            return territories;
        }

        public IEnumerable<Territory> getTerritory(int id)
        {
            List<Territory> territories = new List<Territory>();
            DataTable result = selectRequest("SELECT * FROM territory WHERE id = " + id);

            foreach (DataRow row in result.Rows)
            {
                territories.Add(new Territory(row.Field<string>(1), row.Field<TerritoryType>(2)) { ID = row.Field<int>(0) });
            }

            return territories;
        }
    }
}
