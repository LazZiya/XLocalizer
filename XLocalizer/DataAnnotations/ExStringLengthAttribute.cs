using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Specifies the minimum and maximum length of characters that are allowed in a data field. 
    /// And provides a localized error message
    /// </summary>
    public sealed class ExStringLengthAttribute : StringLengthAttribute
    {
        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExStringLengthAttribute 
        /// class by using a specified maximum length.
        /// </summary>
        /// <param name="maximumLength">The maximum length of a string.</param>
        public ExStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.StringLengthAttribute_ValidationError;
        }
    }
}
