using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public class CultureInfoToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo converterCulture)
        {
            var culture = value as CultureInfo;
            if (culture == null)
                return "";
            var builder = new StringBuilder();

            builder.AppendLine("*** Patterns ***");
            builder.AppendLine(ExploreHelper.GetPatternValues(culture));
            builder.AppendLine();

            builder.AppendLine("*** Properties ***");
            foreach (var property in ExploreHelper.AllProperties)
                builder.AppendLine(property.DisplayName + ": " + property.GetValue(culture));

            return builder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo converterCulture)
        {
            throw new NotImplementedException();
        }
    }
}