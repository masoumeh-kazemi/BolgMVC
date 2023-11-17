using System.ComponentModel.DataAnnotations;

namespace BolgMVC.Web.Models.Auth;

public class RegisterViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string UserName { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    [MinLength(6, ErrorMessage = "کلمه عبور باید حداقل 6 کارکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string FullName { get; set; }
}