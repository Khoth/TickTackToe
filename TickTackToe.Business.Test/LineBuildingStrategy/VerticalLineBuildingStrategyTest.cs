using NUnit.Framework;
using TickTackToe.Business.LineBuildingStrategy.Implementation;

namespace TickTackToe.Business.Test.LineBuildingStrategy
{
	internal sealed class VerticalLineBuildingStrategyTest : LineBuildingStrategyTestBase
	{
		public VerticalLineBuildingStrategyTest()
			: base(new VerticalLineBuildingStrategy())
		{
		}

		[TestCase(1, 1, 1, 2)]
		public override void Find_WithCorrectParams_Success(int startX, int staryY, int expectedX, int expectedY)
		{
			base.Find_WithCorrectParams_Success(startX, staryY, expectedX, expectedY);
		}

		[TestCase(0, 2)]
		public override void FindEoF_WithCorrectParams_Success(int startX, int startY)
		{
			base.FindEoF_WithCorrectParams_Success(startX, startY);
		}
	}
}
