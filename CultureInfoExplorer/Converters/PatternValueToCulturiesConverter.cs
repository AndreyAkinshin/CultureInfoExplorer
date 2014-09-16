using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public class PatternValueToCulturesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo converterCulture)
        {
            if (!(values.Length == 2 && values[0] is Pattern && values[1] is string))
                return new CultureInfo[0];
            var pattern = values[0] as Pattern;
            var patternValue = values[1] as string;
            return ExploreHelper.AllCultures.Where(culture => pattern.GetValue(culture) == patternValue).ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo converterCulture)
        {
            throw new NotImplementedException();
        }
    }
}