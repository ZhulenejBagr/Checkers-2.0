using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkers_2._0.Model
{
    public class Piece
    {

        public bool Color { get; set; }     //true - Red
                                            //false - Black
        public bool IsKing { get; set; }
        public Piece(bool color, bool isKing)
        {
            Color = color;
            IsKing = isKing;
        }
    }
}
