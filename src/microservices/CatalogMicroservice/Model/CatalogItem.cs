using System;

namespace CatalogMicroservice.Model
{
    public class CatalogItem
    {
        public static readonly string DocumentName = "catalogItems";

        public Guid Id { get; set; }
        public CategoryItem Category { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string ParentKey { get; set; }
    }
}
