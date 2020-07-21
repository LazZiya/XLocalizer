using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Provides an attribute that compares two properties, and produces localized error message.
    /// </summary>
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
