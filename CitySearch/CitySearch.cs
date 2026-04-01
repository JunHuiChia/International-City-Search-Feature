using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CitySearch
{
    public class CityFinder : ICityFinder
    {
        private readonly TrieNode _root;

        public CityFinder()
        {
            _root = new TrieNode();
        }

        public void LoadDate(IEnumerable<string> cities)
        {
            foreach (var city in cities)
            {
                if (!string.IsNullOrEmpty(city))
                {
                    Insert(city.ToUpper());
                }
            }
        }

        public ICityResult Search(string searchString)
        {
            var cityResult = new CityResult();

            if (string.IsNullOrEmpty(searchString))
            {
                return cityResult;
            }

            searchString = searchString.ToUpper();
            var node = _root;

            foreach (var character in searchString)
            {
                if (!node.Children.TryGetValue(character, out var nextNode))
                {
                    return cityResult;
                }
            }

            cityResult.NextLetters = node.Children.Keys.Select(c => c.ToString()).ToList();

            var potentialCities = new List<string>();
            GetAllCities(node, potentialCities);
            cityResult.NextCities = potentialCities;
            
            return cityResult;
        }

        private void Insert(string city)
        {
            var node = _root;
            foreach (var character in city)
            {
                if (!node.Children.TryGetValue(character, out var nextNode))
                {
                    nextNode = new TrieNode();
                    node.Children[character] = nextNode;
                }
                node = nextNode;
            }
            node.IsEndOfWord = true;
            node.CityName = city;
        }

        private void GetAllCities(TrieNode node, List<string> cities)
        {
            if (node.IsEndOfWord)
            {
                cities.Add(node.CityName);
            }

            foreach (var child in node.Children.Values)
            {
                GetAllCities(child, cities);
            }
        }
    }
}