using CatalogMicroservice.Model;
using System;
using System.Collections.Generic;

namespace CatalogMicroservice.Repository
{
    public interface ICategoryRepository
    {
        void DeleteCategory(Guid categoryId);
        List<CategoryItem> GetCategories();
        CategoryItem GetCategory(Guid categoryId);
        CategoryItem GetCategory(string categoryName);
        void InsertCategory(CategoryItem category);
        void UpdateCategory(CategoryItem category);
    }
}