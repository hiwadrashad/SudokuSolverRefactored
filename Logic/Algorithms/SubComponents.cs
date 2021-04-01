using Shared.Models;
using Shared.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Algorithms
{
    public static class SubComponents
    {
        public static int[][] GuessANumber(SudokuModel sudokuModel)
        {
            var rnd = new Random();

            for (int i = 2; i < 10;)
            {
                sudokuModel.Coord = FindLocation(sudokuModel.Cells, sudokuModel.Coord);
                List<int> possibleNumbers = Numberchecker(sudokuModel.Cells, sudokuModel.Coord);

                if (possibleNumbers.Count == i)
                {
                    sudokuModel.Cells[sudokuModel.Coord.Row][sudokuModel.Coord.Col] = possibleNumbers[rnd.Next(possibleNumbers.Count)];

                    return sudokuModel.Cells;
                }
                else
                {
                    sudokuModel.Coord = NextCoordinate(sudokuModel.Coord);

                    if (sudokuModel.Coord.Row == 0 && sudokuModel.Coord.Col == 0)
                    {
                        i++;
                    }
                }
            }
            return sudokuModel.Cells;
        }

        public static Coordinate NextCoordinate(Coordinate coord)
        {
            coord.Col = (coord.Col + 1) % 9;
            if (coord.Col == 0)
            {
                coord.Row = (coord.Row + 1) % 9;
            }
            return coord;
        }

        public static Coordinate FindLocation(int[][] cells, Coordinate coord)
        {
            for (int row = coord.Row; row < 9; row++)
            {
                for (int col = coord.Col; col < 9; col++)
                {
                    if (cells[row][col] == 0)
                    {
                        coord.Row = row;
                        coord.Col = col;
                        return coord;
                    }
                }
            }
            return coord;
        }

        public static List<int> Numberchecker(int[][] sudokuCells, Coordinate coord)
        {
            List<int> numberlist = Shared.Globals.AllNumbers.GetAllNumbers;
            int corda = coord.Row - coord.Row % 3;
            int cordb = coord.Col - coord.Col % 3;

            for (int tempcolum = 0; tempcolum < 9; tempcolum++)
            {
                if (numberlist.Contains(sudokuCells[coord.Row][tempcolum]))
                {
                    numberlist.Remove(sudokuCells[coord.Row][tempcolum]);
                }
            }
            for (int tempRow = 0; tempRow < 9; tempRow++)
            {
                if (numberlist.Contains(sudokuCells[tempRow][coord.Col]))
                {
                    numberlist.Remove(sudokuCells[tempRow][coord.Col]);
                }
            }
            for (int i = corda; i < corda + 3; i++)
            {
                for (int j = cordb; j < cordb + 3; j++)
                {
                    if (numberlist.Contains(sudokuCells[i][j]))
                    {
                        numberlist.Remove(sudokuCells[i][j]);
                    }
                }
            }
            return numberlist;
        }

        public static bool CheckIfSolved(int[][] sudoku)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (sudoku[x][y] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckIfStuck(int[][] sudoku)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudoku[row][col] == 0)
                    {
                        List<int> numberlist = Numberchecker(sudoku, new Coordinate { Row = row, Col = col });
                        if (numberlist.Count == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static int[][] CopyArray(int[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }

    }
}
