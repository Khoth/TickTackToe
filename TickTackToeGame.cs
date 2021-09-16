using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TickTackToe.Code.Handlers.Input;

namespace TickTackToe
{
	internal class TickTackToeGame : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private IInputHandler[] _inputHandlers;

		public TickTackToeGame()
		{
			_graphics = new GraphicsDeviceManager(this)
			{
				HardwareModeSwitch = false
			};

			_inputHandlers = new[]
			{
				new KeyboardHandler(new Dictionary<Keys, Action>
				{
					[Keys.Escape] = Exit,
					[Keys.F12] = _graphics.ToggleFullScreen
				})
			};

			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Update(GameTime gameTime)
		{
			Array.ForEach(_inputHandlers, inputHandler => inputHandler.Handle());

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			base.Draw(gameTime);
		}
	}
}
