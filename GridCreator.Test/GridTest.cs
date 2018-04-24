using GridCreator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GridCreator.Test
{
    [TestClass]
    public class GridTest
    {
        #region TwoByTwoTiltedGridWithNormalNumbers
        [TestMethod]
        public void TwoByTwoTiltedGridWithNormalNumbers()
        {
            // arrange
            List<Point> points = new List<Point>();
            points.Add(new Point(24.3, 16));
            points.Add(new Point(14.5, 12.7));
            points.Add(new Point(27.6, 6.2));
            points.Add(new Point(17.8, 2.9));

            // act
            GridCreator gridCreator = new GridCreator();
            Grid grid = gridCreator.CreateGrid(points);

            // assert
            Assert.AreEqual(grid.GetPoint(0, 0), new Point(14.5, 12.7)); // row 1 column 1
            Assert.AreEqual(grid.GetPoint(1, 0), new Point(24.3, 16)); // row 1 column 2

            Assert.AreEqual(grid.GetPoint(0, 1), new Point(17.8, 2.9)); // row 2 column 1
            Assert.AreEqual(grid.GetPoint(1, 1), new Point(27.6, 6.2)); // row 2 column 2

            Assert.AreEqual(grid.GetAlpha().Value, 18.6); // check alpha
        }
        #endregion

        #region ThreeByThreeStraightGridWithNormalNumbers
        [TestMethod]
        public void ThreeByThreeStraightGridWithNormalNumbers()
        {
            // arrange
            List<Point> points = new List<Point>();
            points.Add(new Point(14, 14));
            points.Add(new Point(12, 10));
            points.Add(new Point(12, 12));
            points.Add(new Point(14, 10));
            points.Add(new Point(10, 10));
            points.Add(new Point(14, 12));
            points.Add(new Point(10, 12));
            points.Add(new Point(10, 14));
            points.Add(new Point(12, 14));

            // act
            GridCreator gridCreator = new GridCreator();
            Grid grid = gridCreator.CreateGrid(points);

            // assert
            Assert.AreEqual(grid.GetPoint(0, 0), new Point(10, 14)); // row 1 column 1
            Assert.AreEqual(grid.GetPoint(1, 0), new Point(12, 14)); // row 1 column 2
            Assert.AreEqual(grid.GetPoint(2, 0), new Point(14, 14)); // row 1 column 3

            Assert.AreEqual(grid.GetPoint(0, 1), new Point(10, 12)); // row 2 column 1
            Assert.AreEqual(grid.GetPoint(1, 1), new Point(12, 12)); // row 2 column 2
            Assert.AreEqual(grid.GetPoint(2, 1), new Point(14, 12)); // row 2 column 3

            Assert.AreEqual(grid.GetPoint(0, 2), new Point(10, 10)); // row 3 column 1
            Assert.AreEqual(grid.GetPoint(1, 2), new Point(12, 10)); // row 3 column 2
            Assert.AreEqual(grid.GetPoint(2, 2), new Point(14, 10)); // row 3 column 3

            Assert.AreEqual(grid.GetAlpha().Value, 0); // check alpha
        }
        #endregion

        #region ThreeByThreeTiltedGridWithDecimalNumbers
        [TestMethod]
        public void ThreeByThreeTiltedGridWithDecimalNumbers()
        {
            // arrange
            List<Point> points = new List<Point>();
            points.Add(new Point(11.7, 14.1));
            points.Add(new Point(13.7, 14.3));
            points.Add(new Point(10, 10));
            points.Add(new Point(9.9, 12));
            points.Add(new Point(13.8, 12.3));
            points.Add(new Point(12, 10.1));
            points.Add(new Point(9.7, 14));
            points.Add(new Point(11.8, 12.1));
            points.Add(new Point(14, 10.3));

            // act
            GridCreator gridCreator = new GridCreator();
            Grid grid = gridCreator.CreateGrid(points);

            // assert
            Assert.AreEqual(grid.GetPoint(0, 0), new Point(9.7, 14)); // row 1 column 1
            Assert.AreEqual(grid.GetPoint(1, 0), new Point(11.7, 14.1)); // row 1 column 2
            Assert.AreEqual(grid.GetPoint(2, 0), new Point(13.7, 14.3)); // row 1 column 3

            Assert.AreEqual(grid.GetPoint(0, 1), new Point(9.9, 12)); // row 2 column 1
            Assert.AreEqual(grid.GetPoint(1, 1), new Point(11.8, 12.1)); // row 2 column 2
            Assert.AreEqual(grid.GetPoint(2, 1), new Point(13.8, 12.3)); // row 2 column 3

            Assert.AreEqual(grid.GetPoint(0, 2), new Point(10, 10)); // row 3 column 1
            Assert.AreEqual(grid.GetPoint(1, 2), new Point(12, 10.1)); // row 3 column 2
            Assert.AreEqual(grid.GetPoint(2, 2), new Point(14, 10.3)); // row 3 column 3

            Assert.AreEqual(grid.GetAlpha().Value, 4.3); // check alpha
        }
        #endregion

        #region ThreeByThreeTiltedGridWithLargeNumbers
        [TestMethod]
        public void ThreeByThreeTiltedGridWithLargeNumbers()
        {
            // arrange
            List<Point> points = new List<Point>();
            points.Add(new Point(117000, 141000));
            points.Add(new Point(137000, 143000));
            points.Add(new Point(100000, 100000));
            points.Add(new Point(99000, 120000));
            points.Add(new Point(138000, 123000));
            points.Add(new Point(120000, 101000));
            points.Add(new Point(97000, 140000));
            points.Add(new Point(118000, 121000));
            points.Add(new Point(140000, 103000));

            // act
            GridCreator gridCreator = new GridCreator();
            Grid grid = gridCreator.CreateGrid(points);

            // assert
            Assert.AreEqual(grid.GetPoint(0, 0), new Point(97000, 140000)); // row 1 column 1
            Assert.AreEqual(grid.GetPoint(1, 0), new Point(117000, 141000)); // row 1 column 2
            Assert.AreEqual(grid.GetPoint(2, 0), new Point(137000, 143000)); // row 1 column 3

            Assert.AreEqual(grid.GetPoint(0, 1), new Point(99000, 120000)); // row 2 column 1
            Assert.AreEqual(grid.GetPoint(1, 1), new Point(118000, 121000)); // row 2 column 2
            Assert.AreEqual(grid.GetPoint(2, 1), new Point(138000, 123000)); // row 2 column 3

            Assert.AreEqual(grid.GetPoint(0, 2), new Point(100000, 100000)); // row 3 column 1
            Assert.AreEqual(grid.GetPoint(1, 2), new Point(120000, 101000)); // row 3 column 2
            Assert.AreEqual(grid.GetPoint(2, 2), new Point(140000, 103000)); // row 3 column 3

            Assert.AreEqual(grid.GetAlpha().Value, 4.3); // check alpha
        }
        #endregion

        #region ThreeByThreeStraightGridWithSomeNegativeNumbers
        [TestMethod]
        public void ThreeByThreeStraightGridWithSomeNegativeNumbers()
        {
            // arrange
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 1));
            points.Add(new Point(-1, 0));
            points.Add(new Point(-1, 1));
            points.Add(new Point(1, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(-1, -1));
            points.Add(new Point(1, 1));
            points.Add(new Point(1, -1));
            points.Add(new Point(0, -1));

            // act
            GridCreator gridCreator = new GridCreator();
            Grid grid = gridCreator.CreateGrid(points);

            // assert
            Assert.AreEqual(grid.GetPoint(0, 0), new Point(-1, 1)); // row 1 column 1
            Assert.AreEqual(grid.GetPoint(1, 0), new Point(0, 1)); // row 1 column 2
            Assert.AreEqual(grid.GetPoint(2, 0), new Point(1, 1)); // row 1 column 3

            Assert.AreEqual(grid.GetPoint(0, 1), new Point(-1, 0)); // row 2 column 1
            Assert.AreEqual(grid.GetPoint(1, 1), new Point(0, 0)); // row 2 column 2
            Assert.AreEqual(grid.GetPoint(2, 1), new Point(1, 0)); // row 2 column 3

            Assert.AreEqual(grid.GetPoint(0, 2), new Point(-1, -1)); // row 3 column 1
            Assert.AreEqual(grid.GetPoint(1, 2), new Point(0, -1)); // row 3 column 2
            Assert.AreEqual(grid.GetPoint(2, 2), new Point(1, -1)); // row 3 column 3

            Assert.AreEqual(grid.GetAlpha().Value, 0); // check alpha
        }
        #endregion

        #region FiveByFiveTiltedGridWithNegativeNumbers
        [TestMethod]
        public void FiveByFiveTiltedGridWithNegativeNumbers()
        {
            // arrange
            List<Point> points = new List<Point>();
            points.Add(new Point(-1125.48, -662.88));
            points.Add(new Point(-1053.13, -538.25));
            points.Add(new Point(-928.50, -610.60));
            points.Add(new Point(-1302.38, -393.55));
            points.Add(new Point(-1394.80, -839.78));
            points.Add(new Point(-1591.78, -892.05));
            points.Add(new Point(-1342.53, -1036.75));
            points.Add(new Point(-1073.20, -859.85));
            points.Add(new Point(-1499.35, -445.83));
            points.Add(new Point(-1145.55, -984.48));
            points.Add(new Point(-1571.70, -570.45));
            points.Add(new Point(-1644.05, -695.08));
            points.Add(new Point(-1217.90, -1109.10));
            points.Add(new Point(-1716.40, -819.70));
            points.Add(new Point(-1467.15, -964.40));
            points.Add(new Point(-1519.43, -767.43));
            points.Add(new Point(-1447.08, -642.80));
            points.Add(new Point(-1177.75, -465.90));
            points.Add(new Point(-1374.73, -518.18));
            points.Add(new Point(-1000.85, -735.23));
            points.Add(new Point(-1250.10, -590.53));
            points.Add(new Point(-1427.00, -321.20));
            points.Add(new Point(-1322.45, -715.15));
            points.Add(new Point(-1270.18, -912.13));
            points.Add(new Point(-1197.83, -787.50));

            // act
            GridCreator gridCreator = new GridCreator();
            Grid grid = gridCreator.CreateGrid(points);

            // assert
            Assert.AreEqual(grid.GetPoint(0, 0), new Point(-1427.00, -321.20)); // row 1 column 1
            Assert.AreEqual(grid.GetPoint(1, 0), new Point(-1302.38, -393.55)); // row 1 column 2
            Assert.AreEqual(grid.GetPoint(2, 0), new Point(-1177.75, -465.90)); // row 1 column 3
            Assert.AreEqual(grid.GetPoint(3, 0), new Point(-1053.13, -538.25)); // row 1 column 4
            Assert.AreEqual(grid.GetPoint(4, 0), new Point(-928.50, -610.60)); // row 1 column 5

            Assert.AreEqual(grid.GetPoint(0, 1), new Point(-1499.35, -445.83)); // row 2 column 1
            Assert.AreEqual(grid.GetPoint(1, 1), new Point(-1374.73, -518.18)); // row 2 column 2
            Assert.AreEqual(grid.GetPoint(2, 1), new Point(-1250.10, -590.53)); // row 2 column 3
            Assert.AreEqual(grid.GetPoint(3, 1), new Point(-1125.48, -662.88)); // row 2 column 4
            Assert.AreEqual(grid.GetPoint(4, 1), new Point(-1000.85, -735.23)); // row 2 column 5

            Assert.AreEqual(grid.GetPoint(0, 2), new Point(-1571.70, -570.45)); // row 3 column 1
            Assert.AreEqual(grid.GetPoint(1, 2), new Point(-1447.08, -642.80)); // row 3 column 2
            Assert.AreEqual(grid.GetPoint(2, 2), new Point(-1322.45, -715.15)); // row 3 column 3
            Assert.AreEqual(grid.GetPoint(3, 2), new Point(-1197.83, -787.50)); // row 3 column 4
            Assert.AreEqual(grid.GetPoint(4, 2), new Point(-1073.20, -859.85)); // row 3 column 5

            Assert.AreEqual(grid.GetPoint(0, 3), new Point(-1644.05, -695.08)); // row 4 column 1
            Assert.AreEqual(grid.GetPoint(1, 3), new Point(-1519.43, -767.43)); // row 4 column 2
            Assert.AreEqual(grid.GetPoint(2, 3), new Point(-1394.80, -839.78)); // row 4 column 3
            Assert.AreEqual(grid.GetPoint(3, 3), new Point(-1270.18, -912.13)); // row 4 column 4
            Assert.AreEqual(grid.GetPoint(4, 3), new Point(-1145.55, -984.48)); // row 4 column 5

            Assert.AreEqual(grid.GetPoint(0, 4), new Point(-1716.40, -819.70)); // row 5 column 1
            Assert.AreEqual(grid.GetPoint(1, 4), new Point(-1591.78, -892.05)); // row 5 column 2
            Assert.AreEqual(grid.GetPoint(2, 4), new Point(-1467.15, -964.40)); // row 5 column 3
            Assert.AreEqual(grid.GetPoint(3, 4), new Point(-1342.53, -1036.75)); // row 5 column 4
            Assert.AreEqual(grid.GetPoint(4, 4), new Point(-1217.90, -1109.10)); // row 5 column 5

            Assert.AreEqual(grid.GetAlpha().Value, 30.1); // check alpha
        }
        #endregion

        #region FiveByFiveTiltedGridWithSmallNumbers
        [TestMethod]
        public void FiveByFiveTiltedGridWithSmallNumbers()
        {
            // arrange
            List<Point> points = new List<Point>();
            points.Add(new Point(0.00143782, 0.00291986));
            points.Add(new Point(0.00160532, 0.00282204));
            points.Add(new Point(0.00177148, 0.00272556));
            points.Add(new Point(0.00193898, 0.00262908));
            points.Add(new Point(0.00210514, 0.00253126));
            points.Add(new Point(0.00134134, 0.00275236));
            points.Add(new Point(0.0015075, 0.00265588));
            points.Add(new Point(0.001675, 0.00255806));
            points.Add(new Point(0.0018425, 0.00246158));
            points.Add(new Point(0.00200866, 0.0023651));
            points.Add(new Point(0.00124352, 0.0025862));
            points.Add(new Point(0.00141102, 0.00248838));
            points.Add(new Point(0.00157852, 0.0023919));
            points.Add(new Point(0.00174468, 0.00229542));
            points.Add(new Point(0.00191218, 0.0021976));
            points.Add(new Point(0.00114704, 0.0024187));
            points.Add(new Point(0.00131454, 0.00232222));
            points.Add(new Point(0.0014807, 0.002244));
            points.Add(new Point(0.0016482, 0.00212792));
            points.Add(new Point(0.00181436, 0.00203144));
            points.Add(new Point(0.00105056, 0.0022512));
            points.Add(new Point(0.00121672, 0.00215472));
            points.Add(new Point(0.00138422, 0.00205824));
            points.Add(new Point(0.00155038, 0.00196042));
            points.Add(new Point(0.00171788, 0.00186394));

            // act
            GridCreator gridCreator = new GridCreator();
            Grid grid = gridCreator.CreateGrid(points);

            // assert
            Assert.AreEqual(grid.GetPoint(0, 0), new Point(0.00143782, 0.00291986)); // row 1 column 1
            Assert.AreEqual(grid.GetPoint(1, 0), new Point(0.00160532, 0.00282204)); // row 1 column 2
            Assert.AreEqual(grid.GetPoint(2, 0), new Point(0.00177148, 0.00272556)); // row 1 column 3
            Assert.AreEqual(grid.GetPoint(3, 0), new Point(0.00193898, 0.00262908)); // row 1 column 4
            Assert.AreEqual(grid.GetPoint(4, 0), new Point(0.00210514, 0.00253126)); // row 1 column 5

            Assert.AreEqual(grid.GetPoint(0, 1), new Point(0.00134134, 0.00275236)); // row 2 column 1
            Assert.AreEqual(grid.GetPoint(1, 1), new Point(0.0015075, 0.00265588)); // row 2 column 2
            Assert.AreEqual(grid.GetPoint(2, 1), new Point(0.001675, 0.00255806)); // row 2 column 3
            Assert.AreEqual(grid.GetPoint(3, 1), new Point(0.0018425, 0.00246158)); // row 2 column 4
            Assert.AreEqual(grid.GetPoint(4, 1), new Point(0.00200866, 0.0023651)); // row 2 column 5

            Assert.AreEqual(grid.GetPoint(0, 2), new Point(0.00124352, 0.0025862)); // row 3 column 1
            Assert.AreEqual(grid.GetPoint(1, 2), new Point(0.00141102, 0.00248838)); // row 3 column 2
            Assert.AreEqual(grid.GetPoint(2, 2), new Point(0.00157852, 0.0023919)); // row 3 column 3
            Assert.AreEqual(grid.GetPoint(3, 2), new Point(0.00174468, 0.00229542)); // row 3 column 4
            Assert.AreEqual(grid.GetPoint(4, 2), new Point(0.00191218, 0.0021976)); // row 3 column 5

            Assert.AreEqual(grid.GetPoint(0, 3), new Point(0.00114704, 0.0024187)); // row 4 column 1
            Assert.AreEqual(grid.GetPoint(1, 3), new Point(0.00131454, 0.00232222)); // row 4 column 2
            Assert.AreEqual(grid.GetPoint(2, 3), new Point(0.0014807, 0.002244)); // row 4 column 3
            Assert.AreEqual(grid.GetPoint(3, 3), new Point(0.0016482, 0.00212792)); // row 4 column 4
            Assert.AreEqual(grid.GetPoint(4, 3), new Point(0.00181436, 0.00203144)); // row 4 column 5

            Assert.AreEqual(grid.GetPoint(0, 4), new Point(0.00105056, 0.0022512)); // row 5 column 1
            Assert.AreEqual(grid.GetPoint(1, 4), new Point(0.00121672, 0.00215472)); // row 5 column 2
            Assert.AreEqual(grid.GetPoint(2, 4), new Point(0.00138422, 0.00205824)); // row 5 column 3
            Assert.AreEqual(grid.GetPoint(3, 4), new Point(0.00155038, 0.00196042)); // row 5 column 4
            Assert.AreEqual(grid.GetPoint(4, 4), new Point(0.00171788, 0.00186394)); // row 5 column 5

            Assert.AreEqual(grid.GetAlpha().Value, 30.1); // check alpha
        }
        #endregion
    }
}