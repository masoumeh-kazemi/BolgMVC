using BolgMVC.CoreLayer.DTOs.Users;
using BolgMVC.CoreLayer.Services.Users;
using BolgMVC.CoreLayer.Utilities;
using BolgMVC.Web.Models.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BolgMVC.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _userService.UserRegister(new UserRegisterDto()
            {
                FullName = registerViewModel.FullName,
                UserName = registerViewModel.UserName,
                Password = registerViewModel.Password
            });

            if (user.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError("UserName", user.Message);
                return View();
            }
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewmodel loginViewmodel)
        {
            var user = _userService.UserLogin(new UserLoginDto()
            {
                Password = loginViewmodel.Password,
                UserName = loginViewmodel.UserName
            });
            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربری با این مشخصات یافت نشد");
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Test","Test"),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            //var properties = new AuthenticationProperties()
            //{
            //    IsPersistent = true
            //};
            HttpContext.SignInAsync(claimPrincipal);


            return Redirect("/");
        }

    }
}
