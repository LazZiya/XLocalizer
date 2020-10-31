using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// This attribute is deprected and will be removed in a future release. Use [Compare("otherproperty")] instead
    /// </summary>
    /// 
    [Obsolete("This class is deprected and will be removed in a future release. Use [Compare(\"otherproperty\")] instead")]
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
