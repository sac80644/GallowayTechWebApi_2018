using System.Data.Entity;

namespace GallowayTechWebApi_2018.Models
{
    public partial class PhotoAlbumContext : DbContext
    {
        //You should always use the name= syntax when you are using a connection string in the config file. This ensures that if the connection string is not present then Entity Framework will throw rather than creating a new database by convention.
        public PhotoAlbumContext() : base("name=PhotoAlbumContext")
        {
        }

        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Albums> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photos>()
                .Property(e => e.Caption)
                .IsUnicode(true);
        }
    }
}