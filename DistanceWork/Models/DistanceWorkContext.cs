using Microsoft.EntityFrameworkCore;
using DistanceWork.Models;

namespace DistanceWork.Models
{
    public class DistanceWorkContext : DbContext
    {
        public DistanceWorkContext(DbContextOptions<DistanceWorkContext> options)
           : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<DistanceWork.Models.Job> Job { get; set; }


    }
}
