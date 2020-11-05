using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
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
