using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ODataRaw.DataSource;
using ODataRaw.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ODataRaw.Controllers
{
    //[EnableQuery(PageSize = 1)]
    [EnableQuery]
    public class MongoController : ODataController
    {
        //public IQueryable<Person> Get()
        //{
        //    return DemoDataSources.Instance.People.AsQueryable();
        //}

        //public IHttpActionResult Get()
        //{
        //    return Ok(DemoDataSources.Instance.People.AsQueryable());
        //}

        public IQueryable<Person> Get()
        {
            IMongoDatabase db = (new MongoClient()).GetDatabase("demo");

            IMongoCollection<Person> collection = db.GetCollection<Person>("People");
            IMongoQueryable<Person> queryable = collection.AsQueryable<Person>();

            return queryable;
        }
    }
}