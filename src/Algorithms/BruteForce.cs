namespace string_pattern_matching.Algorithms
{
	public static class BruteForce
	{
		// Method to run the brute force pattern-matching algorithm
		public static (int, int, int) Run(string[] textLines, string pattern)
		{
			// Initialize the variables for the line index and comparisons
			var lineIndex = 0;
			var comps = 0;

			// For each line in the text
			foreach (var line in textLines)
			{
				// For every character in the current line
				for (int i = 0; i < line.Length - pattern.Length + 1; i++)
				{
					// For every character in the pattern
					for (int j = 0; j < pattern.Length; j++)
					{
						// Increment the number of comparisons
						comps++; 

						// If the current text character is not the same as 
						// the current pattern character
						if (line[i + j] != pattern[j])
						{
							// Break from the pattern loop
							break;
						}

						// If the end of the pattern has been reached
						if (j == pattern.Length - 1)
						{
							// Return the current line, position, and comparisons
							return (lineIndex + 1, i + 1, comps);
						}
					}
				}

				// Increment the line number
				lineIndex++;
			}

			// Return default failure values
			return (-1, -1, comps);
		}
	}
}
