using TickTackToe.Model;

namespace TickTackToe.Business.LineBuildingStrategy
{
	internal interface ILineBuildingStrategy
	{
		Point FindNext(Board board, Point from);
	}
}
