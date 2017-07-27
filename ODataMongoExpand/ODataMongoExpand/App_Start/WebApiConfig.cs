// http://www.odata.org/blog/how-to-use-web-api-odata-to-build-an-odata-v4-service-without-entity-framework/
using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using ODataMongoExpand.Models;

namespace ODataMongoExpand
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Create db and collection with test data
            TestSettings.Initialize();

            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";

            builder.EntitySet<Person>("Mongo");
            builder.EntitySet<Person>("Static");

            var edmModel = builder.GetEdmModel();

            return edmModel;
        }
    }
}
