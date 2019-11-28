using System;
using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BMH
	{
		// Method to run Horspool's pattern-matching algorithm
		public static (int, int, int) Run(string[] textLines, string pattern)
		{
			// Create the bad symbol using the pattern
			var shiftTable = new BadSymbolTable(pattern);

			// Initialize the variables for the line index and comparisons
			var lineIndex = 0;
			var comps = 0;

			// For each line in the text
			foreach (var line in textLines)
			{
				// Reset the text position to zero
				var textIndex = 0;

				// While the text index is less than the length of the
				// current line minus the length of the pattern
				while (textIndex < line.Length - pattern.Length + 1)
				{
					// Reset the pattern index
					var patternIndex = pattern.Length - 1;

					// While the entire pattern has not been found
					while (patternIndex >= 0)
					{
						// Increment the number of comparisons
						comps++;
						
						// If the current character in the line is the same
						// as the current character in the pattern
						if (line[textIndex + patternIndex] == pattern[patternIndex])
						{
							// Decrement the pattern index
							patternIndex--;
						}
						// Else they are not the same
						else
						{
							// Shift by the amount given by the last matched character
							// of the pattern 
							textIndex += shiftTable[line[textIndex + pattern.Length - 1]];
							break;
						}
					}

					// If the pattern was found
					if (patternIndex == -1)
					{
						// Return the current line, position, and comparisons
						return (lineIndex + 1, textIndex + 1, comps);
					}
				}

				// Increment the line index
				lineIndex++;
			}

			// Return the default failure values
			return (-1, -1, comps);
		}
	}
}
