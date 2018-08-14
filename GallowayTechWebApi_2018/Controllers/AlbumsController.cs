using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GallowayTechWebApi_2018.Models;

namespace GallowayTechWebApi_2018.Controllers
{
    [Authorize]
    public class AlbumsController : ApiController
    {
        private PhotoAlbumContext db = new PhotoAlbumContext();

        // GET: api/Albums
        [AllowAnonymous]
        public IQueryable<Album> GetAlbums()
        {
            return db.Albums.Include("Photos");
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
            var album = db.Albums
                .FirstOrDefault(a => a.AlbumID == id);

            if (album != null)
            {
                album.Photos = db.Photos.Where(p => p.Size == size & p.AlbumID == id).ToList();
            }

            return album;
        }

        // GET: api/Albums/5
        [AllowAnonymous]
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> GetAlbum(int id)
        {
            Album album = await db.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/Albums/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.AlbumID)
            {
                return BadRequest();
            }

            db.Entry(album).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/Albums
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = album.AlbumID }, album);
        }

        // DELETE: api/Albums/5
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> DeleteAlbum(int id)
        {
            Album album = await db.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            db.Albums.Remove(album);
            await db.SaveChangesAsync();

            return Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return db.Albums.Count(e => e.AlbumID == id) > 0;
        }
    }
}