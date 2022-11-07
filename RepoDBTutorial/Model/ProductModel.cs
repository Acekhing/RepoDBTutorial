using RepoDb.Attributes;
using RepoDBTutorial.Handlers;

namespace RepoDBTutorial.Model
{
    public class ProductModel
    {
        public long ID { get; set; }

        [PropertyHandler(typeof(ProductNamePropertyHandler))]
        public string? Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
