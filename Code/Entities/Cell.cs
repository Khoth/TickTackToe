using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TickTackToe.Code.Entities
{
	public class Cell : IDrawable
	{
		private readonly Game _game;
		private readonly SpriteBatch _spriteBatch;
		private readonly Texture2D _texture;
		private readonly Rectangle _bounds;
		private Sign _sign;

		public int DrawOrder => 0;
		
		public bool Visible => true;
		
		public bool Enabled => true;
		
		public int UpdateOrder => 0;

		public SignTypes SignType => _sign?.Type ?? SignTypes.None;

		public event EventHandler<EventArgs> DrawOrderChanged;
		public event EventHandler<EventArgs> VisibleChanged;

		public Cell(Game game, Rectangle bounds)
		{
			_game = game;
			_spriteBatch = game.Services.GetService<SpriteBatch>();
			_texture = game.Content.Load<Texture2D>("cell");
			_bounds = bounds;
		}

		public void Draw(GameTime gameTime)
		{
			_spriteBatch.Begin();
			_spriteBatch.Draw(_texture, _bounds, Color.White);
			_spriteBatch.End();

			_sign?.Draw(gameTime);
		}

		public bool Contanis(Point point)
		{
			return _bounds.Contains(point);
		}

		public void SetSign(SignTypes signType)
		{
			switch (signType)
			{
				case SignTypes.Cross:
					_sign = new Cross(_game, _bounds);
					break;

				case SignTypes.Zero:
					_sign = new Zero(_game, _bounds);
					break;
			}
		}
	}
}
