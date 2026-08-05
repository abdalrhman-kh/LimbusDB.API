using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Data
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "5d12c03d-7435-46b1-8765-9a3ec0598d1c";
            var writerId = "157ea661-e1e5-4d56-afcf-dd06ce0c9035";

            var roles = new List<IdentityRole>() {
                new IdentityRole
                {
                    Id = readerId,
                    Name = "Reader",
                    NormalizedName = "READER",
                    ConcurrencyStamp = readerId
                },

                new IdentityRole
                {
                    Id = writerId,
                    Name = "Writer",
                    NormalizedName = "WRITER",
                    ConcurrencyStamp = writerId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
