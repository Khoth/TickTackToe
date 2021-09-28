using TickTackToe.Model;

namespace TickTackToe.Business.LineBuildingStrategy.Implementation
{
	internal sealed class VerticalLineBuildingStrategy : ILineBuildingStrategy
	{
		public Point FindNext(Board board, Point from)
		{
			if (from.X >= board.Width ||
				from.Y >= board.Height - 1)
			{
				return null;
			}

			return new Point(from.X, from.Y + 1);
		}
	}
}
