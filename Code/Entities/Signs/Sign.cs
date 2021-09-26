using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TickTackToe.Code.Entities.Base;

namespace TickTackToe.Code.Entities.Signs
{
	public abstract class Sign : Sprite
	{
		protected Texture2D _texture;

		protected Sign(GameServiceContainer serviceContainer, Rectangle bounds)
			: base(serviceContainer, bounds)
		{
		}

		public abstract SignType Type { get; }

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _bounds, Color.White);
		}
	}
}
