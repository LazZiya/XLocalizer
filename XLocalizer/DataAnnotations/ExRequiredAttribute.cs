using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// This attribute is deprected and will be removed in a future release. Use [Required] instead
    /// </summary>
    /// 
    [Obsolete("This class is deprected and will be removed in a future release. Use [Required] instead")]
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
