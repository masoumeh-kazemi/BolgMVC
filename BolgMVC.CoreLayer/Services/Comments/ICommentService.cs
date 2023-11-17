using BolgMVC.CoreLayer.DTOs.Postcomments;
using BolgMVC.CoreLayer.Utilities;

namespace BolgMVC.CoreLayer.Services.Comments;

public interface ICommentService
{
    List<PostCommentDto> GetComments(int postId);
    OperationResult CreatePostComment(CreatePostCommentDto createPostComment);

}