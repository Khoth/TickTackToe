using NUnit.Framework;
using TickTackToe.Business.LineBuildingStrategy;
using TickTackToe.Model;

namespace TickTackToe.Business.Test.LineBuildingStrategy
{
	internal abstract class LineBuildingStrategyTestBase
	{
		protected readonly ILineBuildingStrategy _lineBuildingStrategy;
		
		protected Board Board { get; private set; }

		protected LineBuildingStrategyTestBase(ILineBuildingStrategy lineBuildingStrategy)
		{
			_lineBuildingStrategy = lineBuildingStrategy;
		}

		[SetUp]
		public void Setup()
		{
			Board = new Board(3, 3);
		}

		public virtual void Find_WithCorrectParams_Success(int startX, int staryY, int expectedX, int expectedY)
		{
			Point next = null;

			void GetNext()
			{
				next = _lineBuildingStrategy.FindNext(Board, new Point(startX, staryY));
			}

			Assert.DoesNotThrow(GetNext);
			Assert.NotNull(next);
			Assert.AreEqual(expectedX, next.X);
			Assert.AreEqual(expectedY, next.Y);
		}

		public virtual void FindEoF_WithCorrectParams_Success(int startX, int startY)
		{
			Point next = null;

			void GetNext()
			{
				next = _lineBuildingStrategy.FindNext(Board, new Point(startX, startY));
			}

			Assert.DoesNotThrow(GetNext);
			Assert.IsNull(next);
		}
	}
}
