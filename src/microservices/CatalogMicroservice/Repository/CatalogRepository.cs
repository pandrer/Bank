using CatalogMicroservice.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogMicroservice.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly IMongoCollection<CatalogItem> _col;

        public CatalogRepository(IMongoDatabase db)
        {
            _col = db.GetCollection<CatalogItem>(CatalogItem.DocumentName);
        }

        public List<CatalogItem> GetCatalogItems() =>
            _col.Find(FilterDefinition<CatalogItem>.Empty).ToList();

        public CatalogItem GetCatalogItem(Guid catalogItemId) =>
            _col.Find(c => c.Id == catalogItemId).FirstOrDefault();

        public List<CatalogItem> GetCatalogItemsByCategoryId(Guid categoryItemId, string parent) =>
            _col.Find(c => c.Category.Id == categoryItemId && c.ParentKey == parent).ToList();

        public void InsertCatalogItem(CatalogItem catalogItem) =>
            _col.InsertOne(catalogItem);

        public void UpdateCatalogItem(CatalogItem catalogItem) =>
            _col.UpdateOne(c => c.Id == catalogItem.Id, Builders<CatalogItem>.Update
                .Set(c => c.Key, catalogItem.Key)
                .Set(c => c.Value, catalogItem.Value)
                .Set(c => c.Category, catalogItem.Category));

        public void DeleteCatalogItem(Guid catalogItemId) =>
            _col.DeleteOne(c => c.Id == catalogItemId);
    }
}
