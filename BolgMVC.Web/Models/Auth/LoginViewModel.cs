using System.ComponentModel.DataAnnotations;

namespace BolgMVC.Web.Models.Auth;

public class LoginViewmodel
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string UserName { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Password { get; set; }
}