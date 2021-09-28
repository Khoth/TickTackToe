using NUnit.Framework;
using TickTackToe.Business.LineBuildingStrategy.Implementation;

namespace TickTackToe.Business.Test.LineBuildingStrategy
{
	internal sealed class Diagonal2LineBuildingStrategyTest : LineBuildingStrategyTestBase
	{
		public Diagonal2LineBuildingStrategyTest()
			: base(new Diagonal2LineBuildingStrategy())
		{
		}

		[TestCase(1, 1, 2, 0)]
		public override void Find_WithCorrectParams_Success(int startX, int staryY, int expectedX, int expectedY)
		{
			base.Find_WithCorrectParams_Success(startX, staryY, expectedX, expectedY);
		}

		[TestCase(0, 0)]
		public override void FindEoF_WithCorrectParams_Success(int startX, int startY)
		{
			base.FindEoF_WithCorrectParams_Success(startX, startY);
		}
	}
}
