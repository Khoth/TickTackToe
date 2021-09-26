using Microsoft.Xna.Framework;
using TickTackToe.Code.Entities;

namespace TickTackToe.Code.Logic.CellIterators
{
	public class Diagonal2CellIterator : ICellIterator
	{
		public Point? GetNext(Cell[,] cells, Point from)
		{
			if (cells == null) return null;
			if (from.X >= cells.GetLength(0) - 1) return null;
			if (from.Y < 1) return null;

			return new Point(from.X + 1, from.Y - 1);
		}
	}
}
