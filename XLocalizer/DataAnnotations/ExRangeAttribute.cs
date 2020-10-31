using System;
using System.ComponentModel.DataAnnotations;

namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// This attribute is deprected and will be removed in a future release. Use [Range] instead
    /// </summary>
    /// 
    [Obsolete("This class is deprected and will be removed in a future release. Use [Range] instead")]
    public sealed class ExRangeAttribute : RangeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the LazZiya.ExpressLocalizatin.DataAnnotations.ExRangeAttribute class 
        /// by using the specified minimum and maximum values.
        /// </summary>
        /// <param name="minimum">Specifies the minimum value allowed for the data field value.</param>
        /// <param name="maximum">Specifies the maximum value allowed for the data field value.</param>
        public ExRangeAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.RangeAttribute_ValidationError;
        }

        /// <summary>
        /// Initializes a new instance of the LazZiya.ExpressLocalizatin.DataAnnotations.ExRangeAttribute class 
        /// by using the specified minimum and maximum values.
        /// </summary>
        /// <param name="minimum">Specifies the minimum value allowed for the data field value.</param>
        /// <param name="maximum">Specifies the maximum value allowed for the data field value.</param>
        public ExRangeAttribute(int minimum, int maximum) : base(minimum, maximum)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.RangeAttribute_ValidationError;
        }

        /// <summary>
        /// Initializes a new instance of the XLocalizer.DataAnnotations.ExRangeAttribute
        ///     class by using the specified minimum and maximum values and the specific type.
        /// </summary>
        /// <param name="type">Specifies the type of the object to test.</param>
        /// <param name="minimum">Specifies the minimum value allowed for the data field value.</param>
        /// <param name="maximum">Specifies the maximum value allowed for the data field value.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Type is null
        /// </exception>
        public ExRangeAttribute(Type type, string minimum, string maximum) : base(type, minimum, maximum)
        {
            this.ErrorMessage = ErrorMessage ?? DataAnnotationsErrorMessages.RangeAttribute_ValidationError;
        }
    }
}
