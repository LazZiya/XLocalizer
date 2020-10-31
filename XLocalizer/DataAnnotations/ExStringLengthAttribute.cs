using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// This attribute is deprected and will be removed in a future release. Use [StringLength] instead
    /// </summary>
    /// 
    [Obsolete("This class is deprected and will be removed in a future release. Use [StringLength] instead")]
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
