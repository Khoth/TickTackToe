using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TickTackToe.Code.Entities
{
	public class Board : IDrawable
	{
		private readonly SpriteBatch _spriteBatch;
		private readonly Texture2D _texture;

		private const int _width = 300;
		private const int _heigth = 300;

		public int DrawOrder => 0;
		public bool Visible => true;

		public event EventHandler<EventArgs> DrawOrderChanged;
		public event EventHandler<EventArgs> VisibleChanged;

		public Board(Game game)
		{
			_spriteBatch = game.Services.GetService<SpriteBatch>();
			_texture = game.Content.Load<Texture2D>("board");
		}

		public void Draw(GameTime gameTime)
		{
			var screenWidth = _spriteBatch.GraphicsDevice.Viewport.Width;
			var screenHeight = _spriteBatch.GraphicsDevice.Viewport.Height;

			_spriteBatch.Begin();
			_spriteBatch.Draw(_texture, new Rectangle((screenWidth - _width) / 2, (screenHeight - _heigth) / 2, _width, _heigth), Color.White);
			_spriteBatch.End();
		}
	}
}
