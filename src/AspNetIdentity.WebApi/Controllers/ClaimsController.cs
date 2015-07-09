using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/claims")]
    public class ClaimsController : BaseApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult GetClaims()
        {
            var identity = User.Identity as ClaimsIdentity;

            var claims = identity.Claims.Select(x => new { subject = x.Subject.Name, type = x.Type, value = x.Value });

            return Ok(claims);
        }
    }
}
