using System.Data.Entity;

namespace TravelTripProje.Models.Sınıflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        //public DbSet<Context> Contexts { get; set; }
        public DbSet<Hakkimizda> Hakkimidas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
    }
}