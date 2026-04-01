using System;
using System.Collections.Generic;
using System.Text;

namespace CitySearch
{
    public class CityResult : ICityResult
    {
        public ICollection<string> NextLetters { get; set; } = new List<string>();
        public ICollection<string> NextCities { get; set; } = new List<string>();
    }
}
