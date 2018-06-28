using Microsoft.EntityFrameworkCore;
namespace socialApi.Models
{
    public class CommentLikeContext : DbContext
    {
        public CommentLikeContext(DbContextOptions<CommentLikeContext> options)
            : base(options)
        {
        }
        public DbSet<CommentLike> CommentLikes { get; set; }
    }
}