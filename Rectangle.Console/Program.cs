using System.Collections.Generic;
using System.Linq;
using Rectangle.Impl;

namespace Rectangle.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			List<Point> points = new List<Point>() {
				new Point(2, 1),
				new Point(4, 1),
				new Point(5, 4),
				new Point(3, 5),
				new Point(1, 3),
				};

			Impl.Rectangle rectangle = Service.FindRectangle(points);

			System.Console.WriteLine(rectangle.LeftUpPoint.X + ";" + rectangle.LeftUpPoint.Y + "       " + rectangle.RightUpPoint.X + ";" + rectangle.RightUpPoint.Y);
			System.Console.WriteLine();
			System.Console.WriteLine(rectangle.LeftDownPoint.X + ";" + rectangle.LeftDownPoint.Y + "       " + rectangle.RightDownPoint.X + ";" + rectangle.RightDownPoint.Y);
			System.Console.WriteLine("Widht = " + rectangle.Width + "   Height = " + rectangle.Height);

			System.Console.ReadKey();
		}
	}
}