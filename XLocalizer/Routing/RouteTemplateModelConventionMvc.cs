using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace XLocalizer.Routing
{
    /// <summary>
    /// Configure global template for page route, so culture parameter will be placed at the beginning of the URL
    /// </summary>
    public class RouteTemplateModelConventionMvc : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _culture;

        /// <summary>
        /// Initialize a new instance of RouteTemplateModelConventionMvc to configure a global {culture?} route
        /// </summary>
        public RouteTemplateModelConventionMvc()
        {
            _culture = new AttributeRouteModel();
            _culture.Template = "{culture?}";
        }

        /// <summary>
        /// Initialize a new instance of RouteTemplateModelConventionMvc to configure a global {culture?} route
        /// </summary>
        /// <param name="cultureSegment"></param>
        public RouteTemplateModelConventionMvc(string cultureSegment)
        {
            _culture = new AttributeRouteModel();
            _culture.Template = cultureSegment;
        }

        /// <summary>
        /// Add {culture?} route segment
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_culture, selector.AttributeRouteModel);
                }
                else
                {
                    selector.AttributeRouteModel = _culture;
                }
            }
        }
    }
}
