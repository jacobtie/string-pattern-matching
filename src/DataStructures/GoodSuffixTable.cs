namespace string_pattern_matching.DataStructures
{
	public class GoodSuffixTable
	{
		private int[] _table;

		// Constructor to create the good suffix table
		public GoodSuffixTable(string pattern)
		{
			// Initialize the table 
			this._table = new int[pattern.Length - 1];

			// For every character in the pattern starting from the right
			for (int i = pattern.Length - 1; i >= 1; i--)
			{
				// Get the suffix of the pattern based on the current character
				var suffix = pattern.Substring(i, pattern.Length - i);

				// Reset found to false
				var found = false;

				// For every character before the current character
				for (int j = i - 1; j >= 0; j--)
				{
					// For every character in the current suffix
					for (int k = 0; k < suffix.Length; k++)
					{
						// If the current character in the pattern is not the same
						// as the current character in the suffix
						if (pattern[j + k] != suffix[k])
						{
							break;
						}

						// If the entire suffix was found
						if (k == suffix.Length - 1)
						{
							// Set found to true
							found = true;

							// Update the good suffix table with the shift amount
							this._table[pattern.Length - i - 1] = pattern.Length - (j + k) - 1;
							break;
						}
					}

					// If the suffix was found
					if (found)
					{
						break;
					}
				}

				// If the suffix was not found
				if (!found)
				{
					// Initialize the longest prefix's index
					var longestPrefixIndex = -1;

					// For every character in the suffix starting from the right
					for (int j = suffix.Length - 1; j > 0; j--)
					{
						// Get the subsuffix of the current suffix
						var subSuffix = suffix.Substring(j, suffix.Length - j);

						// For every character in the subsuffix
						for (int k = 0; k < subSuffix.Length; k++)
						{
							// If the current character in the pattern is not the same
							// as the current character in the subsuffix
							if (pattern[k] != subSuffix[k])
							{
								break;
							}

							// If the entire subsuffix was found
							if (k == subSuffix.Length - 1)
							{
								// Set the longest prefix index
								longestPrefixIndex = k;
							}
						}
					}

					// Update the good suffix table with the shift amount
					this._table[pattern.Length - i - 1] = pattern.Length - longestPrefixIndex - 1;
				}
			}
		}

		public int this[int k]
		{
			get => this._table[k - 1];
		}
	}
}
