using BolgMVC.CoreLayer.DTOs.Postcomments;
using BolgMVC.CoreLayer.DTOs.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BolgMVC.Web.Models.Post;

public class PostViewModel
{
    public PostDto Post { get; set; }
    public List<PostDto> RelatedPosts { get; set; }
    public List<PostCommentDto> PostComments { get; set; }

    [BindProperty]
    public List<PostDto> PupolarPosts { get; set; }

    [BindProperty]
    public int PostId { get; set; }

    [BindProperty]
    public string Text { get; set; }

}