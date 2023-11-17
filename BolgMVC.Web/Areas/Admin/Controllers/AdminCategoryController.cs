using BlogMVC.Web.Areas.Admin.Models.AdminCategories;
using BolgMVC.CoreLayer.DTOs.Categories;
using BolgMVC.CoreLayer.Services.Categories;
using BolgMVC.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rap_Blog.Web.Areas.Admin;


namespace BolgMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminCategoryController : AdminControllerBase
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }

        [Route("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId)
        {
            return View();
        }

        [HttpPost("/admin/category/add/{parentId?}")]
        [ValidateAntiForgeryToken]

        public IActionResult Add(int? parentId, CreateCategoryViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createViewModel);
            }

            var category = new CreateCategoryDto()
            {
                Title = createViewModel.Title,
                Slug = createViewModel.Slug,
                MetaDescription = createViewModel.MetaDescription,
                MetaTag = createViewModel.MetaTag,
                ParentId = parentId
            };

            var result = _categoryService.CreateCategory(category);
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(createViewModel.Slug), result.Message);
                return View();
            }

            return RedirectToAction("Index");

        }


        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            var model = new EditCategoryViewModel()
            {
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Title = category.Title,
                Slug = category.Slug
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }

            var category = new EditCategoryDto()
            {
                Id = editViewModel.id,
                Title = editViewModel.Title,
                Slug = editViewModel.Slug,
                MetaDescription = editViewModel.MetaDescription,
                MetaTag = editViewModel.MetaTag,
            };

            var result = _categoryService.EditCategory(category);
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editViewModel.Slug), result.Message);
                return View(editViewModel);
            }
            return RedirectToAction("Index");
       
        }

        public IActionResult GetChildCategories(int parentId)
        {
            var childCategory = _categoryService.GetChildCategories(parentId);
            return new JsonResult(childCategory);
        }
    }
}
