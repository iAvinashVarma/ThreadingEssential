using System;
using System.Collections.Generic;

namespace LearnInfra.Extension
{
	public static class Enumerations
	{
		public static Dictionary<int, string> GetDictionary<T>(this T @type)
		{
			if (typeof(T).IsEnum)
			{
				var dictionary = new Dictionary<int, string>();
				var values = Enum.GetValues(typeof(T));
				foreach (var value in Enum.GetValues(typeof(T)))
				{
					dictionary.Add((int)value, $"{value}");
				}
				return dictionary;
			}
			else
			{
				return null;
			}
		}
	}
}