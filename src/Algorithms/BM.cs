using System;
using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BM
	{
		public static (int index, int comparisons) Run(string text, string pattern)
		{
			// Create the bad symbol table with the pattern
			var badShiftTable = new BadSymbolTable(pattern);
			// Create the good suffix table with the pattern
			var goodShiftTable = new GoodSuffixTable(pattern);
			// Initialize the variable for the comparisons and text index
			var comparisons = 0;
			var textIndex = 0;

			// While the text index is less than the length of the
			// current line minus the length of the pattern
			while (textIndex < text.Length - pattern.Length + 1)
			{
				// Reset the pattern index
				var patternIndex = pattern.Length - 1;

				// While the entire pattern has not been found
				while (patternIndex >= 0)
				{
					// Increment the number of comparisons
					comparisons++;

					// If the current character in the text is the same
					// as the current character in the pattern
					if (text[textIndex + patternIndex] == pattern[patternIndex])
					{
						// Decrement the pattern index
						patternIndex--;
					}
					// Else they are not the same
					else
					{
						// If no matches were made
						if (patternIndex == pattern.Length - 1)
						{
							// Shift using the bad shift of the current character
							textIndex += badShiftTable[text[textIndex + patternIndex]];
						}
						// Else some matches were made
						else
						{
							// Get the max between the bad shift of the current character and one
							var matchedCharacters = pattern.Length - patternIndex - 1;
							var badShiftValue = badShiftTable[text[textIndex + patternIndex]];
							var d1 = Math.Max(badShiftValue - matchedCharacters, 1);

							// Get the good shift based on the number of matches
							var d2 = goodShiftTable[matchedCharacters];

							// Get the max between the bad shift and the good shift
							textIndex += Math.Max(d1, d2);
						}

						break;
					}
				}

				// If the pattern was found
				if (patternIndex == -1)
				{
					// Return the position and comparisons
					return (textIndex, comparisons);
				}
			}

			// Return the default failure values with the number of comparisons
			return (-1, comparisons);
		}
	}
}
