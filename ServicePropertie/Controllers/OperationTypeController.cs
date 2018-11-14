using ServicePropertie.Models;
using ServicePropertie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicePropertie.Controllers
{
    [EnableCors(origins: "https://localhost:44353", headers: "*", methods: "*")]
    [RoutePrefix("api/operationtype")]
    public class OperationTypeController : ApiController
    {
        RepositoryOperationType repositoryOperationTypes = new RepositoryOperationType();
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOperationTypes()
        {
            return Ok(repositoryOperationTypes.GetAllOperationType());
        }
    }
}
