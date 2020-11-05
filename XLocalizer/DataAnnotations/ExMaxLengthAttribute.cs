using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public sealed class ExMaxLengthAttribute : MaxLengthAttribute
    {
        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExMaxLengthAttribute class
        /// </summary>
        public ExMaxLengthAttribute() : base()
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.MaxLengthAttribute_ValidationError;
        }

        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExMaxLengthAttribute class based on the length parameter.
        /// </summary>
        /// <param name="length">The maximum allowable length of array or string data.</param>
        public ExMaxLengthAttribute(int length) : base(length)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.MaxLengthAttribute_ValidationError;
        }
    }
}
