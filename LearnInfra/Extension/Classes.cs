using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LearnInfra.Extension
{
	public static class Classes
	{
		public static IEnumerable<Type> GetTypesInNamespace<T>(Assembly assembly, string nameSpace)
		{
			var types = assembly.GetTypes()
					  .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal));
			return types;
		}
	}
}