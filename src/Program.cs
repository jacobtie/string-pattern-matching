using System;
using string_pattern_matching.Logging;
using string_pattern_matching.Algorithms;

namespace string_pattern_matching
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.WriteLine("String Pattern Matching");

			string keepPlaying;

			do
			{
				var (text, pattern, algorithm) = GetUserInput();

				if (algorithm != "all" && algorithm != "ALL")
				{
					var (index, comparisons) = algorithm switch
					{
						var x when x == "BF" || x == "bf" => BruteForce.Run(text, pattern),
						var y when y == "BMH" || y == "bmh" => BMH.Run(text, pattern),
						var z when z == "BM" || z == "bm" => BM.Run(text, pattern),
						_ => throw new Exception("Invalid algorithm string"),
					};

					if (index == -1)
					{
						Logger.Write("\nPattern was not found in the given text. ");
					}
					else
					{
						Logger.Write($"\nPattern was found at index {index}. ");
					}

					Logger.WriteLine($"There were {comparisons} comparisons made.");
				}
				else
				{
					var (indexBF, comparisonsBF) = BruteForce.Run(text, pattern);
					var (indexBMH, comparisonsBMH) = BMH.Run(text, pattern);
					var (indexBM, comparisonsBM) = BM.Run(text, pattern);

					if (indexBF == -1)
					{
						Logger.WriteLine("\nPattern was not found in the given text. ");
					}
					else
					{
						Logger.WriteLine($"\nPattern was found at index {indexBF}. ");
					}

					Logger.WriteLine($"There were {comparisonsBF} comparisons made by the Brute Force Algorithm.");
					Logger.WriteLine($"There were {comparisonsBMH} comparisons made by the Boyer-Moore-Horspool Algorithm.");
					Logger.WriteLine($"There were {comparisonsBM} comparisons made by the Boyer-Moore Algorithm.");
				}

				do
				{
					Logger.WriteLine("\nWould you like to repeat program? y/n ");
					keepPlaying = Logger.ReadLine();
				}
				while (keepPlaying != "y" && keepPlaying != "Y" && keepPlaying != "n" && keepPlaying != "N");

				Logger.WriteLine();
			}
			while (keepPlaying == "y" || keepPlaying == "Y");

			Logger.LogToFile();

			Console.WriteLine("\nLog outputted to logs/ directory.");

			Console.WriteLine("\nPress enter to exit...");
			Console.ReadLine();
		}

		static (string, string, string) GetUserInput()
		{
			string text;
			string pattern;
			string algorithm;

			Logger.WriteLine("\nPlease enter the text you would like to search: ");

			do
			{
				text = Logger.ReadLine();
			}
			while (text.Length == 0);

			do
			{
				Logger.WriteLine("\nPlease enter the pattern you would like to find: ");
				pattern = Logger.ReadLine();
			}
			while (pattern.Length == 0);

			do
			{
				Logger.WriteLine("\nPlease enter BF for the Brute Force algorithm, BMH for the Boyer-Moore-Horspool algorithm, BM for the Boyer-Moore algorithm, or ALL for all 3 algorithms: ");
				algorithm = Logger.ReadLine();
			}
			while (algorithm != "BF" && algorithm != "bf" && algorithm != "BMH" && algorithm != "bmh" && algorithm != "BM" && algorithm != "bm" && algorithm != "all" && algorithm != "ALL");

			return (text, pattern, algorithm);
		}
	}
}
