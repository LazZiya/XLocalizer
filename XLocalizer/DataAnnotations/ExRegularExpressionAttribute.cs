using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Specifies that a data field value in ASP.NET Dynamic Data must match the specified regular expression.
    /// And proivdes locaized error message.
    /// </summary>
    public sealed class ExRegularExpressionAttribute : RegularExpressionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExRegularExpressionAttribute class
        /// </summary>
        /// <param name="pattern">The regular expression that is used to validate the data field value.</param>
        /// <exception cref="ArgumentNullException">
        /// pattern is null.
        /// </exception>
        public ExRegularExpressionAttribute(string pattern) : base(pattern)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.RegexAttribute_ValidationError;
        }
    }
}
