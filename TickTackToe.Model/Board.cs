using Dawn;
using TickTackToe.Util.Extension;

namespace TickTackToe.Model
{
	public sealed class Board
	{
		private readonly Cell[,] _cells;

		public int Width => _cells.GetLength(0);

		public int Height => _cells.GetLength(1);

		public Cell this[int x, int y] => _cells[x, y];

		public Board(int width, int height)
		{
			Guard.Argument(width).Positive();
			Guard.Argument(height).Positive();

			_cells = new Cell[width, height];
			_cells.ForEach(() => new Cell());
		}
	}
}
