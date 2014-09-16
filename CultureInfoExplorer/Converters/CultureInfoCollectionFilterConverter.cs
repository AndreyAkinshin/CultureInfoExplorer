using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public sealed class CultureInfoCollectionFilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = value as string;
            if (string.IsNullOrWhiteSpace(filter))
                return ExploreHelper.AllCultures;
            filter = filter.ToUpperInvariant().Trim();
            return ExploreHelper.AllCultures.Where(c => c.EnglishName.ToUpperInvariant().Contains(filter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
