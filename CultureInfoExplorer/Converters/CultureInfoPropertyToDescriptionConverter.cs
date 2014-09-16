using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public class CultureInfoPropertyToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo converterCulture)
        {
            var builder = new StringBuilder();
            var property = value as CultureInfoProperty;
            if (property != null)
            {
                builder.AppendLine(property.DisplayName);
                builder.AppendLine(property.Description);
                builder.AppendLine(property.MsdnUrl);
                var availableValues = ExploreHelper.AllCultures.
                    Select(culture => string.Format("'{0}'", property.GetValue(culture))).
                    Distinct().
                    OrderBy(v => v);
                builder.AppendLine("Values: " + string.Join(", ", availableValues));
                builder.AppendLine();

                builder.AppendLine("*** Values for each cultrue ***");
                var maxNameWidth = ExploreHelper.AllCultures.Max(culture => culture.Name.Length);
                foreach (var culture in ExploreHelper.AllCultures)
                    builder.AppendLine(string.Format("{0}: {1}",
                        culture.Name.PadRight(maxNameWidth, ' '),
                        property.GetValue(culture)));
                builder.AppendLine();

                builder.AppendLine("*** Cultures by value ***");
                var groups = from c in ExploreHelper.AllCultures
                             group c by property.GetValue(c) into g
                             select new { Value = g.Key, Cultures = g.ToList() };
                foreach (var group in groups)
                {
                    builder.AppendLine(group.Value);
                    foreach (var culture in group.Cultures)
                        builder.AppendLine(string.Format("  {0} ({1})", culture.DisplayName, culture.Name));
                }
            }
            return builder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo converterCulture)
        {
            throw new NotImplementedException();
        }
    }
}