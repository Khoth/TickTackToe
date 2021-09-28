using NUnit.Framework;
using System;
using System.Collections.Generic;
using TickTackToe.Business.LineBuildingStrategy;
using TickTackToe.Business.LineBuildingStrategy.Implementation;
using TickTackToe.Model;
using TickTackToe.Model.Enum;

namespace TickTackToe.Business.Test
{
	internal sealed class LineBuilderTest
	{
		[Test]
		[TestCaseSource(nameof(GetTestCases))]
		public void Build_WithCorrectParams_Success(
			Board board, ILineBuildingStrategy lineBuildingStrategy, Point startPoint, Point[] expectedLine)
		{
			var lineBuilder = new LineBuilder(lineBuildingStrategy);
			Point[] line = null;

			void BuildLine()
			{
				line = lineBuilder.Build(board, startPoint);
			}

			Assert.DoesNotThrow(BuildLine);
			CollectionAssert.AreEqual(expectedLine, line);
		}

		private static IEnumerable<TestCaseData> GetTestCases()
		{
			var verticalLineBuildingStrategy = new VerticalLineBuildingStrategy();
			var horizontalLineBuildingStrategy = new HorizontalLineBuildingStrategy();
			var diagonalLineBuildingStrategy = new DiagonalLineBuildingStrategy();
			var diagonal2LineBuildingStrategy = new Diagonal2LineBuildingStrategy();

			//	X  -  -
			//  X  0  -
			//  X  -  0
			var board1 = new Board(3, 3);

			board1[0, 0].Sign = SignType.Cross;
			board1[0, 1].Sign = SignType.Cross;
			board1[0, 2].Sign = SignType.Cross;
			board1[1, 1].Sign = SignType.Zero;
			board1[2, 2].Sign = SignType.Zero;

			yield return new TestCaseData(
				board1,
				horizontalLineBuildingStrategy,
				new Point(1, 0),
				Array.Empty<Point>());

			yield return new TestCaseData(
				board1,
				verticalLineBuildingStrategy,
				new Point(0, 0),
				new[]
				{
					new Point(0, 0),
					new Point(0, 1),
					new Point(0, 2)
				});

			yield return new TestCaseData(
				board1,
				horizontalLineBuildingStrategy,
				new Point(0, 0),
				new[]
				{
					new Point(0,0)
				});

			yield return new TestCaseData(
				board1,
				diagonalLineBuildingStrategy,
				new Point(1, 1),
				new[]
				{
					new Point(1, 1),
					new Point(2, 2)
				});

			yield return new TestCaseData(
				board1,
				diagonal2LineBuildingStrategy,
				new Point(0, 2),
				new[]
				{
					new Point(0, 2)
				});
		}
	}
}
