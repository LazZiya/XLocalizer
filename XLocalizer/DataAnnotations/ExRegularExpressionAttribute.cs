using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// This attribute is deprected and will be removed in a future release. Use [RegularExpression] instead
    /// </summary>
    /// 
    [Obsolete("This class is deprected and will be removed in a future release. Use [RegularExpression] instead")]
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
