using BolgMVC.CoreLayer.Services.FileManager;
using BolgMVC.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BolgMVC.Web.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _fileManger;

        public UploadController(IFileManager fileManger)
        {
            _fileManger = fileManger;
        }

        [Route("/Upload/Article")]
        [Authorize(Roles = "Admin")]
        public IActionResult UploadArticleImage(IFormFile upload)
        {
            if (upload == null)
                BadRequest();

            var imageName = _fileManger.SaveFileAndReturnName(upload, Directories.PostContentImage);
            return Json(new { Uploaded = true, url = Directories.GetPostContentImage(imageName) });

        }
    }
}
