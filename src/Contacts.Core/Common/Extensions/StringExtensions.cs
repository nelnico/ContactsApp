using System.Text.RegularExpressions;

namespace Contacts.Core.Common.Extensions;

public static class StringExtensions
{
    public static bool IsValidSouthAfricanMobileNumber(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return false;
        var regex = new Regex(@"[0](\d{9})|([0](\d{2})( |-)((\d{3}))( |-)(\d{4}))|[0](\d{2})( |-)(\d{7})");
        return regex.IsMatch(str) && str.Length == 10;
    }
}