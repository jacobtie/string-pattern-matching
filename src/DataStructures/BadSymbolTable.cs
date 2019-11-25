using System.Collections.Generic;

namespace string_pattern_matching.DataStructures
{
	public class BadSymbolTable
	{
		private Dictionary<char, int> _table;
		private int _m;

		public BadSymbolTable(string pattern)
		{
			this._table = new Dictionary<char, int>();
			this._m = pattern.Length;

			for (int i = 0; i < this._m - 1; i++)
			{
				_table[pattern[i]] = this._m - 1 - i;
			}
		}

		public int this[char c]
		{
			get => this._table.ContainsKey(c) ? this._table[c] : this._m;
		}
	}
}
