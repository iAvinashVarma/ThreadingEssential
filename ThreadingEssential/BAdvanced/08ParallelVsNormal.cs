using LearnEssential.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ThreadingEssential.Extension;

namespace ThreadingEssential.BAdvanced
{
	internal class ParallelVsNormal : ILearner
	{
		public void Practice(string[] args)
		{
			var path = Directory.GetCurrentDirectory();
			var picturesPath = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), @"Pictures\CodeOfConduct");
			var files = Directory.GetFiles(picturesPath, "*.*", SearchOption.AllDirectories)
					   .Where(s => s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)); ;
			var normalExecutionPath = Path.Combine(path, "NormalExecutionPath");
			var parallelExecutionPath = Path.Combine(path, "ParallelExecutionPath");
			Invoke(files, normalExecutionPath, NormalExecution);
			Invoke(files, parallelExecutionPath, ParallelExecution);
		}

		private void Invoke(IEnumerable<string> files, string alteredPath, Action<IEnumerable<string>, string> action)
		{
			DeleteDirectory(alteredPath);
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
				Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
			};
		}

		private void DeleteDirectory(string targetDirectory)
		{
			try
			{
				var files = Directory.GetFiles(targetDirectory);
				var dirs = Directory.GetDirectories(targetDirectory);

				files.ForEach(f =>
				{
					File.SetAttributes(f, FileAttributes.Normal);
					File.Delete(f);
				});

				dirs.ForEach(d =>
				{
					DeleteDirectory(d);
				});

				Directory.Delete(targetDirectory, false);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}
	}
}