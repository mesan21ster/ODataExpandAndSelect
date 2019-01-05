using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using ODataExpandAndSelect.Models;

namespace ODataExpandAndSelect
{
    public static class WebApiConfig
    {
        //private static IEdmModel GenerateEdmModel()
        //{
        //    var builder = new ODataConventionModelBuilder();
        //    builder.EntitySet<Category>("categorylist");
        //    return builder.GetEdmModel();
        //}


        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "WebAPITest";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Product>("Product");
            builder.EntitySet<Category>("Category");
            builder.EntitySet<Supplier>("Supplier");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
        public static void Register(HttpConfiguration config)
        {
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null); //new line
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
