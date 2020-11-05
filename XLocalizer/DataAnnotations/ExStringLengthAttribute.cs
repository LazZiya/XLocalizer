using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Express validation attributes are deprected. Use default attributes instead. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md">Localizing Data Annotations</a>
    /// </summary>
    [Obsolete("Express validation attributes are deprected. Use default attributes instead. See https://docs.ziyad.info/en/XLocalizer/v1.0/localizing-validation-attributes-errors.md")]
    public sealed class ExStringLengthAttribute : StringLengthAttribute
    {
        private bool HasCustomError;

        /// <summary>
        /// Gets or sets the minimum length of a string
        /// </summary>
        /// <remarks>Min length err check: credits <a href="https://github.com/LazZiya/ExpressLocalization/pull/31">@rrtischler</a> </remarks>
        public new int MinimumLength
        {
            get => base.MinimumLength;
            set
            {
                base.MinimumLength = value;
                if (!HasCustomError)
                    this.ErrorMessage = DataAnnotationsErrorMessages.StringLengthAttribute_ValidationErrorIncludingMinimum;
            }
        }

        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExStringLengthAttribute 
        /// class by using a specified maximum length.
        /// </summary>
        /// <param name="maximumLength">The maximum length of a string.</param>
        public ExStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
            HasCustomError = !(ErrorMessage is null);
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.StringLengthAttribute_ValidationError;
        }
    }
}
