using System;

namespace GridCreator.Models
{
    public class Line
    {
        // Private members
        private Point _pointOne { get; set; }
        private Point _pointTwo { get; set; }
        private double? _length { get; set; }

        /*
         * NOTE:
         * This value represents a degree of tolerance for determing if a given point falls on a line.
         * This is necessary due to floating point errors. It can be adjusted if needed.
         */
        private const double THRESHOLD = 0.01;

        /// <summary>
        /// Initialize a line given two points
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        public Line(Point pointOne, Point pointTwo)
        {
            _pointOne = pointOne;
            _pointTwo = pointTwo;
        }

        /// <summary>
        /// Returns the length of the line
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            _length = _length ?? DistanceBetweenPoints(_pointOne, _pointTwo); // lazy load
            return _length.Value;
        }

        /// <summary>
        /// Returns true if line contains the given point (within threshold)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool ContainsPoint(Point point)
        {
            double d1 = GetLength();
            double d2 = DistanceBetweenPoints(_pointOne, point);
            double d3 = DistanceBetweenPoints(_pointTwo, point);

            return (Math.Abs(d1 - (d2 + d3)) <= THRESHOLD * d1);
        }

        /// <summary>
        /// Calculate distance between two points
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        /// <returns></returns>
        private double DistanceBetweenPoints(Point pointOne, Point pointTwo)
        {
            return Math.Sqrt(Math.Pow(pointOne.X - pointTwo.X, 2) + Math.Pow(pointOne.Y - pointTwo.Y, 2));
        }
    }
}