using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BMH
	{
		public static (int index, int comparisons) Run(string text, string pattern)
		{
			// Create the bad symbol using the pattern
			var shiftTable = new BadSymbolTable(pattern);

			// Initialize the variables for the text index and comparisons
			var textIndex = 0;
			var comparisons = 0;

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
						// Shift by the amount given by the last matched character
						// of the pattern 
						textIndex += shiftTable[text[textIndex + pattern.Length - 1]];
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

			// Return the default failure values
			return (-1, comparisons);
		}
	}
}
