using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// This attribute is deprected and will be removed in a future release. Use [MaxLength] instead
    /// </summary>
    /// 
    [Obsolete("This class is deprected and will be removed in a future release. Use [MaxLength] instead")]
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
