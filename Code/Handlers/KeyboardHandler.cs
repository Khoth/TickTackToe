using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TickTackToe.Code.Handlers
{
	internal sealed class KeyboardHandler : IDisposable
	{
		private readonly Game _game;
		private readonly IReadOnlyDictionary<Keys, Action> _keyHandleRules;
		private readonly List<Keys> _pressedKeys = new(0);

		public KeyboardHandler(
			Game game,
			IReadOnlyDictionary<Keys, Action> keyHandleRules)
		{
			_game = game;
			_keyHandleRules = keyHandleRules;

			_pressedKeys = Keyboard.GetState().GetPressedKeys().ToList();

			_game.Window.KeyDown += HandleKeyDown;
			_game.Window.KeyUp += HandleKeyUp;
		}

		public void Dispose()
		{
			_game.Window.KeyDown -= HandleKeyDown;
			_game.Window.KeyUp -= HandleKeyUp;
		}

		private void HandleKeyDown(object sender, InputKeyEventArgs e)
		{
			if (!_pressedKeys.Contains(e.Key))
			{
				_pressedKeys.Add(e.Key);

				if (_keyHandleRules.ContainsKey(e.Key))
				{
					_keyHandleRules[e.Key].Invoke();
				}
			}
		}

		private void HandleKeyUp(object sender, InputKeyEventArgs e)
		{
			_pressedKeys.Remove(e.Key);
		}
	}
}
