using TickTackToe.Code.Enums;

namespace TickTackToe.Code.Entities.Players
{
	public class AiPlayer : Player
	{
		public override bool IsControllable => false;

		public AiPlayer(SignType signType)
			: base(signType)
		{
		}

		public override void Move(Cell[,] cells, Cell cell)
		{
			for (var y = 0; y < cells.GetLength(1); y++)
			{
				for (var x = 0; x < cells.GetLength(0); x++)
				{
					if (cells[x,y].Sign == null)
					{
						cells[x, y].SetSign(SignType);
						return;
					}
				}
			}
		}
	}
}
