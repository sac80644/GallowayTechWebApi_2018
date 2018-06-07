using System.Data.Entity;

namespace GallowayTechWebApi_2018.Models
{
    public partial class SiteContentContext : DbContext
    {
        //You should always use the name= syntax when you are using a connection string in the config file. This ensures that if the connection string is not present then Entity Framework will throw rather than creating a new database by convention.
        public SiteContentContext() : base("name=SiteContentContext")
        {
        }

        public virtual DbSet<SiteContent> SiteContent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteContent>()
                .Property(e => e.Content)
                .IsUnicode(false);
        }
    }
}