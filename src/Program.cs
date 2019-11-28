using System;
using System.IO;
using string_pattern_matching.Algorithms;

namespace string_pattern_matching
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = "?";

			do
			{
				var (text, pattern) = GetUserInput();

				Console.WriteLine("\nBrute Force Algorithm: ");
				var (line, character, comps) = BruteForce.Run(text, pattern);
				PrintResult(pattern, line, character, comps);

				Console.WriteLine("\nHorspool's Algorithm: ");
				(line, character, comps) = BMH.Run(text, pattern);
				PrintResult(pattern, line, character, comps);

				Console.WriteLine("\nBoyer-Moore Algorithm: ");
				(line, character, comps) = BM.Run(text, pattern);
				PrintResult(pattern, line, character, comps);

				do
				{
					Console.WriteLine("\nWould you like to run the program again? (Y/N)");
					input = Console.ReadLine();
				}
				while (input.Length == 0 || (input.ToUpper()[0] != 'Y' && input.ToUpper()[0] != 'N'));
			}
			while (input.ToUpper() == "Y");
		}

		static string[] ReadTextFromFile(string textFile)
		{
			return System.IO.File.ReadAllLines(@"./TestFiles/" + textFile);
		}

		static void PrintResult(string pattern, int line, int character, int comps)
		{
			if (line != -1 && character != -1)
			{
				Console.WriteLine("The first match for \"" + pattern + 
								"\" was found on line " + line + 
								" starting at character " + character + ". ");
				Console.WriteLine("The pattern was found after " + comps + " comparisons. ");
			}
			else
			{
				Console.WriteLine("\nThe pattern \"" + pattern + 
								"\" could not be found in the text. ");
				Console.WriteLine("The end of the text was reached after " + comps + " comparisons. ");
			}
		}

		static (string[], string) GetUserInput()
		{
			string[] textLines = {};
			string textFile;
			string pattern;
			bool invalid;

			do
			{
				invalid = false;
				Console.WriteLine("\nWhich file would you like to search from? ");
				textFile = Console.ReadLine();

				try
				{
					textLines = ReadTextFromFile(textFile);

					Console.WriteLine();

					foreach (var character in textLines[0])
					{
						Console.Write("-");
					}

					Console.WriteLine();

					foreach (var line in textLines)
					{
						Console.WriteLine(line);
					}

					foreach (var character in textLines[0])
					{
						Console.Write("-");
					}

					Console.WriteLine();
				}
				catch (FileNotFoundException)
				{
					Console.WriteLine("\nFile could not be found. Please try again. ");
					invalid = true;
				}
			}
			while (invalid);

			do 
			{
				Console.WriteLine("\nWhat pattern would you like to search for in this text? ");
				pattern = Console.ReadLine();
			}
			while (pattern.Length == 0);

			return (textLines, pattern);
		}
	}
}
