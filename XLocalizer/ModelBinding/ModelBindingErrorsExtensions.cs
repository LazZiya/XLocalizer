using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Localization;
using System;
using XLocalizer.Messages;

namespace XLocalizer.ModelBinding
{
    /// <summary>
    /// Original messages obtained from <a href="https://github.com/aspnet/AspNetCore/blob/master/src/Mvc/Mvc.Core/src/Resources.resx"/>
    /// </summary>
    [Obsolete("This class is deprected and will be removed in a future release.")]
    public static class ModelBindingErrorsExtensions
    {
        /// <summary>
        /// Use DB for localization
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="localizer">localizer factory</param>
        /// <param name="mbErrors">Model binding errors</param>
        public static void SetLocalizedModelBindingErrorMessages(this DefaultModelBindingMessageProvider provider, DefaultModelBindingErrorMessages mbErrors, IStringLocalizer localizer)
        {
            provider.SetAttemptedValueIsInvalidAccessor((x, y)
                => GetLoclizedModelBindingError(localizer, mbErrors.AttemptedValueIsInvalidAccessor, x, y));

            provider.SetMissingBindRequiredValueAccessor((x)
                => GetLoclizedModelBindingError(localizer, mbErrors.MissingBindRequiredValueAccessor, x));

            provider.SetMissingKeyOrValueAccessor(()
                => GetLoclizedModelBindingError(localizer, mbErrors.MissingKeyOrValueAccessor));

            provider.SetMissingRequestBodyRequiredValueAccessor(()
                => GetLoclizedModelBindingError(localizer, mbErrors.MissingRequestBodyRequiredValueAccessor));

            provider.SetNonPropertyAttemptedValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(localizer, mbErrors.NonPropertyAttemptedValueIsInvalidAccessor, x));

            provider.SetNonPropertyUnknownValueIsInvalidAccessor(()
                => GetLoclizedModelBindingError(localizer, mbErrors.NonPropertyUnknownValueIsInvalidAccessor));

            provider.SetNonPropertyValueMustBeANumberAccessor(()
                => GetLoclizedModelBindingError(localizer, mbErrors.NonPropertyValueMustBeANumberAccessor));

            provider.SetUnknownValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(localizer, mbErrors.UnknownValueIsInvalidAccessor, x));

            provider.SetValueIsInvalidAccessor((x)
                => GetLoclizedModelBindingError(localizer, mbErrors.ValueIsInvalidAccessor, x));

            provider.SetValueMustBeANumberAccessor((x)
                => GetLoclizedModelBindingError(localizer, mbErrors.ValueMustBeANumberAccessor, x));

            provider.SetValueMustNotBeNullAccessor((x)
                => GetLoclizedModelBindingError(localizer, mbErrors.ValueMustNotBeNullAccessor, x));
        }

        private static string GetLoclizedModelBindingError(IStringLocalizer localizer, string code, params object[] args)
        {
            return localizer[code, args].Value;
        }
    }
}
