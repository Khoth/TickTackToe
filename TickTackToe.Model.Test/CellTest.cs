using NUnit.Framework;
using TickTackToe.Model.Enum;

namespace TickTackToe.Model.Test
{
	internal sealed class CellTest
	{
		[Test]
		public void Create_WithCorrectParams_Success()
		{
			Cell cell = null;

			void CreateCell()
			{
				cell = new Cell();
			}

			Assert.DoesNotThrow(CreateCell);
			Assert.AreEqual(SignType.None, cell.Sign);
		}
	}
}
