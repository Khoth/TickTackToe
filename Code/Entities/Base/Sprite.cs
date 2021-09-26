using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TickTackToe.Code.Entities.Base
{
	public abstract class Sprite
	{
		protected readonly ContentManager _contentManager;
		protected readonly Rectangle _bounds;

		protected Sprite(GameServiceContainer serviceContainer, Rectangle bounds, string contentDirectory = "Content")
		{
			_contentManager = new ContentManager(serviceContainer, contentDirectory);
			_bounds = bounds;
		}

		public abstract void LoadContent();

		public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

		public virtual bool Contains(Point point) =>
			_bounds.Contains(point);
	}
}
