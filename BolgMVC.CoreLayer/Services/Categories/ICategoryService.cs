using BolgMVC.CoreLayer.DTOs.Categories;
using BolgMVC.CoreLayer.Utilities;

namespace BolgMVC.CoreLayer.Services.Categories;

public interface ICategoryService
{
    List<CategoryDto> GetAllCategories();
    CategoryDto GetCategoryById(int id);
    CategoryDto GetCategoryBySlug(string slug);
    List<CategoryDto> GetChildCategories(int parentId);
    OperationResult CreateCategory(CreateCategoryDto createCategoryDto);
    OperationResult EditCategory(EditCategoryDto editDto);

    bool IsSlugExist(string slug);
}