using XLocalizer.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

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
        /// <param name="factory">localizer factory</param>
        public static void SetLocalizedModelBindingErrorMessages(this DefaultModelBindingMessageProvider provider, IExpressStringLocalizerFactory factory)
        {
            provider.SetAttemptedValueIsInvalidAccessor((x, y)
                => GetLoclizedModelBindingError(factory, "The value '{0}' is not valid for {1}.", x, y));

            provider.SetMissingBindRequiredValueAccessor((x)
                => GetLoclizedModelBindingError(factory, "A value for the '{0}' parameter or property was not provided.", x));

            provider.SetMissingKeyOrValueAccessor(()
                => GetLoclizedModelBindingError(factory, "A value is required."));

            provider.SetMissingRequestBodyRequiredValueAccessor(()
                => GetLoclizedModelBindingError(factory, "A non-empty request body is required."));

            provider.SetNonPropertyAttemptedValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(factory, "The value '{0}' is not valid.", x));

            provider.SetNonPropertyUnknownValueIsInvalidAccessor(()
                => GetLoclizedModelBindingError(factory, "The supplied value is invalid."));

            provider.SetNonPropertyValueMustBeANumberAccessor(()
                => GetLoclizedModelBindingError(factory, "The field must be a number."));

            provider.SetUnknownValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(factory, "The supplied value is invalid for {0}.", x));

            provider.SetValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(factory, "The value '{0}' is invalid.", x));

            provider.SetValueMustBeANumberAccessor((x)
                => GetLoclizedModelBindingError(factory, "The field {0} must be a number.", x));

            provider.SetValueMustNotBeNullAccessor((x)
                => GetLoclizedModelBindingError(factory, "The value '{0}' is invalid.", x));
        }

        private static string GetLoclizedModelBindingError(IExpressStringLocalizerFactory factory, string code, params object[] args)
        {
            var localizer = factory.Create();
            return localizer[code, args].Value;
        }
    }
}
