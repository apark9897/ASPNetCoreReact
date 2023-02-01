using aspnetserver.Data;
using aspnetserver.Data.DTOs;
using aspnetserver.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Linq;

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
        public async Task<ActionResult<List<HomePostDTO>>> GetHomePagePostsAsync()
        {
            List<HomePostDTO> postsToReturn = await _dbContext.Posts
                .Include(e => e.Category)
                .Include(e => e.User)
                .Include(e => e.Comments)
                .Include(e => e.LastComment.User)
                .OrderByDescending(e => e.CreatedDate.Date)
                .OrderByDescending(e => e.Comments.Count)
                .Select(e => new HomePostDTO(e))
                .ToListAsync();
            if (postsToReturn.Count > 0)
            {
                return Ok(postsToReturn);
            }
            return BadRequest("No posts found");
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDTO>> GetPostByIdAsync(int id)
        {
            var postToReturn = await _dbContext.Posts
                .FirstOrDefaultAsync(post => post.PostId == id);
            if (postToReturn != null)
            {
                PostDTO result = new PostDTO(postToReturn);
                return Ok(result);
            }
            return BadRequest("No post with provided id found");
        }

        [HttpPost]
        public async Task<ActionResult> CreatePostAsync(PostDTO postDTO)
        {
            try
            {
                Post postToCreate = new Post(postDTO);
                Debug.Print(String.Format("Content: {0}, PostId: {1}, CategoryId: {2}", postToCreate.Content, postToCreate.PostId, postToCreate.CategoryId));
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
        public async Task<ActionResult> UpdatePostAsync(PostDTO postDTO)
        {
            try
            {
                Post postToUpdate = new Post(postDTO);
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

        [HttpDelete("{id:int}"), Authorize(Roles = "Admin")]
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
