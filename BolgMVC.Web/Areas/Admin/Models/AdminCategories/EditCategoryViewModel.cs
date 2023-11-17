using System.ComponentModel.DataAnnotations;

namespace BlogMVC.Web.Areas.Admin.Models.AdminCategories;

public class EditCategoryViewModel
{
    public int id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است ")]
    public string Title { get; set; }

    [Display(Name = "Slug")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است ")]
    public string Slug { get; set; }

    [Display(Name = "  با - از هم جدا کنید (MetaTag)")]
    [Required(ErrorMessage = "وارد کردن MetaTag اجباری است ")]
    public string MetaTag { get; set; }


    [Display(Name = "MetaDescription")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است ")]
    public string MetaDescription { get; set; }


}