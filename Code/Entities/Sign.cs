using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TickTackToe.Code.Entities
{
	public abstract class Sign : IDrawable
	{
		private readonly SpriteBatch _spriteBatch;
		private readonly Rectangle _bounds;
		protected Texture2D _texture;

		public int DrawOrder => 0;

		public bool Visible => true;

		public virtual SignTypes Type => throw new Exception();

		public event EventHandler<EventArgs> DrawOrderChanged;
		public event EventHandler<EventArgs> VisibleChanged;

		protected Sign(Game game, Rectangle bounds)
		{
			_spriteBatch = game.Services.GetService<SpriteBatch>();
			_bounds = bounds;
		}

		public void Draw(GameTime gameTime)
		{
			_spriteBatch.Begin();
			_spriteBatch.Draw(_texture, _bounds, Color.White);
			_spriteBatch.End();
		}
	}
}
