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

        /*public Board()
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
        }*/
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
                }

            }
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
        public void Move(int i, int j, int x, int y)
        {
            Storage[x, y] = Storage[i, j];
            Storage[i, j] = null;
        }
        public List<Pair> PossibleMoves(int i, int j)
        {
            List<Pair> output = new List<Pair>();
            if (Storage[i,j] != null)
            {
                if (Storage[i, j].Value == "red")
                {
                    if (i < 7)
                    {
                        if (j > 0)
                        {
                            if (Storage[j - 1, i + 1] != null)
                            {
                                if (Storage[j - 1, i + 1].Color ==true )
                                {

                                }
                                if (Storage[j - 1, i + 1].Color == false)
                                {
                                    PossibleMoves(j - 1, i + 1); //jump
                                }
                                else
                                {
                                    output.Add(new Pair(j - 1, i + 1));
                                }
                            }
                            
                        }
                        if (j < 7)
                        {
                            if (Storage[j + 1, i + 1] != null)
                            {
                                if (Storage[j + 1, i + 1].Color == true)
                                {

                                }
                                if (Storage[j + 1, i + 1].Color == false)
                                {
                                    PossibleMoves(j + 1, i + 1); //jump
                                }
                                else
                                {
                                    output.Add(new Pair(j + 1, i + 1));
                                }
                            }
                        }
                    }

                }
                if (Storage[i, j].Value == "black")
                {
                    if (i > 0)
                    {
                        if (j > 0)
                        {
                            if (Storage[j - 1, i - 1] != null)
                            {
                                if (Storage[j - 1, i - 1].Color == false)
                                {

                                }
                                if (Storage[j - 1, i - 1].Color == true)
                                {
                                    PossibleMoves(j - 1, i + 1);
                                }
                                else
                                {
                                    output.Add(new Pair(j - 1, i - 1));
                                }
                            }
                        }
                        if (j < 7)
                        {
                            if (Storage[j + 1, i - 1] != null)
                            {
                                if (Storage[j + 1, i - 1].Color == false)
                                {

                                }
                                if (Storage[j + 1, i - 1].Color == true)
                                {
                                    PossibleMoves(j + 1, i + 1);
                                }
                                else
                                {
                                    output.Add(new Pair(j + 1, i - 1));
                                }
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "redKing")
                {
                    if (i < 7)
                    {
                        if (j > 0)
                        {
                            if (Storage[j - 1, i + 1] != null)
                            {
                                if (Storage[j - 1, i + 1].Color == true)
                                {

                                }
                                if (Storage[j - 1, i + 1].Color == false)
                                {
                                    PossibleMoves(j - 1, i + 1); //jump
                                }
                                else
                                {
                                    output.Add(new Pair(j - 1, i + 1));
                                }
                            }

                        }
                        if (j < 7)
                        {
                            if (Storage[j + 1, i + 1] != null)
                            {
                                if (Storage[j + 1, i + 1].Color == true)
                                {

                                }
                                if (Storage[j + 1, i + 1].Color == false)
                                {
                                    PossibleMoves(j + 1, i + 1); //jump
                                }
                                else
                                {
                                    output.Add(new Pair(j + 1, i + 1));
                                }
                            }
                        }
                    }
                    if (i > 0)
                    {
                        if (j > 0)
                        {
                            if (Storage[j - 1, i - 1] != null)
                            {
                                if (Storage[j - 1, i - 1].Color == true)
                                {

                                }
                                if (Storage[j - 1, i - 1].Color == false)
                                {
                                    PossibleMoves(j - 1, i + 1);
                                }
                                else
                                {
                                    output.Add(new Pair(j - 1, i - 1));
                                }
                            }
                        }
                        if (j < 7)
                        {
                            if (Storage[j + 1, i - 1] != null)
                            {
                                if (Storage[j + 1, i - 1].Color == true)
                                {

                                }
                                if (Storage[j + 1, i - 1].Color == false)
                                {
                                    PossibleMoves(j + 1, i + 1);
                                }
                                else
                                {
                                    output.Add(new Pair(j + 1, i - 1));
                                }
                            }
                        }
                    }
                }
                if (Storage[i, j].Value == "blackKing")
                {
                    if (i < 7)
                    {
                        if (j > 0)
                        {
                            if (Storage[j - 1, i + 1] != null)
                            {
                                if (Storage[j - 1, i + 1].Color == false)
                                {

                                }
                                if (Storage[j - 1, i + 1].Color == true)
                                {
                                    PossibleMoves(j - 1, i + 1); //jump
                                }
                                else
                                {
                                    output.Add(new Pair(j - 1, i + 1));
                                }
                            }

                        }
                        if (j < 7)
                        {
                            if (Storage[j + 1, i + 1] != null)
                            {
                                if (Storage[j + 1, i + 1].Color == false)
                                {

                                }
                                if (Storage[j + 1, i + 1].Color == true)
                                {
                                    PossibleMoves(j + 1, i + 1); //jump
                                }
                                else
                                {
                                    output.Add(new Pair(j + 1, i + 1));
                                }
                            }
                        }
                    }
                    if (i > 0)
                    {
                        if (j > 0)
                        {
                            if (Storage[j - 1, i - 1] != null)
                            {
                                if (Storage[j - 1, i - 1].Color == false)
                                {

                                }
                                if (Storage[j - 1, i - 1].Color == true)
                                {
                                    PossibleMoves(j - 1, i + 1);
                                }
                                else
                                {
                                    output.Add(new Pair(j - 1, i - 1));
                                }
                            }
                        }
                        if (j < 7)
                        {
                            if (Storage[j + 1, i - 1] != null)
                            {
                                if (Storage[j + 1, i - 1].Color == false)
                                {

                                }
                                if (Storage[j + 1, i - 1].Color == true)
                                {
                                    PossibleMoves(j + 1, i + 1);
                                }
                                else
                                {
                                    output.Add(new Pair(j + 1, i - 1));
                                }
                            }
                        }
                    }
                }

            }
            return output;
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
    }
}
