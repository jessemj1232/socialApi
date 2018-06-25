using Microsoft.EntityFrameworkCore;
namespace socialApi.Models
{
    public class FollowingContext :DbContext
    {
        public FollowingContext(DbContextOptions<FollowingContext> options)
            : base(options)
        {
        }

        public DbSet<Following> Follows { get; set; }
    }
}
