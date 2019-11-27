using System;
using string_pattern_matching.Logging;
using string_pattern_matching.Algorithms;

namespace string_pattern_matching
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.WriteLine(BM.Run("CBBAABAABBCABAAABBBABBAAB", "ABBAAB"));

			Console.WriteLine("\nPress enter to exit...");
			Console.ReadLine();
		}
	}
}
