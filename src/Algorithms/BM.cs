using System;
using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BM
	{
		public static (int, int) Run(string text, string pattern)
		{
			var badShiftTable = new BadSymbolTable(pattern);
			var goodShiftTable = new GoodSuffixTable(pattern);
			var comparisons = 0;

			var textIndex = 0;

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
						if (patternIndex == pattern.Length - 1)
						{
							textIndex += badShiftTable[text[textIndex + patternIndex]];
						}
						else
						{
							var matchedCharacters = pattern.Length - patternIndex - 1;
							var badShiftValue = badShiftTable[text[textIndex + patternIndex]];
							var d1 = Math.Max(badShiftValue - matchedCharacters, 1);
							var d2 = goodShiftTable[matchedCharacters];
							textIndex += Math.Max(d1, d2);
						}

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
