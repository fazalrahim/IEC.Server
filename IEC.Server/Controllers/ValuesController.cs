using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IEC.Server.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        //[Route("Get")]
        [HttpGet]
        [Route("testall")]
        public string[] Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values        
        [HttpGet]
        [Route("test")]
        public IHttpActionResult Geting()
        {
            return Ok("heheh");
        }

        // GET api/values/5
        [Route("test-by/{id}")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
