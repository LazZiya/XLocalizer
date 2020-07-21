using Microsoft.Extensions.Localization;

namespace XLocalizer.Common
{
    /// <summary>
    /// Interface to create IStringLocalizer with the default (shared) resource type
    /// using .Create() method that takes no parameters
    /// </summary>
    public interface IExpressStringLocalizerFactory : IStringLocalizerFactory
    {
        /// <summary>
        /// Create new StringLocalizer based on default type
        /// </summary>
        /// <returns></returns>
        IStringLocalizer Create();
    }
}
