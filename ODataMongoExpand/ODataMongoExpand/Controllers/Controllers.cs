using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Web.OData;
using ODataMongoExpand.Models;
using System.Collections.Generic;

namespace ODataMongoExpand.Controllers
{
    //[EnableQuery(PageSize = 1)]
    [EnableQuery]
    public class MongoController : ODataController
    {
        public IQueryable<Person> Get()
        {
            IMongoDatabase db = (new MongoClient()).GetDatabase(TestSettings.dbName);
            IMongoCollection<Person> collection = db.GetCollection<Person>(TestSettings.colPeople);
            IMongoQueryable<Person> queryable = collection.AsQueryable<Person>();

            return queryable;
        }
    }

    [EnableQuery]
    public class StaticController : ODataController
    {
        public IQueryable<Person> Get()
        {
            IMongoDatabase db = (new MongoClient()).GetDatabase(TestSettings.dbName);
            List<Person> data = db.GetCollection<Person>(TestSettings.colPeople).AsQueryable().ToList();

            return data.AsQueryable();
        }
    }
}