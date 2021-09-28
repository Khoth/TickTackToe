using TickTackToe.Model;

namespace TickTackToe.Business.LineBuildingStrategy.Implementation
{
	internal sealed class HorizontalLineBuildingStrategy : ILineBuildingStrategy
	{
		public Point FindNext(Board board, Point from)
		{
			if (from.X >= board.Width - 1 ||
				from.Y >= board.Height)
			{
				return null;
			}

			return new Point(from.X + 1, from.Y);
		}
	}
}
