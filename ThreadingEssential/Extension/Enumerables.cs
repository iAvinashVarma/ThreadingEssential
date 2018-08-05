using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingEssential.Extension
{
	public static class Enumerables
	{
		public static void ForEach<T>(this IEnumerable<T> @enumeration, Action<T> action)
		{
			foreach (var item in @enumeration)
				action.Invoke(item);
		}
	}
}
