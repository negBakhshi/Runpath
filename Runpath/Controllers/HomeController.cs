using Runpath.Helper;
using Newtonsoft.Json;
using System.Web.Http;
using System.Net;

namespace Runpath.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IAPIProvider _apiProvider;

        public HomeController(IAPIProvider apiProvider)
        {
            _apiProvider = apiProvider;
        }

        //GET /getresult
        [HttpGet]
        [Route("getresult")]
        public IHttpActionResult GetResult()
        {
            var allUsersPhotos = _apiProvider.CombineData();
            string json = JsonConvert.SerializeObject(allUsersPhotos, Formatting.Indented);

            return Content(HttpStatusCode.OK, json);
        }

        //GET /getresult
        [HttpGet]
        [Route("getresult/{userId}")]
        public IHttpActionResult GetResult(int userId)
        {
            var userPhotos = _apiProvider.CombineData(userId);
            string json = JsonConvert.SerializeObject(userPhotos, Formatting.Indented);
            
            return Content(HttpStatusCode.OK, json);
        }
    }
}
