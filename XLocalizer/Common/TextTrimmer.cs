using System.Text.RegularExpressions;

namespace XLocalizer.Common
{
    /// <summary>
    /// Trim all whitespaces in a string (start, end and between)
    /// </summary>
    internal static class TextTrimmer
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+"); 
        internal static string ReplaceWhitespace(this string input, string replacement) 
        { 
            return sWhitespace.Replace(input.Trim(), replacement); 
        }
    }
}
