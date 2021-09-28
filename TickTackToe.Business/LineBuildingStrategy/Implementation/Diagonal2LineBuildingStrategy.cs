using TickTackToe.Model;

namespace TickTackToe.Business.LineBuildingStrategy.Implementation
{
	internal sealed class Diagonal2LineBuildingStrategy : ILineBuildingStrategy
	{
		public Point FindNext(Board board, Point from)
		{
			if (from.X >= board.Width - 1 ||
				from.Y < 1)
			{
				return null;
			}

			return new Point(from.X + 1, from.Y - 1);
		}
	}
}
