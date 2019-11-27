using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BMH
	{
		public static (int, int) Run(string text, string pattern)
		{
			var shiftTable = new BadSymbolTable(pattern);

			var textIndex = 0;
			var comparisons = 0;

			while (textIndex < text.Length - pattern.Length + 1)
			{
				var patternIndex = pattern.Length - 1;
				while (patternIndex >= 0)
				{
					comparisons++;
					if (text[textIndex + patternIndex] == pattern[patternIndex])
					{
						patternIndex--;
					}
					else
					{
						textIndex += shiftTable[text[textIndex + pattern.Length - 1]];
						break;
					}
				}

				if (patternIndex == -1)
				{
					return (textIndex, comparisons);
				}
			}

			return (-1, comparisons);
		}
	}
}
