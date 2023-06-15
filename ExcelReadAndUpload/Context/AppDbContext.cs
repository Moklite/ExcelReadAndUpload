using ExcelReadAndUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelReadAndUpload.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
