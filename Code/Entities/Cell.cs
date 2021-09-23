using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TickTackToe.Code.Entities
{
	public class Cell : IDrawable, IUpdateable
	{
		private readonly SpriteBatch _spriteBatch;
		private readonly Texture2D _texture;
		private readonly Rectangle _rectangle;

		private bool _enabled = true;

		public int DrawOrder => 0;
		public bool Visible => true;
		public bool Enabled => _enabled;
		public int UpdateOrder => 0;

		public event EventHandler<EventArgs> DrawOrderChanged;
		public event EventHandler<EventArgs> VisibleChanged;
		public event EventHandler<EventArgs> EnabledChanged;
		public event EventHandler<EventArgs> UpdateOrderChanged;

		private Color _tempColor = Color.White;

		public Cell(Game game, Rectangle rectangle)
		{
			_spriteBatch = game.Services.GetService<SpriteBatch>();
			_texture = game.Content.Load<Texture2D>("cell");
			_rectangle = rectangle;
		}

		public void Draw(GameTime gameTime)
		{
			_spriteBatch.Begin();
			_spriteBatch.Draw(_texture, _rectangle, _tempColor);
			_spriteBatch.End();
		}

		public void Update(GameTime gameTime)
		{
			if (!Enabled) return;

			var mouseState = Mouse.GetState();

			if (mouseState.LeftButton == ButtonState.Pressed &&
				_rectangle.Contains(mouseState.Position))
			{
				_tempColor = Color.Red;
				_enabled = false;
			}
		}
	}
}
