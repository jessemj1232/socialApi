using Microsoft.EntityFrameworkCore;
namespace socialApi.Models
{
    public class PostLikeContext : DbContext
    {
        public PostLikeContext(DbContextOptions<PostLikeContext> options)
            : base(options)
        {
        }
        public DbSet<PostLike> PostLikes { get; set; }
    }
}