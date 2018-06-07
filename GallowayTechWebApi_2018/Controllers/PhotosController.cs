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
using System.Web.Http.Description;
using GallowayTechWebApi_2018.Models;

namespace GallowayTechWebApi_2018.Controllers
{

    //https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2

    public class PhotosController : ApiController
    {
        private PhotoAlbumContext db = new PhotoAlbumContext();

        // GET: api/Photos
        public IQueryable<Photos> GetPhotos()
        {
            return db.Photos;
        }

        [Route("api/Photos/{size}")]
        public IQueryable<Photos> GetPhotos(string size)
        {
            return db.Photos.Where(p => p.Size == size);
        }

        [Route("api/Photos/{id:int}/size/{size}")]
        public IQueryable<Photos> GetPhotos(int id, string size)
        {
            return db.Photos.Where(p => p.PhotoID == id && p.Size == size);
        }
        
        [Route("api/Album/{id:int}")]
        public IQueryable<Photos> GetAlbumPhotos(int id)
        {
            return db.Photos.Where(p => p.AlbumID == id && p.Size == "Full");
        }

        //// GET: api/Photos/5/size/Thumb
        //[Route("api/Photos/{id:int}/size/{size}")]
        //[ResponseType(typeof(Photos))]
        //public async Task<IHttpActionResult> GetPhotos(int id, string size)
        //{
        //    //don't now how to include the queryable wiht async
        //    //return db.Photos.Where(p => p.PhotoID == id && p.Size == size);

        //    Photos photos = await db.Photos.FindAsync(id);
        //    if (photos == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(photos);
        //}

        //This will throw an error right now as you need to specify a PhotoId and size
        // GET: api/Photos/5
        //[Route("api/Photos/{id:int}")]
        //[ResponseType(typeof(Photos))]
        //public async Task<IHttpActionResult> GetPhotos(int id)
        //{
        //    Photos photos = await db.Photos.FindAsync(id);
        //    if (photos == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(photos);
        //}

        // PUT: api/Photos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhotos(int id, Photos photos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photos.PhotoID)
            {
                return BadRequest();
            }

            db.Entry(photos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotosExists(id))
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

        // POST: api/Photos
        [ResponseType(typeof(Photos))]
        public async Task<IHttpActionResult> PostPhotos(Photos photos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Photos.Add(photos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = photos.PhotoID }, photos);
        }

        // DELETE: api/Photos/5
        [ResponseType(typeof(Photos))]
        public async Task<IHttpActionResult> DeletePhotos(int id)
        {
            Photos photos = await db.Photos.FindAsync(id);
            if (photos == null)
            {
                return NotFound();
            }

            db.Photos.Remove(photos);
            await db.SaveChangesAsync();

            return Ok(photos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhotosExists(int id)
        {
            return db.Photos.Count(e => e.PhotoID == id) > 0;
        }
    }
}