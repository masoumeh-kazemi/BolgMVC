using BolgMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BolgMVC.CoreLayer.Services.Posts;
using BolgMVC.CoreLayer.DTOs;
using BolgMVC.CoreLayer.Services;
using BolgMVC.Web.Models.Home;

namespace BolgMVC.Web.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly IMainService _mainService;
        public HomeController(ILogger<HomeController> logger, IPostService postService, IMainService mainService)
        {
            _logger = logger;
            _postService = postService;
            _mainService = mainService;
        }

        public IActionResult Index()
        {
            var mainPageData = _mainService.GetData();

            return View(mainPageData);
        }


        public PartialViewResult PopularPost()
        {
            return PartialView("_PopularPosts", _postService.GetPopularPosts());
        }

    }
}