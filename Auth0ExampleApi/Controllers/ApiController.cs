using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Auth0ExampleApi.Controllers
{
    [RoutePrefix("api")]
    public class ApiController : System.Web.Http.ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Endpoints()
        {
            var apiIdentifier = ConfigurationManager.AppSettings["auth0:ApiIdentifier"];
            
            return Json(new
            {
                Public = $"{apiIdentifier}/public",
                Private = $"{apiIdentifier}/private",
                PrivateScoped = $"{apiIdentifier}/private-scoped",
                PrivateScopedOut = $"{apiIdentifier}/private-scopedout",
                Claims = $"{apiIdentifier}/claims"
            });
        }
        
        [HttpGet]
        [Route("public")]
        public IHttpActionResult Public()
        {
            return Json(new
            {
                Message = "Public endpoint. You don't need to be authenticated to see this."
            });
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        public IHttpActionResult Private()
        {
            return Json(new
            {
                Message = "Private endpoint. You need to be authenticated to see this."
            });
        }

        [HttpGet]
        [Route("private-scoped")]
        [ScopeAuthorize("read:guidance")]
        public IHttpActionResult Scoped()
        {
            return Json(new
            {
                Message = "Private endpoint. You need to be authenticated and have a scope of read:guidance to see this."
            });
        }
        
        [HttpGet]
        [Route("private-scopedout")]
        [ScopeAuthorize("read:random")]
        public IHttpActionResult ScopedOut()
        {
            return Json(new
            {
                Message = "Private endpoint. You need to be authenticated and have a scope of read:random to see this."
            });
        }

        [HttpGet]
        [Route("claims")]
        [Authorize]
        public object Claims()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            return Json(claimsIdentity.Claims.Select(c =>
            new
            {
                Type = c.Type,
                Value = c.Value
            }));
        }
    }
}