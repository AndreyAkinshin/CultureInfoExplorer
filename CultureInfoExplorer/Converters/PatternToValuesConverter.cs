using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public class PatternToValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pattern = value as Pattern;
            if (pattern == null)
                return new string[0];
            return ExploreHelper.AllCultures.Select(pattern.GetValue).Distinct().OrderBy(v => v).ToList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}