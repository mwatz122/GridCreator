using GridCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridCreator
{
    public class GridCreator
    {
        // Private members
        private Grid _grid { get; set; }

        /// <summary>
        /// Create a grid object with rows and columns given a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public Grid CreateGrid(IEnumerable<Point> points)
        {
            _grid = new Grid(GetGridDimension(points));
            _grid.Orientation = GetGridOrientation(points);
            _grid.Corners = GetGridCorners(points);

            PopulateGridPoints(points);

            return _grid;
        }

        /// <summary>
        /// Returns the grid's dimension given a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private int GetGridDimension(IEnumerable<Point> points)
        {
            return (int)Math.Sqrt(points.Count());
        }

        /// <summary>
        /// Identify whether the orientation of the grid is straight (alpha = 0) or tilted (alpha > 0).
        /// If the two maximum y values are equal, the grid orientation must be straight.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private Enums.GridOrientation GetGridOrientation(IEnumerable<Point> points)
        {
            IEnumerable<Point> pointsOrderedByY = points.OrderBy(p => p.Y);

            if (pointsOrderedByY.ElementAt(0).Y == pointsOrderedByY.ElementAt(1).Y)
            {
                return Enums.GridOrientation.Straight;
            }
            else
            {
                return Enums.GridOrientation.Tilted;
            }
        }

        /// <summary>
        /// Identify corners of the grid based on points with extreme x/y values.
        /// Corners are then categorized (top left, top right, bottom left, bottom right) assuming a normal viewing perspective.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private IEnumerable<GridCorner> GetGridCorners(IEnumerable<Point> points)
        {
            if (_grid.Orientation == Enums.GridOrientation.Straight)
            {
                IEnumerable<Point> pointsOrderedByXThenY = points.OrderBy(p => p.X).ThenBy(p => p.Y);

                List<GridCorner> corners = new List<GridCorner>();
                corners.Add(new GridCorner(pointsOrderedByXThenY.First(), Enums.GridCornerPosition.BottomLeft)); // bottom left
                corners.Add(new GridCorner(pointsOrderedByXThenY.ElementAt(_grid.Dimension - 1), Enums.GridCornerPosition.TopLeft)); // top left
                corners.Add(new GridCorner(pointsOrderedByXThenY.ElementAt(points.Count() - _grid.Dimension), Enums.GridCornerPosition.BottomRight)); // bottom right
                corners.Add(new GridCorner(pointsOrderedByXThenY.Last(), Enums.GridCornerPosition.TopRight)); // top right

                return corners;
            }
            else if (_grid.Orientation == Enums.GridOrientation.Tilted)
            {
                IEnumerable<Point> pointsOrderedByX = points.OrderBy(p => p.X);
                IEnumerable<Point> pointsOrderedByY = points.OrderBy(p => p.Y);

                List<GridCorner> corners = new List<GridCorner>();

                if (pointsOrderedByX.First().Y >= pointsOrderedByX.Last().Y)
                {
                    corners.Add(new GridCorner(pointsOrderedByX.First(), Enums.GridCornerPosition.TopLeft)); // top left
                    corners.Add(new GridCorner(pointsOrderedByX.Last(), Enums.GridCornerPosition.BottomRight)); // bottom right
                    corners.Add(new GridCorner(pointsOrderedByY.First(), Enums.GridCornerPosition.BottomLeft)); // bottom left
                    corners.Add(new GridCorner(pointsOrderedByY.Last(), Enums.GridCornerPosition.TopRight)); // top right
                }
                else
                {
                    corners.Add(new GridCorner(pointsOrderedByX.First(), Enums.GridCornerPosition.BottomLeft)); // bottom left
                    corners.Add(new GridCorner(pointsOrderedByX.Last(), Enums.GridCornerPosition.TopRight)); // top right
                    corners.Add(new GridCorner(pointsOrderedByY.First(), Enums.GridCornerPosition.BottomRight)); // bottom right
                    corners.Add(new GridCorner(pointsOrderedByY.Last(), Enums.GridCornerPosition.TopLeft)); // top left
                }

                return corners;
            }
            else
            {
                throw new Exception("Error: Missing grid orientation.");
            }
        }

        /// <summary>
        /// Given a set of points on a grid, categorize them into rows and columns
        /// </summary>
        /// <param name="points"></param>
        private void PopulateGridPoints(IEnumerable<Point> points)
        {
            // Populate top and bottom rows first
            PopulateRowPoints(points, 0, new Line(_grid.GetGridCorner(Enums.GridCornerPosition.TopLeft), _grid.GetGridCorner(Enums.GridCornerPosition.TopRight)));
            PopulateRowPoints(points, _grid.Dimension - 1, new Line(_grid.GetGridCorner(Enums.GridCornerPosition.BottomLeft), _grid.GetGridCorner(Enums.GridCornerPosition.BottomRight)));

            // Then populate all columns
            for (int i = 0; i < _grid.Dimension; i++)
            {
                PopulateColumnPoints(points, i, new Line(_grid.GetPoint(i, 0), _grid.GetPoint(i, _grid.Dimension - 1)));
            }
        }

        /// <summary>
        /// Determine if a set of points fall on a given line.
        /// If they do, add them to a GridRow and then insert the GridRow into the Grid at the provided index.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="rowIndex"></param>
        /// <param name="rowLine"></param>
        private void PopulateRowPoints(IEnumerable<Point> points, int rowIndex, Line rowLine)
        {
            GridRow gridRow = new GridRow();

            foreach (Point point in points)
            {
                if (rowLine.ContainsPoint(point))
                {
                    gridRow.Points.Add(point);
                }

                if (gridRow.Points.Count() == _grid.Dimension) break;
            }

            gridRow.Points = gridRow.Points.OrderBy(p => p.X).ToList();
            _grid.AddGridRow(gridRow, rowIndex);
        }

        /// <summary>
        /// Determine if a set of points fall on a given line.
        /// If they do, add them to a GridColumn and then insert the GridColumn into the Grid at the provided index.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="columnIndex"></param>
        /// <param name="columnLine"></param>
        private void PopulateColumnPoints(IEnumerable<Point> points, int columnIndex, Line columnLine)
        {
            GridColumn gridColumn = new GridColumn();

            foreach (Point point in points)
            {
                if (point.Visited) continue;

                if (columnLine.ContainsPoint(point))
                {
                    point.Visited = true; // mark the point as visited so it will not be checked again
                    gridColumn.Points.Add(point);
                }

                if (gridColumn.Points.Count() == _grid.Dimension) break;
            }

            gridColumn.Points = gridColumn.Points.OrderByDescending(p => p.Y).ToList();
            _grid.AddGridColumn(gridColumn, columnIndex);
        }
    }
}