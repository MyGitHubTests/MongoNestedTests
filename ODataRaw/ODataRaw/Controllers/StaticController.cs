using MongoDB.Driver;
using ODataRaw.DataSource;
using ODataRaw.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ODataRaw.Controllers
{
    //[EnableQuery(PageSize = 1)]
    [EnableQuery]
    public class StaticController : ODataController
    {
        public IQueryable<Person> Get()
        {
            IMongoDatabase db = (new MongoClient()).GetDatabase("demo");
            List<Person> data = db.GetCollection<Person>("People").AsQueryable().ToList();

            return data.AsQueryable();

            // From static object
            //return DemoDataSources.Instance.People.AsQueryable();
        }
    }
}