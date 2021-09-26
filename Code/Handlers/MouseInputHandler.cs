using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace TickTackToe.Code.Handlers
{
	public class MouseInputHandler
	{
		public event EventHandler<Point> MouseLeftButtonClicked;

		public void Update(GameTime gameTime)
		{
			var mouseState = Mouse.GetState();

			if (mouseState.LeftButton == ButtonState.Pressed)
			{
				MouseLeftButtonClicked?.Invoke(this, mouseState.Position);
			}
		}
	}
}
