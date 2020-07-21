using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Specifies the minimum length of array or string data allowed in a property. And produces loclaized error message.
    /// </summary>
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
