using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1.Classes
{
    class Location
    {
        public int x { get; private set; }
        public int y {get; private set; }

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool IsLocation(int x, int y)
        {
            return x == this.x && y == this.y;
        }
    }
}
