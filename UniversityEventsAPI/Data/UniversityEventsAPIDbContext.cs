using Microsoft.EntityFrameworkCore;
using UniversityEventsAPI.Models;

namespace UniversityEventsAPI.Data
{
    public class UniversityEventsAPIDbContext : DbContext
    {
        public UniversityEventsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UniversityEvent> UniversityEvents { get; set; }
    }
}
