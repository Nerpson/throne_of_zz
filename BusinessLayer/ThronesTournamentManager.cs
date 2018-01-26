using DataAccessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ThronesTournamentManager
    {
        private IDalManager _dal = DalManager.GetInstance(); 
        public IEnumerable<String> getHousesNames()
        {
            var houses = _dal.getAllHouses();
            var ret = houses.Select(x => x.Name);
            return ret;
        }
        public IEnumerable<House> getBigHouses()
        {
            return _dal.getAllBigHouses();
        }
        public IEnumerable<String> getStrongCharacter()
        {
            var houses = _dal.getAllCharacters();
            var ret = houses.Where(c => c.Pv>=50 && c.Bravoury>=3).Select(x => String.Format("{0} {1}",x.FirstName,x.LastName));
            return ret;
        }

    }
}
