using System;
using System.Collections.Generic;
using System.Linq;

namespace GridCreator.Models
{
    public class Grid
    {
        // Private members
        private Point[,] _gridArray { get; set; }

        // Public members
        public int Dimension { get; private set; }
        public Enums.GridOrientation Orientation { get; set; }
        public IEnumerable<GridCorner> Corners { get; set; }

        /// <summary>
        /// Initialize a square grid (dxd) with constant dimension
        /// </summary>
        /// <param name="dimension"></param>
        public Grid(int dimension)
        {
            Dimension = dimension;
            _gridArray = new Point[Dimension, Dimension];
        }

        /// <summary>
        /// Get point on the grid located at coordinates (x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Point GetPoint(int x, int y)
        {
            return _gridArray[x, y];
        }

        /// <summary>
        /// Get grid corner located at provided position (top left, top right, bottom left, bottom right)
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public GridCorner GetGridCorner(Enums.GridCornerPosition position)
        {
            if (Corners == null)
            {
                return null;
            }
            else
            {
                return Corners.Where(c => c.Position == position).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get alpha (the angle between any row and the x axis)
        /// </summary>
        /// <returns></returns>
        public double? GetAlpha()
        {
            if (Corners == null)
            {
                return null;
            }
            else
            {
                // Line segment one (bottom edge of the grid)
                Point pointOne = GetGridCorner(Enums.GridCornerPosition.BottomLeft);
                Point pointTwo = GetGridCorner(Enums.GridCornerPosition.BottomRight);

                // Line segment two (x axis)
                Point pointThree = new Point(0, 0);
                Point pointFour = new Point(10, 0);

                // Calculate angle
                double thetaOne = Math.Atan2(pointOne.Y - pointTwo.Y, pointOne.X - pointTwo.X);
                double thetaTwo = Math.Atan2(pointThree.Y - pointFour.Y, pointThree.X - pointFour.X);
                double diff = Math.Abs(thetaOne - thetaTwo);

                // Take minor angle
                double angle = Math.Min(diff, Math.Abs(2 * Math.PI - diff));

                // Return angle (converted from radians to degrees, rounded to tenths place)
                return Math.Round(angle * (180 / Math.PI), 1);
            }
        }

        /// <summary>
        /// Add grid row at provided inex
        /// </summary>
        /// <param name="gridRow"></param>
        /// <param name="index"></param>
        public void AddGridRow(GridRow gridRow, int index)
        {
            for (int i = 0; i < gridRow.Points.Count(); i++)
            {
                _gridArray[i, index] = gridRow.Points.ElementAt(i);
            }
        }

        /// <summary>
        /// Add grid column at provided index
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="index"></param>
        public void AddGridColumn(GridColumn gridColumn, int index)
        {
            for (int i = 0; i < gridColumn.Points.Count(); i++)
            {
                _gridArray[index, i] = gridColumn.Points.ElementAt(i);
            }
        }

        /// <summary>
        /// Get a list of sorted grid rows (ascending)
        /// </summary>
        /// <returns></returns>
        public List<GridRow> GetGridRows()
        {
            List<GridRow> gridRows = new List<GridRow>();

            for (int i = 0; i < Dimension; i++)
            {
                GridRow gridRow = new GridRow();

                for (int j = 0; j < Dimension; j++)
                {
                    gridRow.Points.Add(GetPoint(j, i));
                }

                gridRows.Add(gridRow);
            }

            return gridRows;
        }

        /// <summary>
        /// Get a list of sorted grid columns (ascending)
        /// </summary>
        /// <returns></returns>
        public List<GridColumn> GetGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>();

            for (int i = 0; i < Dimension; i++)
            {
                GridColumn gridColumn = new GridColumn();

                for (int j = 0; j < Dimension; j++)
                {
                    gridColumn.Points.Add(GetPoint(i, j));
                }

                gridColumns.Add(gridColumn);
            }

            return gridColumns;
        }
    }
}