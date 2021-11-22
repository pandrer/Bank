using CatalogMicroservice.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogMicroservice.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<CategoryItem> _col;

        public CategoryRepository(IMongoDatabase db)
        {
            _col = db.GetCollection<CategoryItem>(CategoryItem.DocumentName);
        }

        public List<CategoryItem> GetCategories() =>
            _col.Find(FilterDefinition<CategoryItem>.Empty).ToList();

        public CategoryItem GetCategory(Guid categoryId) =>
            _col.Find(c => c.Id == categoryId).FirstOrDefault();

        public CategoryItem GetCategory(string categoryName) =>
            _col.Find(c => c.Name == categoryName).FirstOrDefault();

        public void InsertCategory(CategoryItem category) =>
            _col.InsertOne(category);

        public void UpdateCategory(CategoryItem category) =>
            _col.UpdateOne(c => c.Id == category.Id, Builders<CategoryItem>.Update
                .Set(c => c.Name, category.Name));

        public void DeleteCategory(Guid categoryId) =>
            _col.DeleteOne(c => c.Id == categoryId);
    }
}
