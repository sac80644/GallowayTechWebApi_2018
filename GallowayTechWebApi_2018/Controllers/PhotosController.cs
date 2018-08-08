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

    [Authorize]
    public class PhotosController : ApiController
    {
        private PhotoAlbumContext db = new PhotoAlbumContext();

        // GET: api/Photos
        [AllowAnonymous]
        public IQueryable<Photo> GetPhotos()
        {
            return db.Photos;
        }

        [Route("api/Photos/{size}")]
        [HttpGet]
        [AllowAnonymous]
        public IQueryable<Photo> GetPhotos(string size)
        {
            return db.Photos.Where(p => p.Size == size);
        }

        [Route("api/Photos/{id:int}/size/{size}")]
        [AllowAnonymous]
        public IQueryable<Photo> GetPhotos(int id, string size)
        {
            return db.Photos.Where(p => p.PhotoID == id && p.Size == size);
        }

        [Route("api/Albums")]
        [AllowAnonymous]
        public IQueryable<Album> GetAlbums()
        {
            var albums = db.Albums.Include("Photos");
            return albums;
        }

        [Route("api/Albums/size/{size}")]
        [AllowAnonymous]
        public IQueryable<Album> GetAlbums(string size)
        {
            var albums = db.Albums;
            foreach (var album in albums)
            {
                album.Photos = db.Photos.Where(p => p.AlbumID == album.AlbumID && p.Size == size).ToList();
            }

            return albums;
        }

        [Route("api/Album/{id:int}")]
        [AllowAnonymous]
        public IQueryable<Photo> GetAlbumPhotos(int id)
        {
            return db.Photos.Where(p => p.AlbumID == id && p.Size == "Full");
        }

        [Route("api/Album/{id:int}/size/{size}")]
        [AllowAnonymous]
        public Album GetAlbumPhotos(int id, string size)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            var album = db.Albums
                .Where(a => a.AlbumID == id)
                //.Include(p => p.Photos)
                .FirstOrDefault();

            album.Photos = db.Photos.Where(p => p.Size == size & p.AlbumID == id).ToList();

            return album;
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

        // PUT: api/Photos/5
        [Route("api/Photos/{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhotos(int id, Photo photo)
        {
            return StatusCode(HttpStatusCode.NotImplemented);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photo.PhotoID)
            {
                return BadRequest();
            }

            db.Entry(photo).State = EntityState.Modified;

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
        [ResponseType(typeof(Photo))]
        public async Task<IHttpActionResult> PostPhotos(Photo photos)
        {
            return StatusCode(HttpStatusCode.NotImplemented);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Photos.Add(photos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = photos.PhotoID }, photos);
        }

        // DELETE: api/Photos/5
        [Route("api/Photos/{id:int}")]
        [ResponseType(typeof(Photo))]
        public async Task<IHttpActionResult> DeletePhotos(int id)
        {
            return StatusCode(HttpStatusCode.NotImplemented);

            Photo photos = await db.Photos.FindAsync(id);
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