using System.ComponentModel.DataAnnotations;

namespace XLocalizer.Messages
{
    /// <summary>
    /// Class to provide custom default model binding error messages.
    /// Messages can be provided in any culture, so user can provide localized error messages here,
    /// but the default request culture in startup must be configured same as messages culture.
    /// </summary>
    public class DefaultModelBindingErrorMessages
    {
        /// <summary>
        /// "The value '{0}' is not valid for {1}."
        /// </summary>
        [Required]
        public string AttemptedValueIsInvalidAccessor { get; set; } = "The value '{0}' is not valid for {1}.";

        /// <summary>
        /// "A value for the '{0}' parameter or property was not provided."
        /// </summary>
        [Required]
        public string MissingBindRequiredValueAccessor { get; set; } = "A value for the '{0}' parameter or property was not provided.";

        /// <summary>
        /// "A value is required."
        /// </summary>
        [Required]
        public string MissingKeyOrValueAccessor { get; set; } = "A value is required.";

        /// <summary>
        /// "A non-empty request body is required."
        /// </summary>
        [Required]
        public string MissingRequestBodyRequiredValueAccessor { get; set; } = "A non-empty request body is required.";

        /// <summary>
        /// "The value '{0}' is not valid."
        /// </summary>
        [Required]
        public string NonPropertyAttemptedValueIsInvalidAccessor { get; set; } = "The value '{0}' is not valid.";

        /// <summary>
        /// "The supplied value is invalid."
        /// </summary>
        [Required]
        public string NonPropertyUnknownValueIsInvalidAccessor { get; set; } = "The supplied value is invalid.";

        /// <summary>
        /// "The field must be a number."
        /// </summary>
        [Required]
        public string NonPropertyValueMustBeANumberAccessor { get; set; } = "The field must be a number.";

        /// <summary>
        /// "The supplied value is invalid for {0}."
        /// </summary>
        [Required]
        public string UnknownValueIsInvalidAccessor { get; set; } = "The supplied value is invalid for {0}.";

        /// <summary>
        /// "The value '{0}' is invalid."
        /// </summary>
        [Required]
        public string ValueIsInvalidAccessor { get; set; } = "The value '{0}' is invalid.";

        /// <summary>
        /// "The field {0} must be a number."
        /// </summary>
        [Required]
        public string ValueMustBeANumberAccessor { get; set; } = "The field {0} must be a number.";

        /// <summary>
        /// "The value '{0}' is invalid."
        /// </summary>
        [Required]
        public string ValueMustNotBeNullAccessor { get; set; } = "The value '{0}' is invalid.";
    }
}
