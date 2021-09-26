using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TickTackToe.Code.Entities.Signs
{
	public class Zero : Sign
	{
		public Zero(GameServiceContainer serviceContainer, Rectangle bounds)
			: base(serviceContainer, bounds)
		{
		}

		public override SignTypes Type => SignTypes.Zero;

		public override void LoadContent()
		{
			_texture = _contentManager.Load<Texture2D>("zero");
		}
	}
}
