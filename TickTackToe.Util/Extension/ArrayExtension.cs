using System;

namespace TickTackToe.Util.Extension
{
	public static class ArrayExtension
	{
		public static void ForEach<T>(this T[,] array, Action<T> action)
		{
			for (var y = 0; y < array.GetLength(1); y++)
			{
				for (var x = 0; x < array.GetLength(0); x++)
				{
					action(array[x, y]);
				}
			}
		}

		public static void ForEach<T>(this T[,] array, Func<T> func)
		{
			for (var y = 0; y < array.GetLength(1); y++)
			{
				for (var x = 0; x < array.GetLength(0); x++)
				{
					array[x, y] = func();
				}
			}
		}
	}
}
