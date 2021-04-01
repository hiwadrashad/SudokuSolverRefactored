using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.Algorithms;
using Shared.Structs;

namespace Logic.Algorithms
{
    public class MainSolvers
    {
     
        public int[][] SolveLogical(SudokuModel sudokuModel)
        {
            var sudokuCells = sudokuModel.Cells;
            bool placed;
            do
            {
                placed = false;

                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (sudokuCells[row][col] == 0)
                        {
                            List<int> numberlist = SubComponents.Numberchecker(sudokuCells, new Coordinate { Row = row, Col = col });

                            if (numberlist.Count == 1)
                            {
                                sudokuCells[row][col] = numberlist[0];
                                placed = true;
                                break;
                            }
                        }
                    }
                    if (placed)
                    {
                        break;
                    }
                }
            } while (placed);

            return sudokuCells;
        }

        public void SolveGuessing(SudokuModel sudokuModel)
        {
            SolveLogical(sudokuModel);

            SudokuBackupModel backup = new SudokuBackupModel
            {
                BackupCells = SubComponents.CopyArray(sudokuModel.Cells)
            };

            while (!SubComponents.CheckIfSolved(sudokuModel.Cells))
            {
                while (!SubComponents.CheckIfStuck(sudokuModel.Cells))
                {
                    sudokuModel.Cells = SubComponents.GuessANumber(sudokuModel);
                    sudokuModel.Cells = SolveLogical(sudokuModel);
                    if (SubComponents.CheckIfSolved(sudokuModel.Cells))
                    {
                        return;
                    }
                }
                sudokuModel.Cells = SubComponents.CopyArray(backup.BackupCells);
            }

        }
    }
}
