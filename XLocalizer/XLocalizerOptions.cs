using XLocalizer.Messages;

namespace XLocalizer
{
    /// <summary>
    /// Express localization options
    /// </summary>
    public class XLocalizerOptions
    {
        /// <summary>
        /// The path to the resources folder e.g. "LocalizationResources"
        /// </summary>
        public string ResourcesPath { get; set; } = "LocalizationResources";
        
        /// <summary>
        /// Express valdiation attributes provides already localized error messages.
        /// Set to true by default. 
        /// Set to false if you don't want to use express validation attributes.
        /// </summary>
        public bool UseExpressValidationAttributes { get; set; } = true;

        /// <summary>
        /// If the key string is not found in the DB, it will be inserted autoamtically to the DB.
        /// default: false
        /// </summary>
        public bool AutoAddKeys { get; set; } = false;

        /// <summary>
        /// If the translation string is not found, it will be translated via registered translation servies.
        /// default: false
        /// Requires registering of one translation service at least. see <a href="...">Registering Translation Services for Localization</a>
        /// </summary>
        public bool AutoTranslate { get; set; } = false;

        /// <summary>
        /// ExpressMemory cache helps speeding up getting localized values from data stores.
        /// It is helpful to set to false during development mode and to true in production.
        /// Default value: true.
        /// </summary>
        public bool UseExpressMemoryCache { get; set; } = true;

        /// <summary>
        /// The culture name to translate from, if not set default request culture will be used.
        /// </summary>
        public string TranslateFromCulture { get; set; }

        /// <summary>
        /// Default DataAnnotation error messages.
        /// </summary>
        public DefaultDataAnnotationsErrorMessages DefaultDataAnnotationsErrorMessages { get; set; } = new DefaultDataAnnotationsErrorMessages();

        /// <summary>
        /// Default identity describer error messages
        /// </summary>
        public DefaultIdentityErrorsMessages DefaultIdentityErrorsMessages { get; set; } = new DefaultIdentityErrorsMessages();

        /// <summary>
        /// Default Model Binding Error Messages
        /// </summary>
        public DefaultModelBindingErrorMessages DefaultModelBindingErrorMessages { get; set; } = new DefaultModelBindingErrorMessages();
    }
}
