using System;
using System.Security.AccessControl;

namespace BolgMVC.CoreLayer.DTOs.Postcomments;

public class PostCommentDto
{
    public string Text { get; set; }
    public string UserFullName { get; set; }
    public DateTime CreationDate { get; set; }


}

public class CreatePostCommentDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }


}