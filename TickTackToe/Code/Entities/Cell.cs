using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TickTackToe.Code.Entities.Base;
using TickTackToe.Code.Entities.Signs;
using TickTackToe.Code.Enums;

namespace TickTackToe.Code.Entities
{
	public class Cell : Sprite
	{
		private readonly GameServiceContainer _serviceContainer;

		private Texture2D _texture;
		private Sign _sign;

		public Sign Sign
		{
			get => _sign;
			private set => _sign = value;
		}

		public Cell(GameServiceContainer serviceContainer, Rectangle bounds)
			: base(serviceContainer, bounds)
		{
			_serviceContainer = serviceContainer;
		}

		public override void LoadContent()
		{
			_texture = _contentManager.Load<Texture2D>("cell");
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, _bounds, Color.White);
			Sign?.Draw(gameTime, spriteBatch);
		}

		public void SetSign(SignType signType)
		{
			switch (signType)
			{
				case SignType.Cross:
					_sign = new Cross(_serviceContainer, _bounds);
					break;

				case SignType.Zero:
					_sign = new Zero(_serviceContainer, _bounds);
					break;
			}

			_sign?.LoadContent();
		}
	}
}
