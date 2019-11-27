namespace string_pattern_matching.Algorithms
{
	public static class BruteForce
	{
		public static (int, int) Run(string text, string pattern)
		{
			var comparisons = 0;

			for (int i = 0; i < text.Length - pattern.Length + 1; i++)
			{
				for (int j = 0; j < pattern.Length; j++)
				{
					comparisons++;
					if (text[i + j] != pattern[j])
					{
						break;
					}
					if (j == pattern.Length - 1)
					{
						return (i, comparisons);
					}
				}
			}

			return (-1, comparisons);
		}
	}
}
