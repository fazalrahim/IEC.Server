using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using IEC.Model;
using System.Web;
using System.IO;

namespace IEC.Server.Controllers
{
    [RoutePrefix("api/Candidates")]
    public class CandidatesController : ApiController
    {
        private IECEntities db = new IECEntities();

        // GET: api/Candidates
        [HttpGet]
        [Route("get-all")]
        public IQueryable<Candidate> GetCandidates()
        {
            return db.Candidates;
        }

        // GET: api/Candidates/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IHttpActionResult> GetCandidate(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // PUT: api/Candidates/5
        [HttpPut]
        [Route("update")]
        public async Task<IHttpActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidate.CandidateId)
            {
                return BadRequest();
            }

            db.Entry(candidate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> PostCandidate(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidates.Add(candidate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidate.CandidateId }, candidate);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IHttpActionResult> DeleteCandidate(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            db.Candidates.Remove(candidate);
            await db.SaveChangesAsync();

            return Ok(candidate);
        }


        [HttpPost]
        [Route("UploadImage")]
        public IHttpActionResult UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            var httpContext = HttpContext.Current;

            if (httpContext.Request.Files.Count > 0)
            {
                //Loop through uploaded files  
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile postedFile = httpContext.Request.Files[i];
                    if (postedFile != null)
                    {
                        imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                        imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                        var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
                        postedFile.SaveAs(filePath);
                        // Construct file save path  
                       //var fileSavePath = Path.Combine(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["fileUploadFolder"]), httpPostedFile.FileName);

                        // Save the uploaded file  
                        // httpPostedFile.SaveAs(fileSavePath);
                    }
                }
            }
            ////Upload Image
            //var postedFile = httpRequest.Files["Image"];
            ////Create custom filename
            //if (postedFile != null)
            //{
            //    imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            //    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            //    var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
            //    postedFile.SaveAs(filePath);
            //}

            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidateExists(int id)
        {
            return db.Candidates.Count(e => e.CandidateId == id) > 0;
        }
    }
}