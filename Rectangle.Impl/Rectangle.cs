using System;

namespace Rectangle.Impl
{
    public sealed class Rectangle
    {
        public Point LeftDownPoint = new Point();
        public Point RightDownPoint = new Point();
        public Point RightUpPoint = new Point();
        public Point LeftUpPoint = new Point();

        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(Point leftDownPoint, Point rightDownPoint, Point rightUpPoint, Point leftUpPoint)
        {
            LeftDownPoint = leftDownPoint;
            RightDownPoint = rightDownPoint;
            RightUpPoint = rightUpPoint;
            LeftUpPoint = leftUpPoint;
        }
        public void SetLeftDownPoint(int x, int y)
        {
            LeftDownPoint.X = x;
            LeftDownPoint.Y = y;
        }

        public void SetRightDownPoint(int x, int y)
        {
            RightDownPoint.X = x;
            RightDownPoint.Y = y;
        }

        public void SetRightUpPoint(int x, int y)
        {
            RightUpPoint.X = x;
            RightUpPoint.Y = y;
        }

        public void SetLeftUpPoint(int x, int y)
        {
            LeftUpPoint.X = x;
            LeftUpPoint.Y = y;
        }

        public Rectangle() { }

        public void SetWidth(Rectangle rectangle)
        {
            rectangle.Width = (int)Math.Sqrt(Math.Pow((rectangle.LeftDownPoint.X - rectangle.RightDownPoint.X), 2) + Math.Pow((rectangle.LeftDownPoint.Y - rectangle.RightDownPoint.Y), 2));
        }

        public void SetHeight(Rectangle rectangle)
        {
            rectangle.Height = (int)Math.Sqrt(Math.Pow((rectangle.LeftDownPoint.X - rectangle.LeftUpPoint.X), 2) + Math.Pow((rectangle.LeftDownPoint.Y - rectangle.LeftUpPoint.Y), 2));
        }
    }
}
