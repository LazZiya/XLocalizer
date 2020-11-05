using System;

namespace XLocalizer.ModelBinding
{
    /// <summary>
    /// This class is deprected. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/model-binding-errors.md">Localizing Model Binding Errors</a>
    /// </summary>
    [Obsolete("This class is deprected. See https://docs.ziyad.info/en/XLocalizer/v1.0/model-binding-errors.md")]
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
