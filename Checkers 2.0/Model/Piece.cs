using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkers_2._0.Model
{
    public class Piece
    {
        public string Value { get; set; }
        public bool Color { get; set; }     //true - Red
                                            //false - Black
        public bool IsKing { get; set; }
        public Piece(string value)
        {
            Value = value;
            if (value == "red")
            {
                
                Color = true;
                IsKing = false;
            }
            if (value == "black")
            {
                
                Color = false;
                IsKing = false;
            }
            if (value == "redKing")
            {
                Color = true;
                IsKing = true;
            }
            if (value == "blackKing")
            {
                Color = false;
                IsKing = true;

            }
        }
    }
}
