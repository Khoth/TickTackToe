using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TickTackToe.Code.Entities;

namespace TickTackToe
{
	internal class TickTackToeGame : Game
	{
		private readonly GraphicsDeviceManager _graphicsDeviceManager;

		private Board _board;

		public TickTackToeGame()
		{
			_graphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				HardwareModeSwitch = false,
			};

			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			base.Initialize();

			_board = new Board(this);
		}

		protected override void LoadContent()
		{
			Services.AddService(new SpriteBatch(GraphicsDevice));
		}

		protected override void Update(GameTime gameTime)
		{
			_board.Update(gameTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_board.Draw(gameTime);
			base.Draw(gameTime);
		}
	}
}
