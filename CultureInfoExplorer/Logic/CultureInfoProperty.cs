using System;
using System.Globalization;

namespace CultureInfoExplorer
{
    public class CultureInfoProperty
    {
        public string Group { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string MsdnUrl { get; private set; }
        public Func<CultureInfo, string> GetValue { get; private set; }
        public string DisplayName { get { return Group == "Main" ? Name : Group + "." + Name; } }

        public CultureInfoProperty(string @group, string name, string description, string msdnUrl, Func<CultureInfo, string> getValue)
        {
            Group = @group;
            Name = name;
            Description = description;
            MsdnUrl = msdnUrl;
            GetValue = getValue;
        }
    }
}