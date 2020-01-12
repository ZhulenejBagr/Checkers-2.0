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
        public Pair LastCor { get; set; }
        public Board(string storage)
        {
            Storage = new Piece[Dimension, Dimension];
            var numbers = Array.ConvertAll(storage.Split(' '), int.Parse).ToList();

            for (int j = 0; j < Dimension; j++)
            {

                for (int k = 0; k < Dimension; k++)
                {
                    if (numbers[j * Dimension + k] == 0)
                    {
                        Storage[j, k] = null;
                        continue;
                    }
                    if (numbers[j * Dimension + k] == 1)    //cervena
                    {
                        Storage[j, k] = new Piece("red");
                        continue;

                    }
                    if (numbers[j * Dimension + k] == 2)    //cerna
                    {
                        Storage[j, k] = new Piece("black");
                        continue;

                    }
                    if (numbers[j * Dimension + k] == 3)    //cervena dama
                    {
                        Storage[j, k] = new Piece("redKing");
                        continue;

                    }
                    if (numbers[j * Dimension + k] == 4)    //cerna dama
                    {
                        Storage[j, k] = new Piece("blackKing");
                        continue;
                    }
                    if (numbers[j * Dimension + k] == 5)    //cerna dama
                    {
                        Storage[j, k] = new Piece("green");
                        continue;
                    }
                }

            }
        }
        //Převede Board to stringu
        //0 - prazdne pole
        //1 - cervena figurka
        //2 - cerna figurka
        //3 - cervena dama
        //4 - cerna dama
        //5 - mozny pohyb
        public string SaveBoard(Piece[,] storage)
        {
            string board = "";
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (storage[i, j] != null)
                    {
                        if (storage[i, j].Value == "red")     //cervena
                        {
                            board += "1 ";
                            continue;
                        }
                        if (storage[i, j].Value == "redKing")     //cervena dama
                        {
                            board += "3 ";
                            continue;
                        }
                        if (storage[i, j].Value == "black")     //cerna
                        {
                            board += "2 ";
                            continue;
                        }
                        if (storage[i, j].Value == "blackKing")     //cerna dama
                        {
                            board += "4 ";
                            continue;
                        }
                        if (storage[i, j].Value == "green")
                        {
                            board += "5 ";
                            continue;
                        }

                    }
                    else
                    {
                        board += "0 ";
                        continue;
                    }

                }
            }
            board = board.Trim();
            return board;
        }
        public bool PossibleMoves(int i, int j)
        {
            
            if (Storage[i, j] == null)
            {
                
            }
            else
            {
                if (Storage[i,j].Value == "green")
                {
                    Storage[i, j] = new Piece(Storage[LastCor.X, LastCor.Y].Value);
                    Storage[LastCor.X, LastCor.Y] = null;
                    for (int x = 0; x < Dimension; x++)
                    {
                        for (int y = 0; y < Dimension; y++)
                        {
                            if (Storage != null)
                            {
                                if (Storage[x,y].Value == "green")
                                {
                                    Storage[x, y] = null;
                                }
                            }
                        }
                    }
                    return true;
                }
                if (Storage[i, j].Value == "red")
                {
                    if (i<7)
                    {
                        if (j>0)
                        {
                            if (Storage[i + 1, j - 1]  == null)
                            {
                                Storage[i + 1, j - 1] = new Piece("green");
                                
                            }
                            else
                            {
                                if (Storage[i + 1, j - 1].Value == "black" | Storage[i + 1, j - 1].Value == "blackKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                        if (j<7)
                        {
                            if (Storage[i + 1, j + 1] == null)
                            {
                                Storage[i + 1, j + 1] = new Piece("green");
                            }
                            else
                            {
                                if (Storage[i + 1, j + 1].Value == "black" | Storage[i + 1, j + 1].Value == "blackKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "black")
                {
                    if (i>0)
                    {
                        if (j>0)
                        {
                            if (Storage[i - 1, j - 1] == null)
                            {
                                Storage[i - 1, j - 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i - 1, j - 1].Value == "red" | Storage[i - 1, j - 1].Value == "redKing")
                                {
                                    Jump(i, j);
                                }
                            }


                        }
                        if (j<7)
                        {
                            if (Storage[i - 1, j + 1] == null)
                            {
                                Storage[i - 1, j + 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i - 1, j + 1].Value == "red" | Storage[i - 1, j + 1].Value == "redKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "redKing")
                {
                    if (i > 0)
                    {
                        if (j > 0)
                        {
                            if (Storage[i - 1, j - 1] == null)
                            {
                                Storage[i - 1, j - 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i - 1, j - 1].Value == "black" | Storage[i - 1, j - 1].Value == "blackKing")
                                {
                                    Jump(i, j);
                                }
                            }

                        }
                        if (j < 7)
                        {
                            if (Storage[i - 1, j + 1] == null)
                            {
                                Storage[i - 1, j + 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i - 1, j + 1].Value == "black" | Storage[i - 1, j + 1].Value == "blackKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                    }
                    if (i < 7)
                    {
                        if (j > 0)
                        {
                            if (Storage[i + 1, j - 1] == null)
                            {
                                Storage[i + 1, j - 1].Value = "green";

                            }
                            else
                            {
                                if (Storage[i + 1, j - 1].Value == "black" | Storage[i + 1, j - 1].Value == "blackKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                        if (j < 7)
                        {
                            if (Storage[i + 1, j + 1] == null)
                            {
                                Storage[i + 1, j + 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i + 1, j + 1].Value == "black" | Storage[i + 1, j + 1].Value == "blackKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "blackKing")
                {
                    if (i > 0)
                    {
                        if (j > 0)
                        {
                            if (Storage[i - 1, j - 1] == null)
                            {
                                Storage[i - 1, j - 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i - 1, j - 1].Value == "red" | Storage[i - 1, j - 1].Value == "redKing")
                                {
                                    Jump(i, j);
                                }
                            }

                        }
                        if (j < 7)
                        {
                            if (Storage[i - 1, j + 1] == null)
                            {
                                Storage[i - 1, j + 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i - 1, j + 1].Value == "red" | Storage[i - 1, j + 1].Value == "redKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                    }
                    if (i < 7)
                    {
                        if (j > 0)
                        {
                            if (Storage[i + 1, j - 1] == null)
                            {
                                Storage[i + 1, j - 1].Value = "green";

                            }
                            else
                            {
                                if (Storage[i + 1, j - 1].Value == "red" | Storage[i + 1, j - 1].Value == "redKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                        if (j < 7)
                        {
                            if (Storage[i + 1, j + 1] == null)
                            {
                                Storage[i + 1, j + 1].Value = "green";
                            }
                            else
                            {
                                if (Storage[i + 1, j + 1].Value == "red" | Storage[i + 1, j + 1].Value == "redKing")
                                {
                                    Jump(i, j);
                                }
                            }
                        }
                    }
                }
                LastCor = new Pair(i, j);

            }
            return false;
            
        }
        public void Jump (int i, int j)
        {
            if (Storage[i, j] == null)
            {

            }
            else
            {
                if (Storage[i, j].Value == "red")
                {
                    if (i < 6)
                    {
                        if (j > 1)
                        {
                            if (Storage[i + 2, j - 2] == null)
                            {
                                Storage[i + 2, j - 2] = new Piece("green");

                            }
                        }
                        if (j < 7)
                        {
                            if (Storage[i + 2, j + 2] == null)
                            {
                                Storage[i + 2, j + 2] = new Piece("green");
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "black")
                {
                    if (i > 1)
                    {
                        if (j > 1)
                        {
                            if (Storage[i - 2, j - 2] == null)
                            {
                                Storage[i - 2, j - 2].Value = "green";
                            }

                        }
                        if (j < 6)
                        {
                            if (Storage[i - 2, j + 2] == null)
                            {
                                Storage[i - 2, j + 2].Value = "green";
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "redKing")
                {
                    if (i > 1)
                    {
                        if (j > 1)
                        {
                            if (Storage[i - 2, j - 2] == null)
                            {
                                Storage[i - 2, j - 2].Value = "green";
                            }

                        }
                        if (j < 6)
                        {
                            if (Storage[i - 2, j + 2] == null)
                            {
                                Storage[i - 2, j + 2].Value = "green";
                            }
                        }
                    }
                    if (i < 6)
                    {
                        if (j > 1)
                        {
                            if (Storage[i + 2, j - 2] == null)
                            {
                                Storage[i + 2, j - 2].Value = "green";

                            }
                        }
                        if (j < 6)
                        {
                            if (Storage[i + 2, j + 2] == null)
                            {
                                Storage[i + 2, j + 2].Value = "green";
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "blackKing")
                {
                    if (i > 1)
                    {
                        if (j > 1)
                        {
                            if (Storage[i - 2, j - 2] == null)
                            {
                                Storage[i - 2, j - 2].Value = "green";
                            }

                        }
                        if (j < 6)
                        {
                            if (Storage[i - 2, j + 2] == null)
                            {
                                Storage[i - 2, j + 2].Value = "green";
                            }
                        }
                    }
                    if (i < 6)
                    {
                        if (j > 1)
                        {
                            if (Storage[i + 2, j - 2] == null)
                            {
                                Storage[i + 2, j - 2].Value = "green";

                            }
                        }
                        if (j < 6)
                        {
                            if (Storage[i + 2, j + 2] == null)
                            {
                                Storage[i + 2, j + 2].Value = "green";
                            }
                        }
                    }
                }
                LastCor = new Pair(i, j);

            }

        }
    }
}







        /*public string SaveBoardVoid()
    {
        for (int i = 0; i < Dimension; i++)
        {
            for (int j = 0; j < Dimension; j++)
            {
                if (Storage[i, j] != null)
                {
                    if (Storage[i, j].Color == true & Storage[i, j].IsKing == false)     //cervena
                    {
                        board += "1 ";
                        continue;
                    }
                    if (storage[i, j].Color == true & storage[i, j].IsKing == true)     //cervena dama
                    {
                        board += "3 ";
                        continue;
                    }
                    if (storage[i, j].Color == false & storage[i, j].IsKing == false)     //cerna
                    {
                        board += "2 ";
                        continue;
                    }
                    if (storage[i, j].Color == false & storage[i, j].IsKing == true)     //cerna dama
                    {
                        board += "4 ";
                        continue;
                    }

                }
                else
                {
                    board += "0 ";
                    continue;
                }

            }
        }
        board = board.Trim();
        return board;
    }
    */
        /*public static  Piece[,] GetBoard(string storage)
        {
            Piece[,] output = new Piece[Dimension, Dimension];
            var numbers = Array.ConvertAll(storage.Split(' '), int.Parse).ToList();

            for (int j = 0; j < Dimension; j++)
            {

                for (int k = 0; k < Dimension; k++)
                {
                    if (numbers[j * Dimension + k] == 0)
                    {
                        output[j, k] = null;
                        continue;
                    }
                    if (numbers[j * Dimension + k] == 1)    //cervena
                    {
                        output[j, k] = new Piece(true, false);
                        continue;

                    }
                    if (numbers[j * Dimension + k] == 2)    //cerna
                    {
                        output[j, k] = new Piece(false, false);
                        continue;

                    }
                    if (numbers[j * Dimension + k] == 3)    //cervena dama
                    {
                        output[j, k] = new Piece(true, true);
                        continue;

                    }
                    if (numbers[j * Dimension + k] == 4)    //cerna dama
                    {
                        output[j, k] = new Piece(false, true);
                        continue;
                    }
                }

            }

            return output;
        }*/
