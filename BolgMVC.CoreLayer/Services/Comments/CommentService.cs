﻿using BolgMVC.CoreLayer.DTOs.Postcomments;
using BolgMVC.CoreLayer.Utilities;
using BolgMVC.DataLayer.Context;
using BolgMVC.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BolgMVC.CoreLayer.Services.Comments;

public class CommentService : ICommentService
{
    private readonly BlogContext _context;

    public CommentService(BlogContext context)
    {
        _context = context;
    }
    public List<PostCommentDto> GetComments(int postId)
    {
        var postComments = _context.PostComments
            .Include(d => d.Post)
            .Where(f => f.PostId == postId).Select(comment => new PostCommentDto()
            {
                Text = comment.Text,
                UserFullName = comment.User.FullName,
                CreationDate = comment.CreationDate
            }).ToList();
        return postComments;
    }

    public OperationResult CreatePostComment(CreatePostCommentDto createPostComment)
    {
        var comment = new PostComment()
        {
            Text = createPostComment.Text,
            PostId = createPostComment.PostId,
            UserId = createPostComment.UserId
        };
        _context.PostComments.Add(comment);
        _context.SaveChanges();
        return OperationResult.Success();
    }
}