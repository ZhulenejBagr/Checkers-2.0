using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkers_2._0.Model
{
    public class Board
    {
        public const int Dimension = 8;

        public Piece[,] Storage { get; set; }
        public Board()
        {
            Storage = new Piece[Dimension, Dimension];
            //cervena
            Storage[0, 0] = new Piece(true, false);
            Storage[0, 2] = new Piece(true, false);
            Storage[0, 4] = new Piece(true, false);
            Storage[0, 6] = new Piece(true, false);
            Storage[1, 1] = new Piece(true, false);
            Storage[1, 3] = new Piece(true, false);
            Storage[1, 5] = new Piece(true, false);
            Storage[1, 7] = new Piece(true, false);
            Storage[2, 0] = new Piece(true, false);
            Storage[2, 2] = new Piece(true, false);
            Storage[2, 4] = new Piece(true, false);
            Storage[2, 6] = new Piece(true, false);
            //cerna
            Storage[7, 1] = new Piece(false, false);
            Storage[7, 3] = new Piece(false, false);
            Storage[7, 5] = new Piece(false, false);
            Storage[7, 7] = new Piece(false, false);
            Storage[6, 0] = new Piece(false, false);
            Storage[6, 2] = new Piece(false, false);
            Storage[6, 4] = new Piece(false, false);
            Storage[6, 6] = new Piece(false, false);
            Storage[5, 1] = new Piece(false, false);
            Storage[5, 3] = new Piece(false, false);
            Storage[5, 5] = new Piece(false, false);
            Storage[5, 7] = new Piece(false, false);
        }
        //Převede Board to stringu
        //0 - prazdne pole
        //1 - cervena figurka
        //2 - cerna figurka
        //3 - cervena dama
        //4 - cerna dama
        public string SaveBoard(Piece[,] storage)           
        {
            string board = "";
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (storage[i, j] != null)
                    {
                        if (storage[i, j].Color == true & storage[i, j].IsKing == false)     //cervena
                        {
                            board += "1";
                            continue;
                        }
                        if (storage[i, j].Color == true & storage[i, j].IsKing == true)     //cervena dama
                        {
                            board += "3";
                            continue;
                        }
                        if (storage[i, j].Color == false & storage[i, j].IsKing == false)     //cerna
                        {
                            board += "2";
                            continue;
                        }
                        if (storage[i, j].Color == false & storage[i, j].IsKing == true)     //cerna dama
                        {
                            board += "4";
                            continue;
                        }

                    }
                    else
                    {
                        board += "0";
                        continue;
                    }

                }
            }
            return board;
        }
    }
}
