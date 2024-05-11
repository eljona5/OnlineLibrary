using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DataLayer.Entities;

namespace OnlineLibrary.DataLayer.DBContext
{
    public class OnlineLibraryDbContext : DbContext//IdentityDbContext
    {
       public OnlineLibraryDbContext() { }
        public OnlineLibraryDbContext(DbContextOptions<OnlineLibraryDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users {  get; set; }
    }
}
