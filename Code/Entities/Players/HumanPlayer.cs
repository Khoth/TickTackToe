namespace TickTackToe.Code.Entities.Players
{
	public class HumanPlayer : Player
	{
		public override bool IsControllable => true;

		public HumanPlayer(SignType signType)
			: base(signType)
		{
		}

		public override void Move(Cell[,] cells, Cell cell)
		{
			cell.SetSign(SignType);
		}
	}
}
