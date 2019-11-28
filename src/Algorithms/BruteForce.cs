namespace string_pattern_matching.Algorithms
{
	public static class BruteForce
	{
		public static (int, int, int) Run(string[] textLines, string pattern)
		{
			var lineIndex = 0;
			var comps = 0;

			foreach (var line in textLines)
			{
				for (int i = 0; i < line.Length - pattern.Length + 1; i++)
				{
					for (int j = 0; j < pattern.Length; j++)
					{
						comps++; 

						if (line[i + j] != pattern[j])
						{
							break;
						}
						if (j == pattern.Length - 1)
						{
							return (lineIndex + 1, i + 1, comps);
						}
					}
				}

				lineIndex++;
			}

			return (-1, -1, comps);
		}
	}
}
