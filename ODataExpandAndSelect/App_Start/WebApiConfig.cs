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
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null); 
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }
    }
}
