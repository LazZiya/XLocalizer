using System.Text.RegularExpressions;

namespace XLocalizer.Common
{
    /// <summary>
    /// Trim all whitespaces in a string (start, end and between)
    /// </summary>
    public static class TextTrimmer
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+"); 
        
        /// <summary>
        /// Remove all extra whitespaces (more than one) in a string
        /// </summary>
        public static string ReplaceWhitespace(this string input, string replacement) 
        { 
            return sWhitespace.Replace(input.Trim(), replacement); 
        }
    }
}
