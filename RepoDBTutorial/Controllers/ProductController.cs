using Microsoft.AspNetCore.Mvc;
using RepoDBTutorial.Model;
using RepoDBTutorial.Repositories;

namespace RepoDBTutorial.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController: ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel productModel)
        {
            if(productModel == null)
            {
                return new BadRequestResult();
            }

            _productRepository.Create(productModel);
            return new OkObjectResult(new {productId = productModel.ID});
        }

        [HttpGet("/api/[controller]/id")]
        public IActionResult GetProductById([FromQuery] long id)
        {
            if(id == 0)
            {
                return new NotFoundResult();
            }

            var product = _productRepository.GetById(id);
            return product == null ? new NotFoundResult() : new OkObjectResult(product);
        }

        [HttpGet("/api/[controller]/name")]
        public IActionResult GetProductByName([FromQuery] string? name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var products = _productRepository.GetByName(name);
            return products == null ? NotFound() : new OkObjectResult(products);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products == null ? NotFound() : new OkObjectResult(products);
        }

        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteProductById([FromRoute] long id)
        {
            if (id == 0)
            {
                return new NotFoundResult();
            }

            var productId = _productRepository.DeleteById(id);
            return new OkObjectResult(new {productId = productId });
        }

    }
}
