using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using RepoDb.Interfaces;
using RepoDBTutorial.Model;
using System.Runtime;

namespace RepoDBTutorial.Repositories
{
    public class ProductRepository : BaseRepository<ProductModel, SqlConnection>, IProductRepository
    {
        public ProductRepository(IOptions<AppSetting> settings) 
            : base(settings.Value.ConnectionString,
                   commandTimeout: settings.Value.CommandTimeout)
        {

        }

        public int Create(ProductModel product)
        {
            return Insert<int>(product);
        }

        public int Delete(ProductModel product)
        {
            return Delete<ProductModel>(product);
        }

        public int DeleteById(long productId)
        {
            return Delete(productId);
        }

        public IEnumerable<ProductModel> Find(string query)
        {
            return Query(product => product.Name.Contains(query));
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return QueryAll();
        }

        public ProductModel GetById(long id)
        {
            return Query(p => p.ID == id).FirstOrDefault();
        }

        public ProductModel GetByName(string name)
        {
            return Query(p => p.Name == name).FirstOrDefault();
        }

        public long GetProductsCount()
        {
            return base.CountAll();
        }

        public int InsertMultiple(List<ProductModel> products)
        {
            return base.InsertAll(products);
        }

        public int Update(ProductModel product)
        {
            var isProductAvailable = base.Exists(product.ID);

            if (isProductAvailable)
            {
                var result = base.Update(product);
                return result;
            }
            return  0;
        }
    }
}
