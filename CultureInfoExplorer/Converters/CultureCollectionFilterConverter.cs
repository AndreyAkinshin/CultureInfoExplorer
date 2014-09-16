using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public sealed class CultureCollectionFilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return ExploreHelper.AllCultures;

            var filter = value as string;
            if (filter == null)
                throw new ArgumentException("Value should be of System.String type.");

            if (filter == string.Empty)
                return ExploreHelper.AllCultures;
            filter = filter.ToUpperInvariant();

            return ExploreHelper.AllCultures.Where(c => c.EnglishName.ToUpperInvariant().Contains(filter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
