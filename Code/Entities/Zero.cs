using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TickTackToe.Code.Entities
{
	public class Zero : Sign
	{
		public override SignTypes Type => SignTypes.Zero;

		public Zero(Game game, Rectangle bounds)
			: base(game, bounds)
		{
			_texture = game.Content.Load<Texture2D>("zero");
		}
	}
}
