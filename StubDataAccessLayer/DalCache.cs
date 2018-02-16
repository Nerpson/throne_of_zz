using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class DalCache<T>
    {

        private bool _loaded;

        public bool Loaded
        {
            get { return _loaded; }
        }

        private IEnumerable<T> _data;

        public IEnumerable<T> Data
        {
            get
            {
                if (!Loaded) throw new Exception("Cache not loaded.");
                return _data;
            }
            set
            {
                _loaded = true;
                _data = value;
            }
        }
    }
}
