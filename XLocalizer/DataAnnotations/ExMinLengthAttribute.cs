using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public sealed class ExMinLengthAttribute : MinLengthAttribute
    {
        /// <summary>
        /// Initializes a new instance of the System.ComponentModel.DataAnnotations.MinLengthAttribute
        /// </summary>
        /// <param name="length"></param>
        public ExMinLengthAttribute(int length) : base(length)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.MinLengthAttribute_ValidationError;
        }
    }
}
