using System;
using System.Collections.Generic;
using System.Text;

namespace CitySearch
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord { get; set; }
        public string CityName { get; set; }
    }
}
