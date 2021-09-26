using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TickTackToe.Code.Entities;

namespace TickTackToe.Code.Logic
{
	public class LineBuilder
	{
		private readonly ILineBuildingStrategy _iterator;

		public LineBuilder(ILineBuildingStrategy iterator)
		{
			_iterator = iterator;
		}

		public Point[] Build(Cell[,] cells, Point from)
		{
			var result = new List<Point>();

			if (from.X >= cells.GetLength(0) ||
				from.Y >= cells.GetLength(1))
			{
				throw new ArgumentOutOfRangeException(nameof(from));
			}

			var singType = cells[from.X, from.Y].Sign.Type;
			Point? next = new Point(from.X, from.Y);

			while (next.HasValue)
			{
				result.Add(next.Value);

				next = _iterator.GetNext(cells, next.Value);

				if (next.HasValue &&
					cells[next.Value.X, next.Value.Y].Sign?.Type != singType)
				{
					next = null;
				}
			};

			return result.ToArray();
		}
	}
}
