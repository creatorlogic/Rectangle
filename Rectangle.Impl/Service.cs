using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
    public static class Service
    {
        public static bool IsDuplicate(List<Point> points)
        {
            var duplicates = points.GroupBy(x => new { x.X, x.Y })
                                                .Where(c => c.Count() > 1)
                                                .Select(x => x.Key).ToList();
            if (duplicates.Any())
                return true;
            return false;
        }

        public static bool IsNull(List<Point> points)
        {
            if (points.Any())
                return false;
            return true;
        }

        public static bool IsAllowableCountPoints(List<Point> points)
        {
            if (points.Count < 2)
                return false;
            return true;
        }

        public static void SwapTwoDots(List<Point> points)
        {
            if (points[0].X == points[1].X)
            {
                var maxByY = points.OrderByDescending(p => p.Y).FirstOrDefault();
                var minByY = points.OrderBy(p => p.Y).FirstOrDefault();
                points[0] = minByY;
                points[1] = maxByY;
            }
            else
            {
                var maxByX = points.OrderByDescending(p => p.X).FirstOrDefault();
                var minByX = points.OrderBy(p => p.X).FirstOrDefault();
                points[0] = maxByX;
                points[1] = minByX;
            }
        }

        public static Rectangle FindRectangleByTwoDots(List<Point> points)
        {
            SwapTwoDots(points);

            int MinLeftDownUpX;
            int MinLeftRightDownY;
            int MaxLeftRightUpY;
            int MaxRightDownUpX;

            Rectangle rectangle = new Rectangle();

            if ((points[0].X >= points[1].X))
            {
                if (points[0].Y < points[1].Y)
                {
                    MaxLeftRightUpY = points[0].Y;
                    MinLeftDownUpX = points[0].X;
                    MaxRightDownUpX = points[0].X + 1;
                    MinLeftRightDownY = points[0].Y - 1;

                    SetCoordinateRectangle(rectangle, MinLeftDownUpX, MinLeftRightDownY, MaxRightDownUpX, MaxLeftRightUpY);

                    return rectangle;
                }

                else if (points[0].Y >= points[1].Y)
                {
                    MinLeftRightDownY = points[0].Y;
                    MinLeftDownUpX = points[0].X;
                    MaxLeftRightUpY = points[0].Y + 1;
                    MaxRightDownUpX = points[0].X + 1;

                    SetCoordinateRectangle(rectangle, MinLeftDownUpX, MinLeftRightDownY, MaxRightDownUpX, MaxLeftRightUpY);

                    return rectangle;
                }
            }
            throw new Exception("The input list is invalid");
        }

        public static void DeleteOutsidePoint(List<Point> points, int value)
        {
            try
            {
                Point outsidePoint = points.First(x => x.X == value);
                points.Remove(outsidePoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool CountDuplicate(List<Point> points, int value)
        {
            var duplicates = points.Where(x => x.X == value).ToList();

            if (duplicates.Count > 1)
                return true;

            return false;
        }

        public static bool IsSeveralMinX(List<Point> points)
        {
            int minX = points.Min(x => x.X);

            if (CountDuplicate(points, minX))
                return true;
            return false;
        }


        public static bool IsSeveralMaxX(List<Point> points)
        {
            int maxX = points.Max(x => x.X);

            if (CountDuplicate(points, maxX))
                return true;

            return false;
        }

        public static bool IsSeveralMinY(List<Point> points)
        {
            int minY = points.Min(y => y.Y);

            if (CountDuplicate(points, minY))
                return true;

            return false;
        }

        public static bool IsSeveralMaxY(List<Point> points)
        {
            int maxY = points.Max(y => y.Y);

            if (CountDuplicate(points, maxY))
                return true;

            return false;
        }

        public static Rectangle FindRectangleByManyDots(List<Point> points)
        {
            Rectangle rectangle = new Rectangle();
            if (!IsSeveralMinX(points))
            {
                int minX = points.Min(x => x.X);
                DeleteOutsidePoint(points, minX);
            }
            else if (!IsSeveralMaxX(points))
            {
                int maxX = points.Max(x => x.X);
                DeleteOutsidePoint(points, maxX);
            }
            else if (!IsSeveralMinY(points))
            {
                int minY = points.Min(y => y.Y);
                DeleteOutsidePoint(points, minY);
            }
            else if (!IsSeveralMaxY(points))
            {
                int maxY = points.Max(y => y.Y);
                DeleteOutsidePoint(points, maxY);
            }
            else
            {
                throw new Exception("The input list is invalid");
            }

            int MinLeftDownUpX = points.Min(x => x.X);
            int MinLeftRightDownY = points.Min(y => y.Y);
            int MaxRightDownUpX = points.Max(x => x.X);
            int MaxLeftRightUpY = points.Max(y => y.Y);

            SetCoordinateRectangle(rectangle, MinLeftDownUpX, MinLeftRightDownY, MaxRightDownUpX, MaxLeftRightUpY);

            return rectangle;
        }

        static void SetCoordinateRectangle(Rectangle rectangle, int MinLeftDownUpX, int MinLeftRightDownY, int MaxRightDownUpX, int MaxLeftRightUpY)
        {
            rectangle.SetLeftDownPoint(MinLeftDownUpX, MinLeftRightDownY);
            rectangle.SetRightDownPoint(MaxRightDownUpX, MinLeftRightDownY);
            rectangle.SetRightUpPoint(MaxRightDownUpX, MaxLeftRightUpY);
            rectangle.SetLeftUpPoint(MinLeftDownUpX, MaxLeftRightUpY);
            rectangle.SetWidth(rectangle);
            rectangle.SetHeight(rectangle);
        }

        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static Rectangle FindRectangle(List<Point> points)
        {
            Rectangle rectangle = new Rectangle();

            if (IsDuplicate(points) || IsNull(points) || !IsAllowableCountPoints(points))
                return rectangle;
            else if (points.Count == 2)
                return FindRectangleByTwoDots(points);
            else
                return FindRectangleByManyDots(points);
        }
    }
}
