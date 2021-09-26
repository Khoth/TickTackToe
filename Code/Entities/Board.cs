using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TickTackToe.Code.Extensions;
using TickTackToe.Code.Handlers;
using TickTackToe.Code.Logic;

namespace TickTackToe.Code.Entities
{
	public class Board
	{
		// TODO transfer to another entities
		private int _cellSide = 102, _turn = 1;
		private SignType _winner = SignType.None; 

		private readonly GameServiceContainer _serviceContainer;
		private readonly MouseInputHandler _mouseInputHandler;
		private readonly Cell[,] _cells;
		private readonly BoardExaminator _boardExaminator;

		private int RowsCount => _cells.GetLength(0);

		private int ColumnsCount => _cells.GetLength(1);

		public Board(GameServiceContainer serviceContainer, int rowsCount, int columnsCount)
		{
			_serviceContainer = serviceContainer;
			_cells = new Cell[rowsCount, columnsCount];
			_mouseInputHandler = _serviceContainer.GetService<MouseInputHandler>();
			_mouseInputHandler.MouseLeftButtonClicked += MouseInputHandler_MouseLeftButtonClicked;
			_boardExaminator = new BoardExaminator();
		}

		~Board()
		{
			_mouseInputHandler.MouseLeftButtonClicked -= MouseInputHandler_MouseLeftButtonClicked;
		}

		public void Initialize()
		{
			var graphicsDeviceService = _serviceContainer.GetService<IGraphicsDeviceService>();
			var viewport = graphicsDeviceService.GraphicsDevice.Viewport;

			var startPoint = new Point(
				(viewport.Width - RowsCount * _cellSide) / 2,
				(viewport.Height - ColumnsCount * _cellSide) / 2);

			for (var y = 0; y < ColumnsCount; y++)
			{
				for (var x = 0; x < RowsCount; x++)
				{
					var cellBounds = new Rectangle(
						startPoint.X + _cellSide * x,
						startPoint.Y + _cellSide * y,
						_cellSide,
						_cellSide);

					_cells[x, y] = new Cell(_serviceContainer, cellBounds);
				}
			}
		}

		public void LoadContents()
		{
			_cells.ForEach(x => x.LoadContent());
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			_cells.ForEach(x => x.Draw(gameTime, spriteBatch));
		}

		private void MouseInputHandler_MouseLeftButtonClicked(object sender, Point e)
		{
			var cell = FindCell(e);

			if (cell != null && cell.Sign == null && _winner == SignType.None)
			{
				cell.SetSign(_turn % 2 == 0 ? SignType.Cross : SignType.Zero);
				_winner = _boardExaminator.Examine(_cells, 3); // TODO
				_turn++;
			}
		}

		private Cell FindCell(Point point)
		{
			for (var y = 0; y < ColumnsCount; y++)
			{
				for (var x = 0; x < RowsCount; x++)
				{
					if (_cells[x, y].Contains(point))
					{
						return _cells[x, y];
					}
				}
			}

			return null;
		}
	}
}
