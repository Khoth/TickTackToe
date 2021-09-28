using NUnit.Framework;

namespace TickTackToe.Model.Test
{
	internal sealed class PointTest
	{
		[TestCase(0, 0)]
		[TestCase(1, 0)]
		[TestCase(0, 1)]
		[TestCase(-1, 0)]
		[TestCase(0, -1)]
		public void Create_WithCorrectParams_Success(int x, int y)
		{
			Point point = null;

			void CreatePoint()
			{
				point = new Point(x, y);
			}

			Assert.DoesNotThrow(CreatePoint);
			Assert.AreEqual(x, point.X);
			Assert.AreEqual(y, point.Y);
		}
	}
}
