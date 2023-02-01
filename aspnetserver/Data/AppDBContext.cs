using aspnetserver.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public sealed class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries().Where(e => e.Entity is IEntityDate && e.State == EntityState.Added).ToList();
            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").CurrentValue = DateTime.Now;
            });
            var EditedEntities = ChangeTracker.Entries().Where(e => e.Entity is IEntityDate && e.State == EntityState.Modified).ToList();
            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedDate").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // return;

            // seeding logic, uncomment only when needed

            Category[] catsToSeed = new Category[]
            {
                new Category()
                {
                    CategoryId = 1,
                    Title = "General",
                    Description = "Anything music-related goes here"
                },
                new Category()
                {
                    CategoryId = 2,
                    Title = "Guitar",
                    Description = "Guitars are awesome, give it up for guitars"
                },
                new Category()
                {
                    CategoryId = 3,
                    Title = "Synths",
                    Description = "We're ready to trip out to synths"
                },
                new Category()
                {
                    CategoryId = 4,
                    Title = "Vocals",
                    Description = "Anything with vocals, vocal performances, healthy vocal techniques, etc are welcome"
                }
            };

            User[] usersToSeed = new User[3]
            {
                new User()
                {
                    UserId = 1,
                    Username = "Barney Dino",
                    Email = "test@test.com"
                },
                new User()
                {
                    UserId = 2,
                    Username = "Danny Dino",
                    Email = "test2@test.com"
                },
                new User()
                {
                    UserId = 3,
                    Username = "Billy Bob",
                    Email = "test3@test.com"
                }
            };

            Post[] postsToSeed = new Post[6];
            Comment[] commentsToSeed = new Comment[6];

            for (int i = 1; i <= 6; i++)
            {
                postsToSeed[i - 1] = new Post()
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"This is post {i} and it has some very interesting content.",
                    CategoryId = 1,
                    UserId = (i % 3) + 1,
                };
                commentsToSeed[i - 1] = new Comment()
                {
                    CommentId = i,
                    Content = $"This is a comment on post {i}, I love this post!",
                    PostId = i,
                    UserId = ((i + 1) % 3) + 1,
                };
            }

            UserRole[] rolesToSeed = new UserRole[3]
            {
                new UserRole()
                {
                    Id = 1,
                    RoleId = "Default",
                    UserId = 1
                },
                new UserRole()
                {
                    Id = 2,
                    RoleId = "Default",
                    UserId = 2
                },
                new UserRole()
                {
                    Id = 3,
                    RoleId = "Admin",
                    UserId = 3
                }
            };

            modelBuilder.Entity<Category>().HasData(catsToSeed);
            modelBuilder.Entity<User>().HasData(usersToSeed);
            modelBuilder.Entity<Post>().HasData(postsToSeed);
            modelBuilder.Entity<Comment>().HasData(commentsToSeed);
            modelBuilder.Entity<UserRole>().HasData(rolesToSeed);
        }
    }
}
