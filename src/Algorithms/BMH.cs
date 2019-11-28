using System;
using string_pattern_matching.DataStructures;

namespace string_pattern_matching.Algorithms
{
	public static class BMH
	{
		public static (int, int, int) Run(string[] textLines, string pattern)
		{
			var shiftTable = new BadSymbolTable(pattern);

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
							textIndex += shiftTable[line[textIndex + pattern.Length - 1]];
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
