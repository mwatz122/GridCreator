using GridCreator.Models;
using System;
using System.Collections.Generic;

namespace GridCreator
{
    public class GridPrinter
    {
        /// <summary>
        /// Print a grid's rows, columns, and alpha value to the standard console.
        /// </summary>
        /// <param name="grid"></param>
        public void PrintGrid(Grid grid)
        {
            PrintRows(grid.GetGridRows(), grid.Dimension);
            PrintColumns(grid.GetGridColumns(), grid.Dimension);
            PrintAlpha(grid.GetAlpha());
        }

        /// <summary>
        /// Print a grid's rows to the standard console.
        /// </summary>
        /// <param name="gridRows"></param>
        /// <param name="gridDimension"></param>
        private void PrintRows(List<GridRow> gridRows, int gridDimension)
        {
            for (int i = 0; i < gridDimension; i++)
            {
                Console.Write(String.Format("Row {0}: ", i));

                for (int j = 0; j < gridDimension; j++)
                {
                    Point point = gridRows[i].Points[j];

                    Console.Write(String.Format("{0},{1}", point.X, point.Y));

                    if (j != gridDimension - 1)
                    {
                        Console.Write(" - ");
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a grid's columns to the standard console.
        /// </summary>
        /// <param name="gridColumns"></param>
        /// <param name="gridDimension"></param>
        private void PrintColumns(List<GridColumn> gridColumns, int gridDimension)
        {
            for (int i = 0; i < gridDimension; i++)
            {
                Console.Write(String.Format("Column {0}: ", i));

                for (int j = 0; j < gridDimension; j++)
                {
                    Point point = gridColumns[i].Points[j];

                    Console.Write(String.Format("{0},{1}", point.X, point.Y));

                    if (j != gridDimension - 1)
                    {
                        Console.Write(" - ");
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a grid's alpha value to the standard console.
        /// </summary>
        private void PrintAlpha(double? alpha)
        {
            Console.Write(String.Format("Alpha={0} degrees", alpha));
        }
    }
}