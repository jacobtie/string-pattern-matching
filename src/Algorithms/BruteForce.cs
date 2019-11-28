namespace string_pattern_matching.Algorithms
{
	public static class BruteForce
	{
		public static (int index, int comparisons) Run(string text, string pattern)
		{
			// Initialize the variable for the comparisons
			var comparisons = 0;

			// For every character in the current line
			for (int i = 0; i < text.Length - pattern.Length + 1; i++)
			{
				// For every character in the pattern
				for (int j = 0; j < pattern.Length; j++)
				{
					// Increment the number of comparisons
					comparisons++;

					// If the current text character is not the same as 
					// the current pattern character
					if (text[i + j] != pattern[j])
					{
						// Break from the pattern loop
						break;
					}

					// If the end of the pattern has been reached
					if (j == pattern.Length - 1)
					{
						// Return the position and comparisons
						return (i, comparisons);
					}
				}
			}

			// Return default failure values
			return (-1, comparisons);
		}
	}
}
