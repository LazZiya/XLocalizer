using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public sealed class ExCompareAttribute : CompareAttribute
    {
        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExCompareAttribute class.
        /// <paramref name="otherProperty">The property to compare with the current property.</paramref>
        /// </summary>
        public ExCompareAttribute(string otherProperty) : base(otherProperty)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.CompareAttribute_MustMatch;
        }
    }
}
