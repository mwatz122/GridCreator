using GridCreator.Models;
using System;
using System.Collections.Generic;

namespace GridCreator
{
    class Program
    {
        /// <summary>
        /// GridCreator entry point. Pass in the path to a file containing points to be arranged on a grid.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    string file = args[0];

                    // 1. Parse the file
                    GridParser gridParser = new GridParser();
                    IEnumerable<Point> points = gridParser.ParseFile(file);

                    // 2. Create the grid
                    GridCreator gridCreator = new GridCreator();
                    Grid grid = gridCreator.CreateGrid(points);

                    // 3. Print the grid
                    GridPrinter gridPrinter = new GridPrinter();
                    gridPrinter.PrintGrid(grid);
                }
                else
                {
                    Console.WriteLine("Please supply the path to a file containing points to be arranged on a grid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating your grid. See exception for details.");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}