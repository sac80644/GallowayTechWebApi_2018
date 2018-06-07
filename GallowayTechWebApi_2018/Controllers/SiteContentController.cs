using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GallowayTechWebApi_2018.Models;

namespace GallowayTechWebApi_2018.Controllers
{
    //MVC Controller similar to API Controller except MVC inherits Controller while API inherits ApiController
    public class SiteContentController : ApiController
    {
        private SiteContentContext db = new SiteContentContext();

        // GET: api/SiteContent
        public IQueryable<SiteContent> GetSiteContent()
        {
            return db.SiteContent;
        }

        // GET: api/SiteContent/5
        [ResponseType(typeof(SiteContent))]
        public IHttpActionResult GetSiteContent(int id)
        {
            SiteContent siteContent = db.SiteContent.Find(id);
            if (siteContent == null)
            {
                return NotFound();
            }

            return Ok(siteContent);
        }

        // PUT: api/SiteContent/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSiteContent(int id, SiteContent siteContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siteContent.ID)
            {
                return BadRequest();
            }

            db.Entry(siteContent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteContentExists(id))
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

        // POST: api/SiteContent
        [ResponseType(typeof(SiteContent))]
        public IHttpActionResult PostSiteContent(SiteContent siteContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SiteContent.Add(siteContent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = siteContent.ID }, siteContent);
        }

        // DELETE: api/SiteContent/5
        [ResponseType(typeof(SiteContent))]
        public IHttpActionResult DeleteSiteContent(int id)
        {
            SiteContent siteContent = db.SiteContent.Find(id);
            if (siteContent == null)
            {
                return NotFound();
            }

            db.SiteContent.Remove(siteContent);
            db.SaveChanges();

            return Ok(siteContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SiteContentExists(int id)
        {
            return db.SiteContent.Count(e => e.ID == id) > 0;
        }
    }
}