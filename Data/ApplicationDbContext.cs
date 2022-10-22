using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApp.Models.Immunization> Immunization { get; set; }
        public DbSet<WebApp.Models.Organization> Organization { get; set; }
        public DbSet<WebApp.Models.Patient> Patient { get; set; }
        public DbSet<WebApp.Models.Provider> Provider { get; set; }
        public DbSet<WebApp.Models.RecordBase> RecordBase { get; set; }
    }
}