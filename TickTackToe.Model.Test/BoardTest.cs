using NUnit.Framework;
using System;

namespace TickTackToe.Model.Test
{
	internal sealed class BoardTest
	{
		[TestCase(1, 1)]
		[TestCase(3, 3)]
		[TestCase(1, 3)]
		[TestCase(3, 1)]
		public void Create_WithCorrectParams_Success(int width, int height)
		{
			Board board = null;

			void CreateBoard()
			{
				board = new Board(width, height);
			}

			Assert.DoesNotThrow(CreateBoard);
			Assert.AreEqual(width, board.Width);
			Assert.AreEqual(height, board.Height);

			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < width; x++)
				{
					Assert.NotNull(board[x, y]);
				}
			}
		}

		[TestCase(1, 0)]
		[TestCase(0, 1)]
		[TestCase(-1, 1)]
		[TestCase(1, -1)]
		public void Create_WithCorrectParams_Fail(int width, int height)
		{
			void CreateBoard()
			{
				_ = new Board(width, height);
			}

			Assert.Throws(Is.InstanceOf<Exception>(), CreateBoard);
		}
	}
}