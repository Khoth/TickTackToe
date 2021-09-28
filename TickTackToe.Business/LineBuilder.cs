using System.Collections.Generic;
using TickTackToe.Business.LineBuildingStrategy;
using TickTackToe.Model;

namespace TickTackToe.Business
{
	internal sealed class LineBuilder
	{
		private readonly ILineBuildingStrategy _lineBuildingStrategy;

		public LineBuilder(ILineBuildingStrategy lineBuildingStrategy)
		{
			_lineBuildingStrategy = lineBuildingStrategy;
		}

		public Point[] Build(Board board, Point from)
		{
			var result = new List<Point>();
			var next = new Point(from.X, from.Y);

			while (next != null)
			{
				result.Add(next);

				next = _lineBuildingStrategy.FindNext(board, next);

				if (next != null &&
					board[next.X, next.Y].Sign != board[from.X, from.Y].Sign)
				{
					next = null;
				}
			};

			return result.ToArray();
		}
	}
}
