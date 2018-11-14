using ServicePropertie.Models;
using ServicePropertie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace ServicePropertie.Controllers
{
    [EnableCors(origins: "https://localhost:44353", headers: "*", methods: "*")]
    [RoutePrefix("api/Property")]
    public class PropertyController : ApiController
    {
        RepositoryProperty propertyRepository = new RepositoryProperty();
    
        // GET: api/Property
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPropertys()
        {
            return Ok(propertyRepository.GetAllProperty());
        }

        // GET: api/Property/5
        [ResponseType(typeof(Property))]
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetPropertyById(int id)
        {
            Property property = propertyRepository.GetPropertyById(id);
            if (property == null)
                return NotFound();
            else
                return Ok(property);
        }

        // GET: api/Property/lat/lng
        [ResponseType(typeof(Property))]
        [HttpGet]
        [Route("GetPropertyById")]
        public IHttpActionResult GetPropertyByLatLng(string lat, string lng)
        {
            Property property = propertyRepository.GetPropertyByLatLng(lat,lng);
            if (property == null)
                return NotFound();
            else
                return Ok(property);
        }


        // POST: api/Property
        [ResponseType(typeof(Property))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostProperty([FromBody]Property property)
        {
            int propertyId = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            propertyId = propertyRepository.SaveProperty(property);
            //return CreatedAtRoute("", new { id = property.Id }, property);
            return Ok(propertyId);
        }

        // PUT: api/Property/5
        [ResponseType(typeof(Property))]
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            propertyRepository.UpdateProperty(property);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Property/5
        [ResponseType(typeof(Property))]
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            Property property = propertyRepository.GetPropertyById(id);
            if (property == null)
                return NotFound();
            else
            propertyRepository.DeleteProperty(id);
            return Ok(property);
        }
    }
}
