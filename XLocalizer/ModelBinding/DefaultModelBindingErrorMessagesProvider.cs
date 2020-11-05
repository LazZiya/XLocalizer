using System;

namespace XLocalizer.ModelBinding
{
    /// <summary>
    /// This class is deprected. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/model-binding-errors.md">Localizing Model Binding Errors</a>
    /// </summary>
    [Obsolete("This class is deprected. See https://docs.ziyad.info/en/XLocalizer/v1.0/model-binding-errors.md")]
    public class DefaultModelBindingErrorMessagesProvider : IModelBindingErrorMessagesProvider
    {
        string IModelBindingErrorMessagesProvider.AttemptedValueIsInvalidAccessor => "The value '{0}' is not valid for {1}.";

        string IModelBindingErrorMessagesProvider.MissingBindRequiredValueAccessor => "A value for the '{0}' parameter or property was not provided.";

        string IModelBindingErrorMessagesProvider.MissingKeyOrValueAccessor => "A value is required.";

        string IModelBindingErrorMessagesProvider.MissingRequestBodyRequiredValueAccessor => "A non-empty request body is required.";

        string IModelBindingErrorMessagesProvider.NonPropertyAttemptedValueIsInvalidAccessor => "The value '{0}' is not valid.";

        string IModelBindingErrorMessagesProvider.NonPropertyUnknownValueIsInvalidAccessor => "The supplied value is invalid.";

        string IModelBindingErrorMessagesProvider.NonPropertyValueMustBeANumberAccessor => "The field must be a number.";

        string IModelBindingErrorMessagesProvider.UnknownValueIsInvalidAccessor => "The supplied value is invalid for {0}.";

        string IModelBindingErrorMessagesProvider.ValueIsInvalidAccessor => "The value '{0}' is invalid.";

        string IModelBindingErrorMessagesProvider.ValueMustBeANumberAccessor => "The field {0} must be a number.";

        string IModelBindingErrorMessagesProvider.ValueMustNotBeNullAccessor => "The value '{0}' is invalid.";
    }
}
