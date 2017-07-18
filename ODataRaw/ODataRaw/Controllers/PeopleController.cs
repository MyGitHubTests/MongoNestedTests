using ODataRaw.DataSource;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ODataRaw.Controllers
{
    [EnableQuery]
    public class PeopleController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.People.AsQueryable());
        }
    }
}