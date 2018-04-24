using System.Collections.Generic;

namespace GridCreator.Models
{
    public class GridRow
    {
        // Public members
        public List<Point> Points { get; set; }

        /// <summary>
        /// Initialize a new grid row with an empty collection of points
        /// </summary>
        public GridRow()
        {
            Points = new List<Point>();
        }
    }
}