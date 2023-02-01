using NUnit.Framework;
using aspnetserver.Data;
using Microsoft.EntityFrameworkCore;
using aspnetserver.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using aspnetserver.Data.Models;
using aspnetserver.Data.DTOs;

namespace UnitTests
{
    public class PostsControllerTests
    {
        private List<Post> postFixtures = new List<Post>
        {
            new Post()
            {
                PostId = 1,
                Title = "Looking for awesome peeps",
                Content = "Hey there, I'm content for post 1 and I'm on the lookout",
                CategoryId = 1,
                UserId = 1
            },
            new Post()
            {
                PostId = 2,
                Title = "I'm cool",
                Content = "Hey there, I'm cool and I'm post 2",
                CategoryId = 1,
                UserId = 1
            },
            new Post()
            {
                PostId = 3,
                Title = "Whats happening guys gals and nonbinary pals",
                Content = "Hey there, I'm cool and I'm post 3, I stole the title for the cooking guy on yt",
                CategoryId = 1,
                UserId = 2
            },
            new Post()
            {
                PostId = 4,
                Title = "Will I be awesome some day?",
                Content = "Hey there, I'm not so cool rn and I'm only 8 and I'm post 4",
                CategoryId = 1,
                UserId = 2
            },
            new Post()
            {
                PostId = 6,
                Title = "Finna bust a quacker",
                Content = "Hey there, I'm urban and cool and I'm post 6, this is not a drill im so lit",
                CategoryId = 1,
                UserId = 2
            }
        };

        private async Task<AppDBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDBContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Posts.CountAsync() <= 0)
            {
                for (var i = 0; i < postFixtures.Count; i++)
                {
                    databaseContext.Posts.Add(postFixtures[i]);
                }
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [Test]
        public async Task GetPostsAsync_Works()
        {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var postController = new PostsController(dbContext);

            // Act
            var result1 = await postController.GetHomePagePostsAsync();

            // Assert
            Assert.NotNull(result1.Result);
            Assert.AreEqual(result1.Result.GetType(), typeof(OkObjectResult));
            OkObjectResult result2 = (OkObjectResult)result1.Result;
            List<PostDTO> postDtos = (List<PostDTO>)result2.Value;
            Assert.AreEqual(postDtos.Count, postFixtures.Count);
        }

        [Test]
        public async Task CreatePostAsync_Works()
        {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var postController = new PostsController(dbContext);
            var postToAdd = new PostDTO()
            {
                PostId = 90,
                Content = "I'm awesome",
                Title = "Test",
                CategoryId = 1,
                UserId = 1
            };
            var postLength = postFixtures.Count;

            // Act
            var posts = await postController.CreatePostAsync(postToAdd);

            // Assert
            Assert.AreEqual(posts.GetType(), typeof(OkObjectResult));
            Assert.That(await dbContext.Posts.CountAsync(), Is.EqualTo(postLength + 1));
        }

        [Test]
        public async Task DeletePostAsync_Works()
        {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var postController = new PostsController(dbContext);
            var postLength = postFixtures.Count;

            // Act
            var posts = await postController.DeletePostAsync(6);

            // Assert
            Assert.AreEqual(posts.GetType(), typeof(OkObjectResult));
            Assert.That(await dbContext.Posts.CountAsync(), Is.EqualTo(postLength - 1));
        }
    }
}