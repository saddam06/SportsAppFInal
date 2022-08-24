using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

namespace SportsApp.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<SportsApp.Models.Category> Category { get; set; }
        
        public DbSet<SportsApp.Models.Product> Product { get; set; }
        
        public DbSet<SportsApp.Models.Contact> Contact { get; set; }
        
        public DbSet<SportsApp.Models.BookingDetail> BookingDetail { get; set; }

       
    }
}
