using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public class CultureInfoPropertyToValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var property = value as CultureInfoProperty;
            if (property == null)
                return new string[0];
            return ExploreHelper.AllCultures.Select(property.GetValue).Distinct().OrderBy(v => v).ToList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}