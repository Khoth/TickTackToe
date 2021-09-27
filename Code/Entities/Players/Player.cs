using TickTackToe.Code.Entities.Base;

namespace TickTackToe.Code.Entities.Players
{
	public abstract class Player : IControllable
	{
		public SignType SignType { get; }

		public abstract bool IsControllable { get; }

		protected Player(SignType signType)
		{
			SignType = signType;
		}

		public abstract void Move(Cell[,] cells, Cell cell);
	}
}
