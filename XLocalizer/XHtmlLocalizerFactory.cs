using XLocalizer.Common;
using Microsoft.AspNetCore.Mvc.Localization;
using System;

namespace XLocalizer
{
    /// <summary>
    /// Factory to create <see cref="XHtmlLocalizer{TResource}"/>
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public class XHtmlLocalizerFactory<TResource> : IExpressHtmlLocalizerFactory
        where TResource : class
    {
        private readonly IExpressStringLocalizerFactory _strFactory;

        /// <summary>
        /// Initialize a new instance of <see cref="XHtmlLocalizer{TResource}"/>
        /// </summary>
        /// <param name="stringLocalizerFactory"></param>
        public XHtmlLocalizerFactory(IExpressStringLocalizerFactory stringLocalizerFactory)
        {
            _strFactory = stringLocalizerFactory;
        }

        /// <summary>
        /// Create a new <see cref="IHtmlLocalizer"/> based on the default reource type
        /// </summary>
        /// <returns></returns>
        public IHtmlLocalizer Create()
        {
            return new XHtmlLocalizer<TResource>(_strFactory);
        }

        /// <summary>
        /// Create a new <see cref="IHtmlLocalizer"/> based on provided resource type
        /// </summary>
        /// <param name="resourceSource"></param>
        /// <returns></returns>
        public IHtmlLocalizer Create(Type resourceSource)
        {
            if (resourceSource == null)
                throw new NotImplementedException(nameof(resourceSource));

            var strLocalizer = _strFactory.Create(resourceSource);

            return new XHtmlLocalizer(strLocalizer);
        }

        public IHtmlLocalizer Create(string baseName, string location)
        {
            throw new NotImplementedException();
        }
    }
}
