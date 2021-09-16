using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TickTackToe.Code.Entities;
using TickTackToe.Code.Handlers;

namespace TickTackToe
{
	internal class TickTackToeGame : Game
	{
		private readonly GraphicsDeviceManager _graphicsDeviceManager;
		private readonly KeyboardHandler _keyboardHandler;

		private Board _board;

		public TickTackToeGame()
		{
			_graphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				HardwareModeSwitch = false
			};

			_keyboardHandler = new KeyboardHandler(this, new Dictionary<Keys, Action>
			{
				[Keys.Escape] = Exit,
				[Keys.F12] = _graphicsDeviceManager.ToggleFullScreen
			});

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
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			_board.Draw(gameTime);

			base.Draw(gameTime);
		}

		protected override void Dispose(bool disposing)
		{
			_keyboardHandler.Dispose();

			base.Dispose(disposing);
		}
	}
}
