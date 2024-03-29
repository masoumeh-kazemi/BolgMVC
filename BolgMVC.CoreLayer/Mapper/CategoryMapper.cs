﻿using BolgMVC.CoreLayer.DTOs.Categories;
using BolgMVC.DataLayer.Entities;

namespace BolgMVC.CoreLayer.Mapper;

public class CategoryMapper
{
    public static CategoryDto MapToDto(Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            MetaDescription = category.MetaDescription,
            MetaTag = category.MetaTag,
            ParentId = category.ParentId,
            Slug = category.Slug,
            Title = category.Title,
        };
    }

    public static void EditToCategory(EditCategoryDto editCategoryDto, Category category)
    {
        category.Slug = editCategoryDto.Slug;
        category.Title = editCategoryDto.Title;
        category.MetaDescription = editCategoryDto.MetaDescription;
        category.MetaTag = editCategoryDto.MetaTag;
    }
}