using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using XLocalizer.Messages;

namespace XLocalizer.MetadataProviders
{
    /// <summary>
    /// A class to override the default model binding error messages
    /// </summary>
    public class XModelBindingMetadataProvider : IBindingMetadataProvider
    {
        private readonly IStringLocalizer localizer;
        private readonly DefaultModelBindingErrorMessages mbErrors;

        /// <summary>
        /// Initialize a new instance of <see cref="XModelBindingMetadataProvider"/>
        /// </summary>
        /// <param name="strLocalizer"></param>
        /// <param name="options"></param>
        public XModelBindingMetadataProvider(IStringLocalizer strLocalizer, IOptions<XLocalizerOptions> options)
        {
            localizer = strLocalizer;
            mbErrors = options.Value.DefaultModelBindingErrorMessages;
        }

        /// <summary>
        /// Create binding metadata and override <see cref="DefaultModelBindingMessageProvider"/> by custom instance of <see cref="DefaultModelBindingErrorMessages"/>
        /// </summary>
        /// <param name="context"></param>
        public void CreateBindingMetadata(BindingMetadataProviderContext context)
        {
            var provider = new DefaultModelBindingMessageProvider();
            
            provider.SetAttemptedValueIsInvalidAccessor((x, y) => localizer[mbErrors.AttemptedValueIsInvalidAccessor, x, y]);

            provider.SetMissingBindRequiredValueAccessor((x) => localizer[mbErrors.MissingBindRequiredValueAccessor, x]);

            provider.SetMissingKeyOrValueAccessor(() => localizer[mbErrors.MissingKeyOrValueAccessor]);

            provider.SetMissingRequestBodyRequiredValueAccessor(() => localizer[mbErrors.MissingRequestBodyRequiredValueAccessor]);

            provider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => localizer[mbErrors.NonPropertyAttemptedValueIsInvalidAccessor, x]);

            provider.SetNonPropertyUnknownValueIsInvalidAccessor(() => localizer[mbErrors.NonPropertyUnknownValueIsInvalidAccessor]);

            provider.SetNonPropertyValueMustBeANumberAccessor(() => localizer[mbErrors.NonPropertyValueMustBeANumberAccessor]);

            provider.SetUnknownValueIsInvalidAccessor((x) => localizer[mbErrors.UnknownValueIsInvalidAccessor, x]);

            provider.SetValueIsInvalidAccessor((x) => localizer[mbErrors.ValueIsInvalidAccessor, x]);

            provider.SetValueMustBeANumberAccessor((x) => localizer[mbErrors.ValueMustBeANumberAccessor, x]);

            provider.SetValueMustNotBeNullAccessor((x) => localizer[mbErrors.ValueMustNotBeNullAccessor, x]);

            context.BindingMetadata.ModelBindingMessageProvider = provider;
        }
    }
}
