using BolgMVC.CoreLayer.DTOs.Posts;
using BolgMVC.CoreLayer.Services.Posts;
using BolgMVC.Web.Models.Search;
using Microsoft.AspNetCore.Mvc;

namespace BolgMVC.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPostService _postService;

        public SearchController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int pageId = 1, string categorySlug = "", string q = null)
        {
            var filter = _postService.GetPostByFilter(new PostFilterParams()
            {
                PageId = pageId,
                CategorySlug = categorySlug,
                Take = 1,
                Title = q
            });

            var model = new SearchViewModel()
            {
                Filter = filter
            };
            return View(model);

        }

        public IActionResult Pagination(int pageId = 1, string categorySlug = "", string q = null)
        {
            var model = _postService.GetPostByFilter(new PostFilterParams()
            {
                PageId = pageId,
                CategorySlug = categorySlug,
                Take = 1,
                Title = q
            });

            return PartialView("_SearchView", model);
        }
    }
}