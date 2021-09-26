using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TickTackToe.Code.Entities;
using TickTackToe.Code.Handlers;

namespace TickTackToe
{
	internal class TickTackToeGame : Game
	{
		private readonly MouseInputHandler _mouseInputHandler;

		private SpriteBatch _spriteBatch;
		private Board _board;

		public TickTackToeGame()
		{
			_ = new GraphicsDeviceManager(this) { HardwareModeSwitch = false };
			
			IsMouseVisible = true;
			
			_mouseInputHandler = new MouseInputHandler();
			Services.AddService(_mouseInputHandler);

			_board = new Board(Services, 3, 3);
		}

		protected override void Initialize()
		{
			_board.Initialize();
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			_board.LoadContents();
		}

		protected override void Update(GameTime gameTime)
		{
			_mouseInputHandler.Update(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();
			_board.Draw(gameTime, _spriteBatch);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
