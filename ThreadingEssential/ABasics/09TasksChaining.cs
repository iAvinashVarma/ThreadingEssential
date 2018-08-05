﻿using System;
using System.Threading.Tasks;
using ThreadingEssential.Interface;

namespace ThreadingEssential.ABasics
{
	internal class TasksChaining : ILearner
	{
		public void Practice(string[] args)
		{
			var antecedent = Task.Run(() =>
			{
				Task.Delay(2000);
				return DateTime.Today.ToShortDateString();
			});
			var continuation = antecedent.ContinueWith(a =>
			{
				return $"Today is {antecedent.Result}";
			});
			Console.WriteLine("This will display before the result");
			Console.WriteLine(continuation.Result);
		}
	}
}