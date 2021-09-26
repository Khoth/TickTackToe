using Microsoft.Xna.Framework;
using TickTackToe.Code.Entities;

namespace TickTackToe.Code.Logic
{
	public interface ILineBuildingStrategy
	{
		Point? GetNext(Cell[,] cells, Point from);
	}
}
