﻿using aspnetserver.Data;
using aspnetserver.Data.DTOs;
using aspnetserver.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public CommentsController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CreateCommentDTO>>> GetCommentsByPostIdAsync(int postid)
        {
            Post validatePost = await _dbContext.Posts.FindAsync(postid);
            if (validatePost == null) return BadRequest("Post does not exist");
            List<CreateCommentDTO> commentsToReturn = await _dbContext.Comments
                .Where(e => e.PostId == postid)
                .Select(e => new CreateCommentDTO(e))
                .ToListAsync();
            if (commentsToReturn.Count > 0)
            {
                return Ok(commentsToReturn);
            }
            return BadRequest("No comments found");
        }

        [HttpPost]
        public async Task<ActionResult<CreateCommentDTO>> CreateCommentAsync(CreateCommentDTO commentDTO)
        {
            Post validatePost = await _dbContext.Posts.FindAsync(commentDTO.PostId);
            if (validatePost == null) return BadRequest("Post does not exist");
            try
            {
                Comment commentToCreate = new Comment(commentDTO);
                await _dbContext.Comments.AddAsync(commentToCreate);
                if (await _dbContext.SaveChangesAsync() >= 1)
                {
                    commentDTO.CommentId = commentToCreate.CommentId;
                    return Ok(commentDTO);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return BadRequest("Comment failed to create");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCommentAsync(CreateCommentDTO commentDTO)
        {
            try
            {
                Comment commentToUpdate = new Comment(commentDTO);
                _dbContext.Comments.Update(commentToUpdate);
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
                return BadRequest("Comment failed to update");
            }
        }

        [HttpDelete("{id:int}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCommentAsync(int id)
        {
            try
            {
                var commentToDelete = await _dbContext.Comments.FirstOrDefaultAsync(comment => comment.CommentId == id);
                if (commentToDelete == null) throw new Exception();
                _dbContext.Comments.Remove(commentToDelete);
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
                return BadRequest("Comment failed to delete");
            }
        }
    }
}
