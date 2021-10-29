using System;

namespace CatalogMicroservice.Model
{
    public class CategoryItem
    {
        public static readonly string DocumentName = "categoryItems";

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
