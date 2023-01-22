using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public sealed class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postsToSeed = new Post[6];

            for (int i = 1; i <= 6; i++)
            {
                postsToSeed[i - 1] = new Post()
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"This is post {i} and it has some very interesting content."
                };
                
            }

            modelBuilder.Entity<Post>().HasData(postsToSeed);
        }
    }
}
