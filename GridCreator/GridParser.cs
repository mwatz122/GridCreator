using GridCreator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GridCreator
{
    public class GridParser
    {
        /// <summary>
        /// Parses a file containing points to be arranged on a grid. Returns points.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public IEnumerable<Point> ParseFile(string file)
        {
            List<Point> points = new List<Point>();
            IEnumerable<string> lines = File.ReadLines(file);

            ValidateNumberOfLines(lines.Count());

            foreach (string line in lines)
            {
                string[] coordinates = line.Split(',');

                double x = double.Parse(coordinates[0]);
                double y = double.Parse(coordinates[1]);

                points.Add(new Point(x, y));
            }

            return points;
        }

        /// <summary>
        /// Check to make sure the number of lines in the file is valid. If not, this method will throw an exception.
        /// </summary>
        /// <param name="count"></param>
        private void ValidateNumberOfLines(int count)
        {
            if (count < 4 || Math.Sqrt(count) % 1 != 0)
            {
                throw new Exception(String.Format("Error: The file contains an invalid number of points. ({0})", count));
            }
        }
    }
}