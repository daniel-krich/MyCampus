using System.Globalization;

namespace MyCampusUI.Extensions;

public static class DateTimeExtensions
{
    public static string ToLongDateHebrewString(this DateTime date)
    {
        CultureInfo il = new CultureInfo("he-IL");
        return date.ToString("f", il);
    }
}
