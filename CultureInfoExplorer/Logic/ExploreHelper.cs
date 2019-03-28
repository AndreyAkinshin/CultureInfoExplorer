using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CultureInfoExplorer
{
    public class ExploreHelper
    {
        public static ReadOnlyCollection<CultureInfo> AllCultures { get; private set; }
        public static ReadOnlyCollection<CultureInfoProperty> AllProperties { get; private set; }
        public static ReadOnlyCollection<Pattern> AllPatterns { get; private set; }

        static ExploreHelper()
        {
            AllCultures = new ReadOnlyCollection<CultureInfo>(CultureInfo.GetCultures(CultureTypes.AllCultures));
            AllProperties = new ReadOnlyCollection<CultureInfoProperty>(new List<CultureInfoProperty>
            {
                // *** Main ***
                new CultureInfoProperty(
                    "Main", 
                    "Name", 
                    "The culture name in the format languagecode2-country/regioncode2.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.name.aspx",
                    culture => culture.Name),
                new CultureInfoProperty(
                    "Main",
                    "DisplayName",
                    "The full localized culture name.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.displayname.aspx",
                    culture => culture.DisplayName),
                new CultureInfoProperty(
                    "Main",
                    "EnglishName",
                    "The culture name in the format languagefull [country/regionfull] in English.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.englishname.aspx",
                    culture => culture.EnglishName),
                new CultureInfoProperty(
                    "Main",
                    "NativeName",
                    "The culture name, consisting of the language, the country/region, and the optional script, that the culture is set to display.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.nativename.aspx",
                    culture => culture.NativeName),
                new CultureInfoProperty(
                    "Main",
                    "TwoLetterISOLanguageName",
                    "The ISO 639-1 two-letter code for the language of the current CultureInfo.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.twoletterisolanguagename.aspx",
                    culture => culture.TwoLetterISOLanguageName),
                new CultureInfoProperty(
                    "Main",
                    "ThreeLetterISOLanguageName",
                    "The ISO 639-2 three-letter code for the language of the current CultureInfo.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.threeletterisolanguagename.aspx",
                    culture => culture.ThreeLetterISOLanguageName),
                new CultureInfoProperty(
                    "Main",
                    "ThreeLetterWindowsLanguageName",
                    "The three-letter code for the language as defined in the Windows API.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.threeletterwindowslanguagename.aspx",
                    culture => culture.ThreeLetterWindowsLanguageName),
                new CultureInfoProperty(
                    "Main",
                    "IsNeutralCulture",
                    "A value indicating whether the current CultureInfo represents a neutral culture.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.isneutralculture.aspx",
                    culture => culture.IsNeutralCulture.ToString()),
                new CultureInfoProperty(
                    "Main",
                    "Parent",
                    "The CultureInfo that represents the parent culture of the current CultureInfo.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.parent.aspx",
                    culture => culture.Parent.DisplayName),
                new CultureInfoProperty(
                    "Main",
                    "Calendar",
                    "The default calendar used by the culture.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.calendar.aspx",
                    culture => CalendarToString(culture.Calendar)),
                new CultureInfoProperty(
                    "Main",
                    "OptionalCalendars",
                    "The list of calendars that can be used by the culture.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.optionalcalendars.aspx",
                    culture => ArrayToString(culture.OptionalCalendars.Select(CalendarToString).ToArray(), ", ")),
                new CultureInfoProperty(
                    "Main",
                    "LCID",
                    "The culture identifier",
                    "https://msdn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.lcid",
                    culture => culture.LCID.ToString()),
                
                // *** NumberFormat, Common ***
                new CultureInfoProperty(
                    "NumberFormat",
                    "NegativeSign",
                    "The string that denotes that the associated number is negative.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.negativesign.aspx",
                    culture => culture.NumberFormat.NegativeSign),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PositiveSign",
                    "The string that denotes that the associated number is positive.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.positivesign.aspx",
                    culture => culture.NumberFormat.PositiveSign),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NumberNegativePattern",
                    "The format pattern for negative numeric values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.numbernegativepattern.aspx",
                    culture => NumberNegativePatternToString(culture.NumberFormat.NumberNegativePattern)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NegativeInfinitySymbol",
                    "The string that represents negative infinity.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.negativeinfinitysymbol.aspx",
                    culture => culture.NumberFormat.NegativeInfinitySymbol),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PositiveInfinitySymbol",
                    "The string that represents positive infinity.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.positiveinfinitysymbol.aspx",
                    culture => culture.NumberFormat.PositiveInfinitySymbol),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NaNSymbol",
                    "The string that represents the IEEE NaN (not a number) value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.nansymbol.aspx",
                    culture => culture.NumberFormat.NaNSymbol),
                new CultureInfoProperty(
                    "NumberFormat",
                    "DigitSubstitution",
                    "A value that specifies how the graphical user interface displays the shape of a digit.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.digitsubstitution.aspx",
                    culture => culture.NumberFormat.DigitSubstitution.ToString()),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NativeDigits",
                    "A string array of native digits equivalent to the Western digits 0 through 9.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.nativedigits.aspx",
                    culture => ArrayToString(culture.NumberFormat.NativeDigits)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NumberDecimalDigits",
                    "The number of decimal places to use in numeric values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.numberdecimaldigits.aspx",
                    culture => culture.NumberFormat.NumberDecimalDigits.ToString(CultureInfo.InvariantCulture)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NumberDecimalSeparator",
                    "The string to use as the decimal separator in numeric values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.numberdecimalseparator.aspx",
                    culture => culture.NumberFormat.NumberDecimalSeparator),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NumberGroupSeparator",
                    "The string that separates groups of digits to the left of the decimal in numeric values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.numbergroupseparator.aspx",
                    culture => GroupSeparatorToString(culture.NumberFormat.NumberGroupSeparator)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "NumberGroupSizes",
                    "The number of digits in each group to the left of the decimal in numeric values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.numbergroupsizes.aspx",
                    culture => ArrayToString(culture.NumberFormat.NumberGroupSizes)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PerMilleSymbol",
                    "The string to use as the per mille symbol.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.permillesymbol.aspx",
                    culture => culture.NumberFormat.PerMilleSymbol),

                // *** NumberFormat, Pecent ***
                new CultureInfoProperty(
                    "NumberFormat",
                    "PercentSymbol",
                    "The string to use as the percent symbol.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.percentsymbol.aspx",
                    culture => culture.NumberFormat.PercentSymbol),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PercentNegativePattern",
                    "The format pattern for negative percent values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.percentnegativepattern.aspx",
                    culture => PercentNegativePatternToString(culture.NumberFormat.PercentNegativePattern)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PercentPositivePattern",
                    "The format pattern for positive percent values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.percentpositivepattern.aspx",
                    culture => PercentPositivePatternToString(culture.NumberFormat.PercentPositivePattern)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PercentDecimalDigits",
                    "The number of decimal places to use in percent values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.percentdecimaldigits.aspx",
                    culture => culture.NumberFormat.PercentDecimalDigits.ToString(CultureInfo.InvariantCulture)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PercentDecimalSeparator",
                    "The string to use as the decimal separator in percent values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.percentdecimalseparator.aspx",
                    culture => culture.NumberFormat.PercentDecimalSeparator),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PercentGroupSeparator",
                    "The string that separates groups of digits to the left of the decimal in percent values. ",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.percentgroupseparator.aspx",
                    culture => GroupSeparatorToString(culture.NumberFormat.PercentGroupSeparator)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "PercentGroupSizes",
                    "The number of digits in each group to the left of the decimal in percent values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.percentgroupsizes.aspx",
                    culture => ArrayToString(culture.NumberFormat.PercentGroupSizes)),

                // *** NumberFormat, Currency ***
                new CultureInfoProperty(
                    "NumberFormat",
                    "CurrencySymbol",
                    "The string to use as the currency symbol.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencysymbol.aspx",
                    culture => culture.NumberFormat.CurrencySymbol),
                new CultureInfoProperty(
                    "NumberFormat",
                    "CurrencyNegativePattern",
                    "The format pattern for negative currency values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencynegativepattern.aspx",
                    culture => CurrencyNegativePatternToString(culture.NumberFormat.CurrencyNegativePattern)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "CurrencyPositivePattern",
                    "The format pattern for positive currency values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencypositivepattern.aspx",
                    culture => CurrencyPositivePatternToString(culture.NumberFormat.CurrencyPositivePattern)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "CurrencyDecimalDigits",
                    "The number of decimal places to use in currency values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencydecimaldigits.aspx",
                    culture => culture.NumberFormat.CurrencyDecimalDigits.ToString(CultureInfo.InvariantCulture)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "CurrencyDecimalSeparator",
                    "The string to use as the decimal separator in currency values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencydecimalseparator.aspx",
                    culture => culture.NumberFormat.CurrencyDecimalSeparator),
                new CultureInfoProperty(
                    "NumberFormat",
                    "CurrencyGroupSeparator",
                    "The string that separates groups of digits to the left of the decimal in currency values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencygroupseparator.aspx",
                    culture => GroupSeparatorToString(culture.NumberFormat.CurrencyGroupSeparator)),
                new CultureInfoProperty(
                    "NumberFormat",
                    "CurrencyGroupSizes",
                    "The number of digits in each group to the left of the decimal in currency values.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencygroupsizes.aspx",
                    culture => ArrayToString(culture.NumberFormat.CurrencyGroupSizes)),


                // *** DateTimeFormat ***
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "AbbreviatedDayNames",
                    "A one-dimensional array of type String containing the culture-specific abbreviated names of the days of the week.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.abbreviateddaynames.aspx",
                    culture => ArrayToString(culture.DateTimeFormat.AbbreviatedDayNames)),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "AbbreviatedMonthGenitiveNames",
                    "A string array of abbreviated month names associated with the current DateTimeFormatInfo object.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.abbreviatedmonthgenitivenames.aspx",
                    culture => ArrayToString(culture.DateTimeFormat.AbbreviatedMonthGenitiveNames)),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "AbbreviatedMonthNames",
                    "A one-dimensional string array that contains the culture-specific abbreviated names of the months.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.abbreviatedmonthnames.aspx",
                    culture => ArrayToString(culture.DateTimeFormat.AbbreviatedMonthNames)),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "AMDesignator",
                    "The string designator for hours that are \"ante meridiem\" (before noon).",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.amdesignator.aspx",
                    culture => culture.DateTimeFormat.AMDesignator),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "CalendarWeekRule",
                    "A value that specifies which rule is used to determine the first calendar week of the year.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.calendarweekrule.aspx",
                    culture => culture.DateTimeFormat.CalendarWeekRule.ToString()),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "DateSeparator",
                    "The string that separates the components of a date, that is, the year, month, and day.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.dateseparator.aspx",
                    culture => culture.DateTimeFormat.DateSeparator),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "DayNames",
                    "A one-dimensional string array that contains the culture-specific full names of the days of the week.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.daynames.aspx",
                    culture => ArrayToString(culture.DateTimeFormat.DayNames)),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "FirstDayOfWeek",
                    "The first day of the week.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.firstdayofweek.aspx",
                    culture => culture.DateTimeFormat.FirstDayOfWeek.ToString()),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "FullDateTimePattern",
                    "The custom format string for a long date and long time value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.fulldatetimepattern.aspx",
                    culture => culture.DateTimeFormat.FullDateTimePattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "LongDatePattern",
                    "The custom format string for a long date value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.longdatepattern.aspx",
                    culture => culture.DateTimeFormat.LongDatePattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "LongTimePattern",
                    "The custom format string for a long time value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.longtimepattern.aspx",
                    culture => culture.DateTimeFormat.LongTimePattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "MonthDayPattern",
                    "The custom format string for a month and day value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.monthdaypattern.aspx",
                    culture => culture.DateTimeFormat.MonthDayPattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "MonthGenitiveNames",
                    "A string array of month names associated with the current DateTimeFormatInfo object.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.monthgenitivenames.aspx",
                    culture => ArrayToString(culture.DateTimeFormat.MonthGenitiveNames)),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "MonthNames",
                    "A one-dimensional array of type String containing the culture-specific full names of the months.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.monthnames.aspx",
                    culture => ArrayToString(culture.DateTimeFormat.MonthNames)),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "NativeCalendarName",
                    "The native name of the calendar associated with the current DateTimeFormatInfo object.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.nativecalendarname.aspx",
                    culture => culture.DateTimeFormat.NativeCalendarName),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "PMDesignator",
                    "The string designator for hours that are \"post meridiem\" (after noon).",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.pmdesignator.aspx",
                    culture => culture.DateTimeFormat.PMDesignator),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "RFC1123Pattern",
                    "The custom format string for a time value that is based on the Internet Engineering Task Force (IETF) Request for Comments (RFC) 1123 specification.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.rfc1123pattern.aspx",
                    culture => culture.DateTimeFormat.PMDesignator),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "ShortDatePattern",
                    "The custom format string for a short date value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.shortdatepattern.aspx",
                    culture => culture.DateTimeFormat.ShortDatePattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "ShortestDayNames",
                    "A string array of the shortest unique abbreviated day names associated with the current DateTimeFormatInfo object.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.shortestdaynames.aspx",
                    culture => ArrayToString(culture.DateTimeFormat.ShortestDayNames)),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "ShortTimePattern",
                    "The custom format string for a short time value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.shorttimepattern.aspx",
                    culture => culture.DateTimeFormat.ShortTimePattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "SortableDateTimePattern",
                    "The custom format string for a sortable date and time value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.sortabledatetimepattern.aspx",
                    culture => culture.DateTimeFormat.SortableDateTimePattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "TimeSeparator",
                    "The string that separates the components of time, that is, the hour, minutes, and seconds.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.timeseparator.aspx",
                    culture => culture.DateTimeFormat.TimeSeparator),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "UniversalSortableDateTimePattern",
                    "The custom format string for a universal, sortable date and time string.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.universalsortabledatetimepattern.aspx",
                    culture => culture.DateTimeFormat.UniversalSortableDateTimePattern),
                new CultureInfoProperty(
                    "DateTimeFormat",
                    "YearMonthPattern",
                    "The custom format string for a year and month value.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.yearmonthpattern.aspx",
                    culture => culture.DateTimeFormat.YearMonthPattern),

                 // *** TextInfo ***
                new CultureInfoProperty(
                    "TextInfo",
                    "IsRightToLeft",
                    "A value indicating whether the current TextInfo object represents a writing system where text flows from right to left.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.textinfo.isrighttoleft.aspx",
                    culture => culture.TextInfo.IsRightToLeft.ToString(CultureInfo.InvariantCulture)),
                new CultureInfoProperty(
                    "TextInfo",
                    "ListSeparator",
                    "The string that separates items in a list.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.textinfo.listseparator.aspx",
                    culture => culture.TextInfo.ListSeparator),
                new CultureInfoProperty(
                    "TextInfo",
                    "ANSICodePage",
                    "The American National Standards Institute (ANSI) code page used by the writing system represented by the current TextInfo.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.textinfo.ansicodepage.aspx",
                    culture => culture.TextInfo.ANSICodePage.ToString(CultureInfo.InvariantCulture)),
                new CultureInfoProperty(
                    "TextInfo",
                    "EBCDICCodePage",
                    "The Extended Binary Coded Decimal Interchange Code (EBCDIC) code page used by the writing system represented by the current TextInfo.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.textinfo.ebcdiccodepage.aspx",
                    culture => culture.TextInfo.EBCDICCodePage.ToString(CultureInfo.InvariantCulture)),
                new CultureInfoProperty(
                    "TextInfo",
                    "MacCodePage",
                    "The Macintosh code page used by the writing system represented by the current TextInfo.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.textinfo.maccodepage.aspx",
                    culture => culture.TextInfo.MacCodePage.ToString(CultureInfo.InvariantCulture)),
                new CultureInfoProperty(
                    "TextInfo",
                    "OEMCodePage",
                    "The original equipment manufacturer (OEM) code page used by the writing system represented by the current TextInfo.",
                    "http://msdn.microsoft.com/en-us/library/system.globalization.textinfo.oemcodepage.aspx",
                    culture => culture.TextInfo.OEMCodePage.ToString(CultureInfo.InvariantCulture)),
            });

            const double Number = 1234567.1234567;
            var patterns = new List<Pattern>
            {
                new Pattern("Number (positive)", culture => string.Format(culture, "{0:N7}", Number)),
                new Pattern("Number (negative)", culture => string.Format(culture, "{0:N7}", -Number)),
                new Pattern("Percent (positive)", culture => string.Format(culture, "{0:P7}", Number)),
                new Pattern("Percent (negative)", culture => string.Format(culture, "{0:P7}", -Number)),
                new Pattern("Currency (positive)", culture => string.Format(culture, "{0:C7}", Number)),
                new Pattern("Currency (negative)", culture => string.Format(culture, "{0:C7}", -Number)),
            };
            var dateTimeValue = new DateTime(2014, 12, 31, 13, 14, 15);
            var dateTimeFormats = new[]
            {
                "d", "D", "f", "F", "g", "G", "m", "o", "R", "s", "t", "T", "u", "U", "y",
                "h:mm:ss.ff t", "d MMM yyyy", "HH:mm:ss.f", "dd MMM HH:mm:ss", "HH:mm:ss.ffffzzz"
            };
            patterns.AddRange(dateTimeFormats.Select(dateTimeFormat => new Pattern(
                string.Format("DateTime ({0})", dateTimeFormat),
                culture => dateTimeValue.ToString(dateTimeFormat, culture))));
            AllPatterns = new ReadOnlyCollection<Pattern>(patterns);
        }

        private static string ArrayToString(int[] array, string separator = " ")
        {
            return string.Join(separator, array);
        }

        private static string ArrayToString(string[] array, string separator = " ")
        {
            return string.Join(separator, array);
        }

        private static string GroupSeparatorToString(string groupSeparator)
        {
            return FormatValue(groupSeparator);
        }

        private static string CurrencyNegativePatternToString(int currencyNegativePattern)
        {
            switch (currencyNegativePattern)
            {
                case 0:
                    return "($n)";
                case 1:
                    return "-$n";
                case 2:
                    return "$-n";
                case 3:
                    return "$n-";
                case 4:
                    return "(n$)";
                case 5:
                    return "-n$";
                case 6:
                    return "n-$";
                case 7:
                    return "n$-";
                case 8:
                    return "-n $";
                case 9:
                    return "-$ n";
                case 10:
                    return "n $-";
                case 11:
                    return "$ n-";
                case 12:
                    return "$ -n";
                case 13:
                    return "n- $";
                case 14:
                    return "($ n)";
                case 15:
                    return "(n $)";
            }
            throw new NotSupportedException();
        }

        private static string CurrencyPositivePatternToString(int currencyPositivePattern)
        {
            switch (currencyPositivePattern)
            {
                case 0:
                    return "$n";
                case 1:
                    return "n$";
                case 2:
                    return "$ n";
                case 3:
                    return "n $";
            }
            throw new NotSupportedException();
        }

        private static string NumberNegativePatternToString(int numberNegativePattern)
        {
            switch (numberNegativePattern)
            {
                case 0:
                    return "(n)";
                case 1:
                    return "-n";
                case 2:
                    return "- n";
                case 3:
                    return "n-";
                case 4:
                    return "n -";
            }
            throw new NotSupportedException();
        }

        private static string PercentNegativePatternToString(int percentNegativePattern)
        {
            switch (percentNegativePattern)
            {
                case 0:
                    return "-n %";
                case 1:
                    return "-n%";
                case 2:
                    return "-%n";
                case 3:
                    return "%-n";
                case 4:
                    return "%n-";
                case 5:
                    return "n-%";
                case 6:
                    return "n%-";
                case 7:
                    return "-% n";
                case 8:
                    return "n %-";
                case 9:
                    return "% n-";
                case 10:
                    return "% -n";
                case 11:
                    return "n- %";
            }
            throw new NotSupportedException();
        }

        private static string PercentPositivePatternToString(int percentPositivePattern)
        {
            switch (percentPositivePattern)
            {
                case 0:
                    return "n %";
                case 1:
                    return "n%";
                case 2:
                    return "%n";
                case 3:
                    return "% n";
            }
            throw new NotSupportedException();
        }

        private static string CalendarToString(Calendar calendar)
        {
            var algorithmType = calendar.AlgorithmType.ToString().Replace("Calendar", "");
            if (calendar.GetType() == typeof(GregorianCalendar))
            {
                var gregorianCalendar = (GregorianCalendar)calendar;
                return string.Format("Gregorian-{0} ({1})", gregorianCalendar.CalendarType, algorithmType);
            }
            return string.Format("{0} ({1})", calendar.ToString().Replace("System.Globalization.", "").Replace("Calendar", ""), algorithmType);
        }

        private static string FormatValue(string value)
        {
            var escapeChars = new[] { '\u00A0' };
            if (value.Length == 1 && escapeChars.Contains(value[0]))
                return string.Format("\\u{0}", ((int)value[0]).ToString("X4"));
            return value;
        }

        public static string GetPatternValues(CultureInfo culture)
        {
            var builder = new StringBuilder();
            var maxPatternNameWidth = AllPatterns.Max(p => p.Name.Length);
            foreach (var pattern in AllPatterns)
                builder.AppendLine(string.Format("{0} : {1}",
                    pattern.Name.PadRight(maxPatternNameWidth, ' '),
                    pattern.GetValue(culture)));
            return builder.ToString();
        }
    }
}