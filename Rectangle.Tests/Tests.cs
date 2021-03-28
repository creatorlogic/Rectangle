using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class Tests
	{
		[Test]
		public void IsDuplicate_ReturnsTrue()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(1, 2),
				new Point(1, 2)
			};
			bool expected = true;

			// Act
			var actual = Service.IsDuplicate(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void IsNull_ReturnsTrue()
		{
			// Arrange
			List<Point> points = new List<Point>();
			bool expected = true;

			// Act
			var actual = Service.IsNull(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}


		[Test]
		public void IsAllowableCountPoints_ReturnsFalse()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(1, 1)
			};
			bool expected = false;

			// Act
			var actual = Service.IsAllowableCountPoints(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void SwapTwoDots()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(2, 0),
				new Point(1, 1)
			};
			var expected = new List<Point>()
			{
				new Point(2, 0),
				new Point(1, 1)
			};

			// Act
			Service.SwapTwoDots(points);
			var actual = points;

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void FindRectangleByTwoDots()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(1, 1),
				new Point(2, 2)
			};
			Point LeftDownPoint = new Point(2, 2);
			Point RightDownPoint = new Point(3, 2);
			Point RightUpPoint = new Point(3, 3);
			Point LeftUpPoint = new Point(2, 3);

			Impl.Rectangle expected = new Impl.Rectangle(LeftDownPoint, RightDownPoint, RightUpPoint, LeftUpPoint);

			// Act
			var actual = Service.FindRectangleByTwoDots(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CountDuplicate_ReturnsTrue()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(5, 0),
				new Point(5, 1),

			};
			int value = 5;

			bool expected = true;

			// Act
			var actual = Service.CountDuplicate(points, value);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void IsSeveralMinX_ReturnsTrue()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(1, 1),
				new Point(1, 2),
				new Point(2, 3),
				new Point(4, 1),
				new Point(4, 3)
			};
			bool expected = true;

			// Act
			var actual = Service.IsSeveralMinX(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void IsSeveralMaxX_ReturnsTrue()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(2, 1),
				new Point(3, 1),
				new Point(4, 3),
				new Point(5, 1),
				new Point(5, 2)
			};
			bool expected = true;

			// Act
			var actual = Service.IsSeveralMaxX(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void IsSeveralMinY_ReturnsFalse()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(2, 1),
				new Point(4, 1),
				new Point(4, 3),
				new Point(2, 3),
				new Point(2, 0),
			};
			bool expected = false;

			// Act
			var actual = Service.IsSeveralMinY(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void IsSeveralMaxY_ReturnsTrue()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(2, 1),
				new Point(4, 1),
				new Point(4, 3),
				new Point(2, 3),
				new Point(2, 4),
				new Point(3, 4)
			};
			bool expected = true;

			// Act
			var actual = Service.IsSeveralMaxY(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void FindRectangleByManyDots()
		{
			// Arrange
			List<Point> points = new List<Point>()
			{
				new Point(2, 2),
				new Point(4, 1),
				new Point(5, 4),
				new Point(2, 5),
				new Point(1, 3)
			};
			Point LeftDownPoint = new Point(2, 1);
			Point RightDownPoint = new Point(5, 1);
			Point RightUpPoint = new Point(5, 5);
			Point LeftUpPoint = new Point(2, 5);

			Impl.Rectangle expected = new Impl.Rectangle(LeftDownPoint, RightDownPoint, RightUpPoint, LeftUpPoint);


			// Act
			Impl.Rectangle actual = Service.FindRectangleByManyDots(points);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}