using BolgMVC.CoreLayer.DTOs.Postcomments;
using BolgMVC.CoreLayer.Services.Comments;
using BolgMVC.CoreLayer.Services.Posts;
using BolgMVC.CoreLayer.Utilities;
using BolgMVC.DataLayer.Entities;
using BolgMVC.Web.Models.Post;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace BolgMVC.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public PostController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        [Route("/post/{slug}")]
        public IActionResult Index(string slug)
        {
            var post = _postService.GetPostBySlug(slug);
            var postComments = _commentService.GetComments(post.Id);
            var relatedPosts = _postService.GetRelatedPosts(post.CategoryId);
            var popularPost = _postService.GetPopularPosts();
            var model = new PostViewModel()
            {
                Post = post,
                PostComments = postComments,
                RelatedPosts = relatedPosts,
                PupolarPosts = popularPost
            };
            _postService.IncreaseVisit(slug);


            return View(model);
        }

        [HttpPost("/post/{slug}")]
        public IActionResult Index(string slug, PostViewModel post)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", new { slug = slug });

            if (!ModelState.IsValid)
            {
                var post2 = _postService.GetPostBySlug(slug);
                var postComments2 = _commentService.GetComments(post2.Id);
                var relatedPosts2 = _postService.GetRelatedPosts(post2.CategoryId);

                //var model2 = new PostViewModel()
                //{
                //    Post = post2,
                //    PostComments = postComments2,
                //    RelatedPosts = relatedPosts2
                //};
                //return View(model2);
            }

            _commentService.CreatePostComment(new CreatePostCommentDto()
            {
                PostId = post.PostId,
                Text = post.Text,
                UserId = User.GetUserId()
            });

            return RedirectToAction("Index", new { slug = slug });
        }

    }
}
