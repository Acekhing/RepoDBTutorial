using RepoDb;
using RepoDBTutorial.Model;
using System.Data.Common;

namespace RepoDBTutorial.Repositories
{
    public interface IProductRepository
    {
        int Create(ProductModel product);
        int Update(ProductModel product);
        int Delete(ProductModel product);
        int DeleteById(long productId);
        ProductModel GetById(long id);
        ProductModel GetByName(string name);
        IEnumerable<ProductModel> GetAll();

    }
}
