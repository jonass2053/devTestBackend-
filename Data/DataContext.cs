using Microsoft.EntityFrameworkCore;
using BitmexApi.Models;

namespace BitmexApi.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Announcement> Announcement { get; set; }


    }
}
