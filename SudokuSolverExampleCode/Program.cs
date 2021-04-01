using Shared.Models;
using System;
using System.Collections.Generic;
using Templates.SudokuTemplates;

namespace SudokuSolverExampleCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SudokuModel> listSudokus = (List<SudokuModel>)SudokuData.GetMockData();
            var sudoku = listSudokus.Find(s => s.SudokuId.Equals(2));
            Logic.Algorithms.MainSolvers solver = new Logic.Algorithms.MainSolvers();
            solver.SolveGuessing(sudoku);
            Templates.VisualTemplates.Sudoku.PrintSudoku(sudoku.Cells);
            Console.ReadKey();
        }

      
    }
}
