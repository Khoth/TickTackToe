using System;

namespace TickTackToe.Code.Extensions
{
	public static class ArrayExtensions
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
	}
}
