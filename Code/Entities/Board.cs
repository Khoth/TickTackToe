using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TickTackToe.Code.Entities
{
	public class Board : IDrawable, IUpdateable
	{
		private const int CellSide = 102;
		private const int RowsCount = 3;
		private const int ColumnsCount = 3;

		private int _turn = 1;

		private readonly SpriteBatch _spriteBatch;
		private readonly Cell[,] _cells;
		private readonly Rectangle _boardBounds;

		public int DrawOrder => 0;
		public int UpdateOrder => 0;
		public bool Visible => true;
		public bool Enabled => true;

		public event EventHandler<EventArgs> DrawOrderChanged;
		public event EventHandler<EventArgs> VisibleChanged;
		public event EventHandler<EventArgs> EnabledChanged;
		public event EventHandler<EventArgs> UpdateOrderChanged;

		public Board(Game game)
		{
			_spriteBatch = game.Services.GetService<SpriteBatch>();
			_cells = new Cell[RowsCount, ColumnsCount];

			var viewport = _spriteBatch.GraphicsDevice.Viewport;

			var startPoint = new Point(
				(viewport.Width - RowsCount * CellSide) / 2,
				(viewport.Height - ColumnsCount * CellSide) / 2);

			_boardBounds = new Rectangle(startPoint.X, startPoint.Y,
				RowsCount * CellSide, ColumnsCount * CellSide);

			for (var y = 0; y < ColumnsCount; y++)
			{
				for (var x = 0; x < RowsCount; x++)
				{
					var cellBounds = new Rectangle(
						startPoint.X + CellSide * x,
						startPoint.Y + CellSide * y,
						CellSide,
						CellSide);

					_cells[x, y] = new Cell(game, cellBounds);
				}
			}
		}

		public void Draw(GameTime gameTime)
		{
			ForEachCell(cell => cell.Draw(gameTime));
		}

		public void Update(GameTime gameTime)
		{
			var mouseState = Mouse.GetState();

			if (mouseState.LeftButton == ButtonState.Pressed)
			{
				HandleClick(mouseState.Position);
			}
		}

		private void HandleClick(Point point)
		{
			if (!_boardBounds.Contains(point)) return;

			var cell = FindCell(point);

			if (cell != null && cell.SignType == SignTypes.None)
			{
				cell.SetSign(_turn % 2 == 0 ? SignTypes.Cross : SignTypes.Zero);
				_turn++;
			}
		}

		private Cell FindCell(Point point)
		{
			for (var y = 0; y < ColumnsCount; y++)
			{
				for (var x = 0; x < RowsCount; x++)
				{
					if (_cells[x, y].Contanis(point))
					{
						return _cells[x, y];
					}
				}
			}

			return null;
		}

		private void ForEachCell(Action<Cell> action)
		{
			for (var y = 0; y < ColumnsCount; y++)
			{
				for (var x = 0; x < RowsCount; x++)
				{
					action(_cells[x, y]);
				}
			}
		}
	}
}
