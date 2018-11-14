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
    [RoutePrefix("api/PropertyType")]
    public class PropertyTypeController : ApiController
    {
        RepositoryPropertyType propertyTypesRepository = new RepositoryPropertyType();

        // GET: api/PropertyTypes
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPropertyTypes()
        {
            return Ok(propertyTypesRepository.GetAllPropertyType());
        }

        // GET: api/PropertyTypes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PropertyTypes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PropertyTypes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PropertyTypes/5
        public void Delete(int id)
        {
        }
    }
}
