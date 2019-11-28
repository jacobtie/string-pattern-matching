using System;
using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BM
	{
		public static (int, int, int) Run(string[] textLines, string pattern)
		{
			var badShiftTable = new BadSymbolTable(pattern);
			var goodShiftTable = new GoodSuffixTable(pattern);

			var lineIndex = 0;
			var comps = 0;

			foreach (var line in textLines)
			{
				var textIndex = 0;
				
				while (textIndex < line.Length - pattern.Length + 1)
				{
					var patternIndex = pattern.Length - 1;

					while (patternIndex >= 0)
					{
						comps++;
						
						if (line[textIndex + patternIndex] == pattern[patternIndex])
						{
							patternIndex--;
						}
						else
						{
							if (patternIndex == pattern.Length - 1)
							{
								textIndex += badShiftTable[line[textIndex + patternIndex]];
							}
							else
							{
								var d1 = Math.Max(badShiftTable[line[textIndex + patternIndex]] - 1 - (pattern.Length - patternIndex - 1), 1);
								var d2 = goodShiftTable[pattern.Length - patternIndex - 1];
								textIndex += Math.Max(d1, d2);
							}

							break;
						}
					}

					if (patternIndex == -1)
					{
						return (lineIndex + 1, textIndex + 1, comps);
					}
				}

				lineIndex++;
			}

			return (-1, -1, comps);
		}
	}
}
