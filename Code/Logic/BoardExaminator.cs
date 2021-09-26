using Microsoft.Xna.Framework;
using System.Linq;
using TickTackToe.Code.Entities;
using TickTackToe.Code.Logic.CellIterators;

namespace TickTackToe.Code.Logic
{
	public class BoardExaminator
	{
		private readonly ICellIterator[] _cellIterators;
		private readonly LineBuilder[] _lineBuilders;

		public BoardExaminator()
		{
			_cellIterators = new ICellIterator[]
			{
				new HorizontalCellIterator(),
				new VerticalCellIterator(),
				new DiagonalCellIterator()
			};

			_lineBuilders = _cellIterators
				.Select(x => new LineBuilder(x))
				.ToArray();
		}

		public SignType Examine(Cell[,] cells, int lineMinLength)
		{
			for (var y = 0; y < cells.GetLength(1); y++)
			{
				for (var x = 0; x < cells.GetLength(0); x++)
				{
					if (cells[x, y].Sign == null) continue;

					foreach (var lineBuilder in _lineBuilders)
					{
						var line = lineBuilder.Build(cells, new Point(x, y));

						if (line.Length >= lineMinLength)
						{
							return cells[x, y].Sign.Type;
						}
					}
				}
			}

			return SignType.None;
		}
	}
}
