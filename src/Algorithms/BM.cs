using System;
using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BM
	{
		public static int Run(string text, string pattern)
		{
			var badShiftTable = new BadSymbolTable(pattern);
			var goodShiftTable = new GoodSuffixTable(pattern);

			var textIndex = 0;

			while (textIndex < text.Length - pattern.Length + 1)
			{
				var patternIndex = pattern.Length - 1;
				while (patternIndex >= 0)
				{
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
							var d1 = Math.Max(badShiftTable[text[textIndex + patternIndex]] - 1 - (pattern.Length - patternIndex - 1), 1);
							var d2 = goodShiftTable[pattern.Length - patternIndex - 1];
							textIndex += Math.Max(d1, d2);
						}

						break;
					}
				}

				if (patternIndex == -1)
				{
					return textIndex;
				}
			}

			return -1;
		}
	}
}
