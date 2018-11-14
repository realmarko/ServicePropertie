using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicePropertie.Controllers
{
    [EnableCors(origins: "https://localhost:44353", headers:"*",methods:"*")]
    [RoutePrefix("api/State")]
    public class StateController : ApiController
    {
        Repositories.RepositoryState state = new Repositories.RepositoryState();

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(state.GetAllState());
        }
    }
}
