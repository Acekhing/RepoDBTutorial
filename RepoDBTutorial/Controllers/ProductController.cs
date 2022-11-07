using Microsoft.AspNetCore.Mvc;
using RepoDBTutorial.Model;
using RepoDBTutorial.Repositories;

namespace RepoDBTutorial.Controllers
{

    [Route("api/products")]
    [ApiController]

    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel productModel)
        {
            if (productModel == null)
            {
                return new BadRequestResult();
            }

            _productRepository.Create(productModel);
            return new OkObjectResult(new { productId = productModel.ID });
        }

        [HttpPost("all")]
        public IActionResult AddMultipleProducts([FromBody] List<ProductModel> products)
        {
            var result = _productRepository.InsertMultiple(products);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] long id)
        {
            if (id == 0)
            {
                return new NotFoundResult();
            }

            var product = _productRepository.GetById(id);
            return product == null ? new NotFoundResult() : new OkObjectResult(product);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products == null ? NotFound() : new OkObjectResult(products);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProductById([FromRoute] long id)
        {
            if (id == 0)
            {
                return new NotFoundResult();
            }

            var productId = _productRepository.DeleteById(id);
            return new OkObjectResult(new { productId = productId });
        }

        [HttpGet("search")]
        public IActionResult SearchProducts([FromQuery] string query)
        {
            var results = _productRepository.Find(query);
            return Ok(results);
        }

        [HttpGet("count")]
        public IActionResult GetProductCount()
        {
            var productsCount = _productRepository.GetProductsCount();
            return new OkObjectResult(new { totalProducts = productsCount });
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            var result = _productRepository.Update(product);
            return result == 0 ? new NotFoundResult() : new OkObjectResult(result);
        }

    }
}
