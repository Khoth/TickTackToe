using TickTackToe.Model.Enum;

namespace TickTackToe.Model
{
	public sealed class Cell
	{
		public SignType Sign { get; set; }

		public Cell()
		{
			Sign = SignType.None;
		}
	}
}
