namespace string_pattern_matching.Algorithms
{
	public static class BruteForce
	{
		public static int Run(string text, string pattern)
		{
			for (int i = 0; i < text.Length - pattern.Length + 1; i++)
			{
				for (int j = 0; j < pattern.Length; j++)
				{
					if (text[i + j] != pattern[j])
					{
						break;
					}
					if (j == pattern.Length - 1)
					{
						return i;
					}
				}
			}

			return -1;
		}
	}
}
