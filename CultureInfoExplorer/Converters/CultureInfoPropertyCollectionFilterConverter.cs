using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public sealed class CultureInfoPropertyCollectionFilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<CultureInfoProperty> properties;
            var filter = value as string;
            if (string.IsNullOrWhiteSpace(filter))
                properties = ExploreHelper.AllProperties;
            else
            {
                filter = filter.ToUpperInvariant();
                properties = ExploreHelper.AllProperties.Where(c => c.DisplayName.ToUpperInvariant().Contains(filter));
            }
            var groupedProperites = CollectionViewSource.GetDefaultView(properties);
            groupedProperites.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
            return groupedProperites;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
