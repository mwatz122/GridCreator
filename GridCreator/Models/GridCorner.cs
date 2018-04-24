namespace GridCreator.Models
{
    public class GridCorner : Point
    {
        // Public members
        public Enums.GridCornerPosition Position { get; set; }

        /// <summary>
        /// Initialize a grid corner located at provided position (top left, top right, bottom left, bottom right)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="position"></param>
        public GridCorner(Point point, Enums.GridCornerPosition position)
            : base(point.X, point.Y)
        {
            Position = position;
        }
    }
}