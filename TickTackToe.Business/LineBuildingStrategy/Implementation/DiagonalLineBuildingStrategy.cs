using TickTackToe.Model;

namespace TickTackToe.Business.LineBuildingStrategy.Implementation
{
	internal class DiagonalLineBuildingStrategy : ILineBuildingStrategy
	{
		public Point FindNext(Board board, Point from)
		{
			if (from.X >= board.Width - 1 ||
				from.Y >= board.Height - 1)
			{
				return null;
			}

			return new Point(from.X + 1, from.Y + 1);
		}
	}
}
