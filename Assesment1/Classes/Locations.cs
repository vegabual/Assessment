using Assesment1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1
{
    public class Locations
    {
        private List<Location> locationList;

        public Locations()
        {
            locationList = new List<Location>();
        }

        public void AddNew(int x, int y)
        {
            Location location = new Location(x, y);
            locationList.Add(location);
        }

        public bool Contains(int x, int y)
        {
            bool found = false;
            int i = 0;
            while(!found && i < locationList.Count)
            {
                found = locationList[i].IsLocation(x, y);
                i++;
            }        
            return found;
        }
    }
}
