using System;
using System.Collections.Generic;

namespace ThreadingEssential.Extension
{
	public static class Enumerables
	{
		public static void For(int fromInclusive, int toExclusive, Action<int> action)
		{
			for (int i = fromInclusive; i < toExclusive; i++)
			{
				action.Invoke(i);
			}
		}

		public static void ForEach<T>(this IEnumerable<T> @enumeration, Action<T> action)
		{
			foreach (var item in @enumeration)
				action.Invoke(item);
		}
	}
}