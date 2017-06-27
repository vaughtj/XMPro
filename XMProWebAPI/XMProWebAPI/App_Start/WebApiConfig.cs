using System.Web.Http;
using System.Web.OData.Builder;
using XMProWebAPI.Models;
using System.Web.OData.Extensions;

namespace XMProWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional });


            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<ParcelDeliveries>("ParcelDeliveries");
            builder.EntitySet<Parcels>("Parcels");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());



        }
    }
}
