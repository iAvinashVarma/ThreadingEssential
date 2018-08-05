using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingEssential.Extension;
using ThreadingEssential.Interface;

namespace ThreadingEssential.BAdvanced
{
	class ParallelVsNormal : ILearner
	{
		public void Practice(string[] args)
		{
			var path = Directory.GetCurrentDirectory();
			var picturesPath = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), @"Pictures\CodeOfConduct");
			 var files = Directory.GetFiles(picturesPath, "*.*", SearchOption.AllDirectories)
						.Where(s => s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)); ;
			var normalExecutionPath = Path.Combine(path, "NormalExecutionPath");
			var parallelExecutionPath = Path.Combine(path, "ParallelExecutionPath");
			Invoke(NormalExecution, files, normalExecutionPath);
			Invoke(ParallelExecution, files, parallelExecutionPath);
		}

		private void Invoke(Action<IEnumerable<string>, string> action, IEnumerable<string> files, string alteredPath)
		{
			Directory.Delete(alteredPath);
			Directory.CreateDirectory(alteredPath);
			var sw = new Stopwatch();
			sw.Start();
			action.Invoke(files, alteredPath);
			sw.Stop();
			Console.WriteLine($"{action.Method.Name}: {sw.ElapsedMilliseconds}");
		}

		private void NormalExecution(IEnumerable<string> files, string alteredPath)
		{
			files.ForEach(f =>
			{
				EachExecution(f, alteredPath);
			});
		}

		private void ParallelExecution(IEnumerable<string> files, string alteredPath)
		{
			Parallel.ForEach(files, currentFile =>
			{
				EachExecution(currentFile, alteredPath);
			});
		}

		private void EachExecution(string currentFile, string alteredPath)
		{
			var file = Path.GetFileName(currentFile);
			using (var fileBitMap = new Bitmap(currentFile))
			{
				fileBitMap.RotateFlip(RotateFlipType.Rotate180FlipX);
				fileBitMap.Save(Path.Combine(alteredPath, file));
				//Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
			};
		}
	}
}
