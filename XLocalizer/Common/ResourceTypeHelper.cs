using System;
using System.IO;
using System.Reflection;

namespace XLocalizer.Common
{
    /// <summary>
    /// Generate fully qualified resource name
    /// ResourceManager looks for .resources files in the project output directory.
    /// So if our resource file is .\LocalizationResources\LocSource.tr.resx
    /// Then ResourceManager will look for: SampleProject.LocalizationResources.LocSource.tr.resources
    ///
    /// The resource name must be in the following format:
    /// {assembly-name}.{resources-folder}.{resource-namespace}.{resource-name}
    /// e.g. SampleProject.LocalizationResources.LocSource
    /// e.g. SampleProject.LocalizationResources.Pages.Products.IndexModel
    ///
    /// The challenge is when we have a type name for a PageModel out of resources-folder,
    /// such type has no class inside the resources folder, so we have to reconstruct the
    /// type full name to fulfill above format.
    /// </summary>
    public class ResourceTypeHelper
    {
        /// <summary>
        /// Create the compiled reource name from type and location
        /// </summary>
        /// <param name="type"></param>
        /// <param name="location">Resources folder path</param>
        /// <returns></returns>
        public static string CreateCompiledResourceName(Type type, string location)
        {
            // Get {assembly-name}
            // e.g.: SampleProject
            var assemblyName = type.Assembly.GetName().Name;

            var locationAsNamespace = location.Replace(Path.DirectorySeparatorChar, '.').Replace(Path.AltDirectorySeparatorChar, '.');

            // If we have a type resource already inside the resources folder, then take the full type name.
            // e.g. 
            // Type             : LocSource
            // Type Location    : SampleProject\LocalizationResources\LocSource 
            // Type full name   : SampleProject.LocalizationResources.LocSource
            // Resx Resource    : SampleProject\LocalizationResources\LocSource.xx.resx
            // Compiled resource: SampleProject.LocalizationResources.LocSource.xx.resources

            // Or, the type can be out of resources folder, so we need to add the resources folder name
            // e.g.
            // Type             : LoginModel
            // Type Location    : SampleProject\Areas\Identity\Pages\Account\LoginModel 
            // Type full name   : SampleProject.Areas.Identity.Pages.Account.LoginModel
            // Resx Resource    : SampleProject\LocalizationResources\Areas.Identity.Pages.Account.LoginModel.xx.resx
            // Compiled Resource: SampleProject.LocalizationResources.Areas.Identity.Pages.Account.LoginModel.xx.resources

            // Compiled resources are located in the root of output folder
            // and they are used by ResourceManager to read localized values from.

            return type.FullName.StartsWith($"{assemblyName}.{locationAsNamespace}.")
                ? type.FullName
                : type.FullName.Replace($"{assemblyName}.", $"{assemblyName}.{locationAsNamespace}.");
        }

        /// <summary>
        /// Create a reource name from type and location
        /// </summary>
        /// <param name="type"></param>
        /// <param name="location">Resources folder path</param>
        /// <returns></returns>
        public static string CreateResourceName(Type type, string location)
        {
            // Get {assembly-name}
            // e.g.: SampleProject
            var assemblyName = type.Assembly.GetName().Name;

            var locationAsNamespace = location.Replace(Path.DirectorySeparatorChar, '.').Replace(Path.AltDirectorySeparatorChar, '.');

            // If we have a type resource already inside the resources folder, then take the full type name.
            // e.g. 
            // Type             : LocSource
            // Type Location    : SampleProject\LocalizationResources\LocSource 
            // Type full name   : SampleProject.LocalizationResources.LocSource
            // Resx/Xml Resource    : SampleProject\LocalizationResources\LocSource.xx.resx

            // Or, the type can be out of resources folder, so we need to add the resources folder name
            // e.g.
            // Type             : LoginModel
            // Type Location    : SampleProject\Areas\Identity\Pages\Account\LoginModel 
            // Type full name   : SampleProject.Areas.Identity.Pages.Account.LoginModel
            // Resx Resource    : SampleProject\LocalizationResources\Areas.Identity.Pages.Account.LoginModel.xx.resx
            return type.FullName.StartsWith($"{assemblyName}.{locationAsNamespace}.")
                ? type.FullName.Replace($"{assemblyName}.{locationAsNamespace}.", "")
                : type.FullName.Replace($"{assemblyName}.", "");
        }

        /// <summary>
        /// Create a type name from basename and location
        /// </summary>
        /// <param name="baseName">Type full name</param>
        /// <param name="location">Assembly name</param>
        /// <returns></returns>
        public static Type GetResourceType(string baseName, string location)
        {
            var assemblyName = new AssemblyName(location);
            var assembly = Assembly.Load(assemblyName);
            var type = assembly.GetType(baseName);

            return type;
        }
    }
}
