using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// This attribute is deprected and will be removed in a future release. Use [MinLength] instead
    /// </summary>
    /// 
    [Obsolete("This class is deprected and will be removed in a future release. Use [MinLength] instead")]
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
