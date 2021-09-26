using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TickTackToe.Code.Entities.Signs
{
	public class Cross : Sign
	{
		public Cross(GameServiceContainer serviceContainer, Rectangle bounds)
			:base(serviceContainer, bounds)
		{
		}

		public override SignType Type => SignType.Cross;

		public override void LoadContent()
		{
			_texture = _contentManager.Load<Texture2D>("cross");
		}
	}
}
