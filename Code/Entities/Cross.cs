using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TickTackToe.Code.Entities
{
	public class Cross : Sign
	{
		public override SignTypes Type => SignTypes.Cross;

		public Cross(Game game, Rectangle bounds)
			: base(game, bounds)
		{
			_texture = game.Content.Load<Texture2D>("cross");
		}
	}
}
