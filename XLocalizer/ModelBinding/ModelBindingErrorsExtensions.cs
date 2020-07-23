using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Localization;

namespace XLocalizer.ModelBinding
{
    /// <summary>
    /// Original messages obtained from <a href="https://github.com/aspnet/AspNetCore/blob/master/src/Mvc/Mvc.Core/src/Resources.resx"/>
    /// </summary>
    public static class ModelBindingErrorsExtensions
    {
        /// <summary>
        /// Use DB for localization
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="localizer">localizer factory</param>
        public static void SetLocalizedModelBindingErrorMessages(this DefaultModelBindingMessageProvider provider, IStringLocalizer localizer)
        {
            provider.SetAttemptedValueIsInvalidAccessor((x, y)
                => GetLoclizedModelBindingError(localizer, "The value '{0}' is not valid for {1}.", x, y));

            provider.SetMissingBindRequiredValueAccessor((x)
                => GetLoclizedModelBindingError(localizer, "A value for the '{0}' parameter or property was not provided.", x));

            provider.SetMissingKeyOrValueAccessor(()
                => GetLoclizedModelBindingError(localizer, "A value is required."));

            provider.SetMissingRequestBodyRequiredValueAccessor(()
                => GetLoclizedModelBindingError(localizer, "A non-empty request body is required."));

            provider.SetNonPropertyAttemptedValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(localizer, "The value '{0}' is not valid.", x));

            provider.SetNonPropertyUnknownValueIsInvalidAccessor(()
                => GetLoclizedModelBindingError(localizer, "The supplied value is invalid."));

            provider.SetNonPropertyValueMustBeANumberAccessor(()
                => GetLoclizedModelBindingError(localizer, "The field must be a number."));

            provider.SetUnknownValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(localizer, "The supplied value is invalid for {0}.", x));

            provider.SetValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(localizer, "The value '{0}' is invalid.", x));

            provider.SetValueMustBeANumberAccessor((x)
                => GetLoclizedModelBindingError(localizer, "The field {0} must be a number.", x));

            provider.SetValueMustNotBeNullAccessor((x)
                => GetLoclizedModelBindingError(localizer, "The value '{0}' is invalid.", x));
        }

        private static string GetLoclizedModelBindingError(IStringLocalizer localizer, string code, params object[] args)
        {
            return localizer[code, args].Value;
        }
    }
}
