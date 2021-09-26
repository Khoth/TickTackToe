﻿using Microsoft.Xna.Framework;
using TickTackToe.Code.Entities;

namespace TickTackToe.Code.Logic.CellIterators
{
	public class VerticalCellIterator : ICellIterator
	{
		public Point? GetNext(Cell[,] cells, Point from)
		{
			if (cells == null) return null;
			if (from.X >= cells.GetLength(0)) return null;
			if (from.Y >= cells.GetLength(1) - 1) return null;

			return new Point(from.X, from.Y + 1);
		}
	}
}