using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace XLocalizer.Routing
{
    /// <summary>
    /// Configure global template for page route, so culture parameter will be placed at the beginning of the URL
    /// </summary>
    public class RouteTemplateModelConventionRazorPages : IPageRouteModelConvention
    {
        /// <summary>
        /// automatically invoked
        /// </summary>
        /// <param name="model"></param>
        public void Apply(PageRouteModel model)
        {
            var selectorCount = model.Selectors.Count;
            for (var i = 0; i < selectorCount; i++)
            {
                var selector = model.Selectors[i];
                model.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Order = -1,
                        Template = AttributeRouteModel.CombineTemplates(
                            "{culture?}",
                            selector.AttributeRouteModel.Template)
                    }
                });
            }
        }
    }
}
