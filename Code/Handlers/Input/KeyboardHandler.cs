using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TickTackToe.Code.Handlers.Input
{
	internal sealed class KeyboardHandler : IInputHandler
	{
		private readonly IReadOnlyDictionary<Keys, Action> _keyHandleRules;
		private Keys[] _previousPressedKeys;

		public KeyboardHandler(IReadOnlyDictionary<Keys, Action> keyHandleRules)
		{
			_keyHandleRules = keyHandleRules;
			_previousPressedKeys = Keyboard.GetState().GetPressedKeys();
		}

		public void Handle()
		{
			var currenlyPressedKeys = Keyboard.GetState().GetPressedKeys();

			Array.ForEach(currenlyPressedKeys, key =>
			{
				if (_previousPressedKeys.Contains(key)) return;
				if (!_keyHandleRules.ContainsKey(key)) return;

				_keyHandleRules[key].Invoke();
			});

			_previousPressedKeys = currenlyPressedKeys;
		}
	}
}
