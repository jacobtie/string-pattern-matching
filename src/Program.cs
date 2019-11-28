using System;
using System.IO;
using string_pattern_matching.Algorithms;

namespace string_pattern_matching
{
	class Program
	{
		// Main method to begin running the program 
		static void Main(string[] args)
		{
			// Variable to store user input
			string input = "?";

			// Do while the user wants to repeat the program
			do
			{
				// Get the text and pattern from the user
				var (text, pattern) = GetUserInput();

				// Print out the results of each algorithm
				Console.WriteLine("\nBrute Force Algorithm: ");
				var (line, character, comps) = BruteForce.Run(text, pattern);
				PrintResult(pattern, line, character, comps);

				Console.WriteLine("\nHorspool's Algorithm: ");
				(line, character, comps) = BMH.Run(text, pattern);
				PrintResult(pattern, line, character, comps);

				Console.WriteLine("\nBoyer-Moore Algorithm: ");
				(line, character, comps) = BM.Run(text, pattern);
				PrintResult(pattern, line, character, comps);

				// Do while the user input is invalid
				do
				{
					Console.WriteLine("\nWould you like to run the program again? (Y/N)");
					input = Console.ReadLine();
				}
				while (input.Length == 0 || (input.ToUpper()[0] != 'Y' && input.ToUpper()[0] != 'N'));
			}
			while (input.ToUpper() == "Y");
		}

		// Method to read each line from a text file as an array of strings
		static string[] ReadTextFromFile(string textFile)
		{
			return System.IO.File.ReadAllLines(@"./TestFiles/" + textFile);
		}

		// Method to print the results of a particular algorithm
		static void PrintResult(string pattern, int line, int character, int comps)
		{
			// If the pattern was found in the text
			if (line != -1 && character != -1)
			{
				// Print the line, position, and number of comparisons
				Console.WriteLine("The first match for \"" + pattern + 
								"\" was found on line " + line + 
								" starting at character " + character + ". ");
				Console.WriteLine("The pattern was found after " + comps + " comparisons. ");
			}
			// Else the pattern could not be found in the text
			else
			{
				// Print the number of comparisons
				Console.WriteLine("\nThe pattern \"" + pattern + 
								"\" could not be found in the text. ");
				Console.WriteLine("The end of the text was reached after " + comps + " comparisons. ");
			}
		}

		// Method to get the text and pattern from the user
		static (string[], string) GetUserInput()
		{
			// Variables to store the text and pattern
			string[] textLines = {};
			string textFile;
			string pattern;
			bool invalid;

			// Do while the given text file could not be found
			do
			{
				// Reset invalid
				invalid = false;

				// Get the name of the text file
				Console.WriteLine("\nWhich file would you like to search from? ");
				textFile = Console.ReadLine();

				// Try to find and read the text file
				try
				{
					// Store each line from the text file
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
				// If the file could not be found
				catch (FileNotFoundException)
				{
					// Print the error and set invalid to true
					Console.WriteLine("\nFile could not be found. Please try again. ");
					invalid = true;
				}
			}
			while (invalid);

			// Do while the user inputted an empty pattern
			do 
			{
				// Get the pattern from the user
				Console.WriteLine("\nWhat pattern would you like to search for in this text? ");
				pattern = Console.ReadLine();
			}
			while (pattern.Length == 0);

			// Return the lines of the text and the pattern
			return (textLines, pattern);
		}
	}
}
