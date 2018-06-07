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
using GallowayTechWebApi_2018_Beta.Models;

namespace GallowayTechWebApi_2018_Beta.Controllers
{
    public class PhotoAlbumController : ApiController
    {
        private PhotoAlbumContext db = new PhotoAlbumContext();

        // GET: api/PhotoAlbum
        public IQueryable<Photos> GetPhotos()
        {
            return db.Photos;
        }

        // GET: api/PhotoAlbum/5
        [ResponseType(typeof(Photos))]
        public async Task<IHttpActionResult> GetPhotos(int id)
        {
            Photos photos = await db.Photos.FindAsync(id);
            if (photos == null)
            {
                return NotFound();
            }

            return Ok(photos);
        }

        // PUT: api/PhotoAlbum/5
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

        // POST: api/PhotoAlbum
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

        // DELETE: api/PhotoAlbum/5
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