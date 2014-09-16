using System;
using System.Globalization;

namespace CultureInfoExplorer
{
    public class Pattern
    {
        public string Name { get; private set; }
        public Func<CultureInfo, string> GetValue { get; private set; }

        public Pattern(string name, Func<CultureInfo, string> getValue)
        {
            Name = name;
            GetValue = getValue;
        }
    }
}