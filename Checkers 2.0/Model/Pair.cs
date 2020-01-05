using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkers_2._0.Model
{
    public class Pair
    {
        public int X { get; set; }
        public  int Y { get; set; }
        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
