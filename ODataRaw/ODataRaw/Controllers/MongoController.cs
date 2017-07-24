using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ODataRaw.Models;
using System.Linq;
using System.Web.OData;

namespace ODataRaw.Controllers
{
    //[EnableQuery(PageSize = 1)]
    [EnableQuery]
    public class MongoController : ODataController
    {
        public IQueryable<Person> Get()
        {
            IMongoDatabase db = (new MongoClient()).GetDatabase("demo");

            IMongoCollection<Person> collection = db.GetCollection<Person>("People");
            IMongoQueryable<Person> queryable = collection.AsQueryable<Person>();

            return queryable;
        }
    }
}