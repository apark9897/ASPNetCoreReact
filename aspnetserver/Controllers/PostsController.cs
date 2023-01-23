using aspnetserver.Data;
using aspnetserver.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public PostsController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPostsAsync()
        {
            List<Post> postsToReturn = await _dbContext.Posts.ToListAsync();
            if (postsToReturn.Count > 0)
            {
                return Ok(postsToReturn);
            }
            return BadRequest("No posts found");
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> GetPostByIdAsync(int id)
        {
            var postToReturn = await _dbContext.Posts.FirstOrDefaultAsync(post => post.PostId == id);
            if (postToReturn != null)
            {
                return Ok(postToReturn);
            }
            return BadRequest("No post with provided id found");
        }

        [HttpPost]
        public async Task<ActionResult> CreatePostAsync(Post postToCreate)
        {
            try
            {
                await _dbContext.Posts.AddAsync(postToCreate);
                if (await _dbContext.SaveChangesAsync() >= 1)
                {
                    return Ok("Create successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return BadRequest("Post failed to create");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePostAsync(Post postToUpdate)
        {
            try
            {
                _dbContext.Posts.Update(postToUpdate);
                if (await _dbContext.SaveChangesAsync() >= 1)
                {
                    return Ok("Update successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return BadRequest("Post failed to update");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePostAsync(int id)
        {
            try
            {
                var postToDelete = await _dbContext.Posts.FirstOrDefaultAsync(post => post.PostId == id);
                if (postToDelete == null) throw new Exception();
                _dbContext.Posts.Remove(postToDelete);
                if (await _dbContext.SaveChangesAsync() >= 1)
                {
                    return Ok("Delete successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return BadRequest("Post failed to delete");
            }
        }
    }
}
