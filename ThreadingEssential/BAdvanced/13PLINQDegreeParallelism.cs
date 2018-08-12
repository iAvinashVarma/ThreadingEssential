using LearnInfra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace ThreadingEssential.BAdvanced
{
	public class PLINQDegreeParallelism : ILearner
	{
		public void Practice(string[] args)
		{
			var webSites = new List<string>
			{
				"www.apple.com",
				"www.google.com",
				"www.microsoft.com"
			};

			var responses = webSites.AsParallel()
				.WithDegreeOfParallelism(webSites.Count)
				.Select(PingSites).ToList();

			responses.ForEach(r =>
			{
				Console.WriteLine($"IP Address: {r.Address} | Status: {r.Status} | Time Taken: {r.RoundtripTime}");
			});
		}

		private PingReply PingSites(string webSiteName)
		{
			var ping = new Ping();
			return ping.Send(webSiteName);
		}
	}
}