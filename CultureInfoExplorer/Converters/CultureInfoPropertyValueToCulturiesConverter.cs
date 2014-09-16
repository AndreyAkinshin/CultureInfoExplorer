using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public class CultureInfoPropertyValueToCulturesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo converterCulture)
        {
            if (!(values.Length == 2 && values[0] is CultureInfoProperty && values[1] is string))
                return new CultureInfo[0];
            var property = values[0] as CultureInfoProperty;
            var propertyValue = values[1] as string;
            return ExploreHelper.AllCultures.Where(culture => property.GetValue(culture) == propertyValue).ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo converterCulture)
        {
            throw new NotImplementedException();
        }
    }
}