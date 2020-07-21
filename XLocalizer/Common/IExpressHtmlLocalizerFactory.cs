using Microsoft.AspNetCore.Mvc.Localization;

namespace XLocalizer.Common
{
    /// <summary>
    /// Interface to create IHtmlLocalizer with the default (shared) resource type
    /// using .Create() method that takes no parameters
    /// </summary>
    public interface IExpressHtmlLocalizerFactory : IHtmlLocalizerFactory
    {
        /// <summary>
        /// Create new HtmlLocalizer based on default type and default translation service
        /// </summary>
        /// <returns></returns>
        IHtmlLocalizer Create();
    }
}
