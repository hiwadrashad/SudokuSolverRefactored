using System;
using System.Collections.Generic;
using System.Text;

namespace Templates.VisualTemplates
{
    public static class Sudoku
    {
        public static void PrintSudoku(int[][] cells)
        {
            string horLine = "----------------------";
            string verLine = "|";

            Console.Write(horLine);
            Console.WriteLine();
            for (int i = 0; i < cells.Length; i++)
            {
                Console.Write(verLine);
                for (int j = 0; j < cells[i].Length; j++)
                {
                    if (cells[i][j] != 0)
                    {
                        Console.Write($"{cells[i][j]} ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    if (j % 3 == 2)
                    {
                        Console.Write(verLine);
                    }
                }
                Console.WriteLine();
                if (i % 3 == 2)
                {
                    Console.Write(horLine);
                    Console.WriteLine();
                }
            }
        }
    }
}
