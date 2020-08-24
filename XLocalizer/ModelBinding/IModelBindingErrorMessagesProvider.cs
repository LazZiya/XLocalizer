namespace XLocalizer.ModelBinding
{
    /// <summary>
    /// Interface to provide custom default model binding error messages.
    /// Messages can be provided in any culture, so user can provide localized error messages here,
    /// but the default request culture in startup must be configured same as messages culture.
    /// </summary>
    public interface IModelBindingErrorMessagesProvider
    {
        /// <summary>
        /// "The value '{0}' is not valid for {1}."
        /// </summary>
        string AttemptedValueIsInvalidAccessor { get; }

        /// <summary>
        /// "A value for the '{0}' parameter or property was not provided."
        /// </summary>
        string MissingBindRequiredValueAccessor { get; }

        /// <summary>
        /// "A value is required."
        /// </summary>
        string MissingKeyOrValueAccessor { get; }

        /// <summary>
        /// "A non-empty request body is required."
        /// </summary>
        string MissingRequestBodyRequiredValueAccessor { get; }

        /// <summary>
        /// "The value '{0}' is not valid."
        /// </summary>
        string NonPropertyAttemptedValueIsInvalidAccessor { get; }

        /// <summary>
        /// "The supplied value is invalid."
        /// </summary>
        string NonPropertyUnknownValueIsInvalidAccessor { get; }

        /// <summary>
        /// "The field must be a number."
        /// </summary>
        string NonPropertyValueMustBeANumberAccessor { get; }

        /// <summary>
        /// "The supplied value is invalid for {0}."
        /// </summary>
        string UnknownValueIsInvalidAccessor { get; }

        /// <summary>
        /// "The value '{0}' is invalid."
        /// </summary>
        string ValueIsInvalidAccessor { get; }

        /// <summary>
        /// "The field {0} must be a number."
        /// </summary>
        string ValueMustBeANumberAccessor { get; }

        /// <summary>
        /// "The value '{0}' is invalid."
        /// </summary>
        string ValueMustNotBeNullAccessor { get; }
    }
}
