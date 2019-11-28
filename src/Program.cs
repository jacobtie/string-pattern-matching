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

			// Variable to hold whether or not to continue the program after each termination
			string keepPlaying;

			// Loop while the user wants to continue
			do
			{
				// Get user input of text, pattern, and which algorithm to run
				var (text, pattern, algorithm) = GetUserInput();

				// Run one algorithm if user did not specify to run all
				if (algorithm != "all" && algorithm != "ALL")
				{
					// Get the index and comparisons based on which algorithm the user chose
					var (index, comparisons) = algorithm switch
					{
						var x when x == "BF" || x == "bf" => BruteForce.Run(text, pattern),
						var y when y == "BMH" || y == "bmh" => BMH.Run(text, pattern),
						var z when z == "BM" || z == "bm" => BM.Run(text, pattern),
						_ => throw new Exception("Invalid algorithm string"),
					};

					// If the pattern was not found
					if (index == -1)
					{
						Logger.Write("\nPattern was not found in the given text. ");
					}
					// Else the pattern was found
					else
					{
						Logger.Write($"\nPattern was found at index {index}. ");
					}

					Logger.WriteLine($"There were {comparisons} comparisons made.");
				}
				else
				{
					// Get the index and comparisons from all algorithms
					var (indexBF, comparisonsBF) = BruteForce.Run(text, pattern);
					var (indexBMH, comparisonsBMH) = BMH.Run(text, pattern);
					var (indexBM, comparisonsBM) = BM.Run(text, pattern);

					// All algorithms should return the same index so we only need to use indexBF

					// If pattern was not found
					if (indexBF == -1)
					{
						Logger.WriteLine("\nPattern was not found in the given text. ");
					}
					// Else pattern was found
					else
					{
						Logger.WriteLine($"\nPattern was found at index {indexBF}. ");
					}

					Logger.WriteLine($"There were {comparisonsBF} comparisons made by the Brute Force Algorithm.");
					Logger.WriteLine($"There were {comparisonsBMH} comparisons made by the Boyer-Moore-Horspool Algorithm.");
					Logger.WriteLine($"There were {comparisonsBM} comparisons made by the Boyer-Moore Algorithm.");
				}

				// Loop until valid input of y/n
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

			// Loop until valid input of text
			do
			{
				text = Logger.ReadLine();
			}
			while (text.Length == 0);

			// Loop until valid input of pattern
			do
			{
				Logger.WriteLine("\nPlease enter the pattern you would like to find: ");
				pattern = Logger.ReadLine();
			}
			while (pattern.Length == 0);

			// Loop until valid input of algorithm
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
