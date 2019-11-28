using System.Collections.Generic;

namespace string_pattern_matching.DataStructures
{
	public class BadSymbolTable
	{
		private Dictionary<char, int> _table;
		private int _m;

		// Constructor to create the bad symbol table
		public BadSymbolTable(string pattern)
		{
			// Initialize the Dictionary and pattern length
			this._table = new Dictionary<char, int>();
			this._m = pattern.Length;

			// For every character in the pattern
			for (int i = 0; i < this._m - 1; i++)
			{
				// Update the length of the character from the end of the pattern
				_table[pattern[i]] = this._m - 1 - i;
			}
		}

		// Index the table
		public int this[char c]
		{
			// Return the value at the key if it exists, else return the length of the pattern
			get => this._table.ContainsKey(c) ? this._table[c] : this._m;
		}
	}
}
