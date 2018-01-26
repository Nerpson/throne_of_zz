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

        public SQLDalManager(String connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<House> getAllBigHouses()
        {
            List<House> houses = new List<House>();

            DataTable result = selectRequest("SELECT * FROM house WHERE nbUnit > 500");
            foreach (DataRow row in result.Rows)
            {
                // ... Write value of first field as integer.
                houses.Add(new House(row.Field<string>(1), row.Field<int>(2)));
            }

            return houses;
        }

        public IEnumerable<Character> getAllCharacters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<House> getAllHouses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Territory> getAllTerritories()
        {
            throw new NotImplementedException();
        }
    }
}
