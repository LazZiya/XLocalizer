using Microsoft.AspNetCore.Builder;

using System;

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
        /// Optional : Add culture parameter to login, logout and access denied paths.
        /// <para>default value = true</para>
        /// <para>set to false if you need to configure the application cookie options manually</para>
        /// </summary>
        public bool ConfigureRedirectPaths { get; set; } = true;

        /// <summary>
        /// The default login path
        /// <para>default value = "/Identity/Account/Login/"</para>
        /// </summary>
        public string RedirectToLoginPath { get; set; } = "/Identity/Account/Login/";
        
        /// <summary>
        /// The default logout path
        /// <para>default value = "/Identity/Account/Logout/"</para>
        /// </summary>
        public string RedirectToLogoutPath { get; set; } = "/Identity/Account/Logout/";
        
        /// <summary>
        /// The default access denied path
        /// <para>default value = "/Identity/Account/AccessDenied/"</para>
        /// </summary>
        public string RedirectToAccessDeniedPath { get; set; } = "/Identity/Account/AccessDenied/";

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
    }
}
