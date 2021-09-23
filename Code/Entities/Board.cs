using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TickTackToe.Code.Entities
{
	public class Board : IDrawable, IUpdateable
	{
		private const int CellSide = 102;
		private const int RowsCount = 3;
		private const int ColumnsCount = 3;

		private readonly SpriteBatch _spriteBatch;
		private readonly Cell[,] _cells;

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

			for (var y = 0; y < ColumnsCount; y++)
			{
				for (var x = 0; x < RowsCount; x++)
				{
					var cellPosition = new Rectangle(
						startPoint.X + CellSide * x,
						startPoint.Y + CellSide * y,
						CellSide,
						CellSide);

					_cells[x, y] = new Cell(game, cellPosition);
				}
			}
		}

		public void Draw(GameTime gameTime)
		{
			ForEachCell(cell => cell.Draw(gameTime));
		}

		public void Update(GameTime gameTime)
		{
			ForEachCell(cell => cell.Update(gameTime));
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
