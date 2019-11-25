namespace string_pattern_matching.DataStructures
{
	public class GoodSuffixTable
	{
		private int[] _table;

		public GoodSuffixTable(string pattern)
		{
			this._table = new int[pattern.Length - 1];

			for (int i = pattern.Length - 1; i >= 1; i--)
			{
				var suffix = pattern.Substring(i, pattern.Length - i);
				var found = false;
				for (int j = i - 1; j >= 0; j--)
				{
					for (int k = 0; k < suffix.Length; k++)
					{
						if (pattern[j + k] != suffix[k])
						{
							break;
						}

						if (k == suffix.Length - 1)
						{
							found = true;
							this._table[pattern.Length - i - 1] = pattern.Length - (j + k) - 1;
							break;
						}
					}

					if (found)
					{
						break;
					}
				}

				if (!found)
				{
					var longestPrefixIndex = -1;

					for (int j = suffix.Length - 1; j > 0; j--)
					{
						var subSuffix = suffix.Substring(j, suffix.Length - j);

						for (int k = 0; k < subSuffix.Length; k++)
						{
							if (pattern[k] != subSuffix[k])
							{
								break;
							}

							if (k == subSuffix.Length - 1)
							{
								longestPrefixIndex = k;
							}
						}
					}

					this._table[pattern.Length - i - 1] = pattern.Length - longestPrefixIndex - 1;
				}
			}
		}

		public int this[int i]
		{
			get => this._table[i - 1];
		}
	}
}
