using System;

namespace GridCreator.Models
{
    public class Point : IEquatable<Point>
    {
        // Public members
        public bool Visited { get; set; }
        public double X { get; protected set; }
        public double Y { get; protected set; }

        /// <summary>
        /// Initialize a point given (x,y) coordinate pair
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Check two points for equality
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Point other)
        {
            return (X == other.X && Y == other.Y);
        }

        public override bool Equals(Object obj)
        {
            return Equals((Point)obj);
        }
    }
}