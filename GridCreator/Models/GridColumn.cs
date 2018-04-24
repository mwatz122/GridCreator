using System.Collections.Generic;

namespace GridCreator.Models
{
    public class GridColumn
    {
        // Public members
        public List<Point> Points { get; set; }

        /// <summary>
        /// Initialize a new grid column with an empty collection of points
        /// </summary>
        public GridColumn()
        {
            Points = new List<Point>();
        }
    }
}