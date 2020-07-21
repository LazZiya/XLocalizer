using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Specifies that a data field is required, and provides a localized error message
    /// </summary>
    public sealed class ExRequiredAttribute : RequiredAttribute
    {
        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExRequiredAttribute class.
        /// </summary>
        public ExRequiredAttribute() : base()
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.RequiredAttribute_ValidationError;
        }
    }
}
