using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrewtate
{
    internal class Functions
    {
        RailwaysEntities db = new RailwaysEntities();

        public int TrainCount()
        {
            return db.Train.ToList().Count;
        }

        public int TrainStationsCount()
        {
            return db.Stantion.ToList().Count;
        }
    }
}
