using System;

namespace TickTackToe.Model
{
	public class Point : IEquatable<Point>
	{
		public int X { get; set; }

		public int Y { get; set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public bool Equals(Point other)
		{
			return
				other != null &&
				other.X == X &&
				other.Y == Y;
		}
	}
}
