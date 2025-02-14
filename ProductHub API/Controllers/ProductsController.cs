using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductHub_API.Dto.Products;
using ProductHub_API.Models;
using ProductHub_API.Services.Interfaces;
using System.Diagnostics;

namespace ProductHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<ResponseModel<IEnumerable<ProductsModel>>>> GetAllProducts()
        {
            var products = await _productsService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetProductById/{idProduct}")]
        public async Task<ActionResult<ResponseModel<ProductsModel>>> GetProductById(int idProduct)
        {
            var product = await _productsService.GetProductById(idProduct);
            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        [Authorize]

        public async Task<ActionResult<ResponseModel<IEnumerable<ProductsModel>>>> CreateProduct([FromBody] ProductsDto productDto)
        {
            var newProduct = await _productsService.CreateProduct(productDto);
            return Ok(newProduct);
        }

        [Authorize]
        [HttpDelete("DeleteProduct/{idProduct}")]
        public async Task<ActionResult<ResponseModel<IEnumerable<ProductsModel>>>> DeleteProduct(int idProduct)
        {
            var user = User.Identity?.Name; 
            Debug.WriteLine($"[API] Usuário autenticado: {user}"); 

            var product = await _productsService.DeleteProduct(idProduct);
            return Ok(product);
        }


        [HttpPut("UpdateProduct/{idProduct}")]
        [Authorize]

        public async Task<ActionResult<ResponseModel<IEnumerable<ProductsModel>>>> UpdateProduct(int idProduct, [FromBody] ProductsDto productDto)
        {
            var product = await _productsService.UpdateProduct(idProduct, productDto);
            return Ok(product);
        }
    }
}
