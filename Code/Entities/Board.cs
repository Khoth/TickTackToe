using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TickTackToe.Code.Entities.Players;
using TickTackToe.Code.Extensions;
using TickTackToe.Code.Handlers;
using TickTackToe.Code.Logic;

namespace TickTackToe.Code.Entities
{
	public class Board
	{
		// TODO refactor
		private const int LineLengthToWin = 3, _cellSide = 102;

		private readonly GameServiceContainer _serviceContainer;
		private readonly MouseInputHandler _mouseInputHandler;
		private readonly Cell[,] _cells;
		private readonly BoardExaminator _boardExaminator;
		private readonly Player[] _players;

		private int _activePlayerIndex;
		private int _winnerPlayerIndex;

		private int RowsCount => _cells.GetLength(0);

		private int ColumnsCount => _cells.GetLength(1);

		private Player ActivePlayer => _players[_activePlayerIndex];

		public Board(GameServiceContainer serviceContainer, int rowsCount, int columnsCount)
		{
			_serviceContainer = serviceContainer;
			_cells = new Cell[rowsCount, columnsCount];
			_mouseInputHandler = _serviceContainer.GetService<MouseInputHandler>();
			_mouseInputHandler.MouseLeftButtonClicked += MouseInputHandler_MouseLeftButtonClicked;
			_boardExaminator = new BoardExaminator();
			_players = new Player[]
			{
				new HumanPlayer(SignType.Cross),
				new AiPlayer(SignType.Zero)
			};
			_winnerPlayerIndex = -1;
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

			_activePlayerIndex = 0;

			if (!ActivePlayer.IsControllable)
			{
				MoveUncontrollablePlayer();
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
			if (!ActivePlayer.IsControllable || _winnerPlayerIndex >= 0)
			{
				return;
			}

			var cell = FindCell(e);

			if (cell != null && cell.Sign == null)
			{
				ActivePlayer.Move(_cells, cell);
				CheckIfWin();
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

		private void ToggleActivePlayer()
		{
			_activePlayerIndex = _activePlayerIndex == 1 ? 0 : 1;

			if (!ActivePlayer.IsControllable)
			{
				MoveUncontrollablePlayer();
			}
		}

		private void MoveUncontrollablePlayer()
		{
			if (_winnerPlayerIndex >= 0) return;

			ActivePlayer.Move(_cells, null);
			CheckIfWin();
		}

		private void CheckIfWin()
		{
			var line = _boardExaminator.Examine(_cells, LineLengthToWin);

			if (line.Length >= LineLengthToWin)
			{
				_winnerPlayerIndex = _activePlayerIndex;
			}
			else
			{
				ToggleActivePlayer();
			}
		}
	}
}
