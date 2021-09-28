using System;
using TickTackToe.Business.LineBuildingStrategy.Implementation;
using TickTackToe.Model;
using TickTackToe.Model.Enum;

namespace TickTackToe.Business
{
	public sealed class BoardExaminator
	{
		private readonly LineBuilder[] _lineBuilders;

		public BoardExaminator()
		{
			_lineBuilders = new[]
			{
				new LineBuilder(new HorizontalLineBuildingStrategy()),
				new LineBuilder(new VerticalLineBuildingStrategy()),
				new LineBuilder(new DiagonalLineBuildingStrategy()),
				new LineBuilder(new Diagonal2LineBuildingStrategy())
			};
		}

		public Point[] Examine(Board board, int lineMinLength)
		{
			for (var y = 0; y < board.Height; y++)
			{
				for (var x = 0; x < board.Width; x++)
				{
					if (board[x, y].Sign == SignType.None) continue;

					foreach (var lineBuilder in _lineBuilders)
					{
						var line = lineBuilder.Build(board, new Point(x, y));

						if (line.Length >= lineMinLength)
						{
							return line;
						}
					}
				}
			}

			return Array.Empty<Point>();
		}
	}
}
